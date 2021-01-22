using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dadachMovie.Services
{
    public class AccountsService : BaseService, IAccountsService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILoggerService _logger;
        private readonly IRatingService _ratingService;
        private readonly IUserFavoriteMoviesService _userFavoriteMoviesService;
        private readonly string _containerName = "users";

        public AccountsService(UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            RoleManager<Role> roleManager,
                            IConfiguration configuration,
                            AppDbContext dbContext,
                            IMapper mapper,
                            IHttpContextAccessor httpContextAccessor,
                            IFileStorageService fileStorageService,
                            ILoggerService logger,
                            IRatingService ratingService,
                            IUserFavoriteMoviesService userFavoriteMoviesService)
            : base(dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _fileStorageService = fileStorageService;
            _logger = logger;
            _ratingService = ratingService;
            _userFavoriteMoviesService = userFavoriteMoviesService;
        }

        public async Task<Paging<UserDTO>> GetUsersPagingAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _userManager.Users.GridifyQueryableAsync(gridifyQuery,null);

            return new Paging<UserDTO> {Items = queryable.Query.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }

        public async Task<IdentityResult> RegisterUserAsync(UserCreationDTO userCreationDTO)
        {
            var user = new User { UserName = userCreationDTO.EmailAddress, Email = userCreationDTO.EmailAddress,
                                FirstName = userCreationDTO.FirstName, LastName = userCreationDTO.LastName,
                                RegisterDate = DateTimeOffset.Now};
            var register = await _userManager.CreateAsync(user, userCreationDTO.Password);
            if (!register.Succeeded)
            {
                var errors = new StringBuilder();
                foreach (var error in register.Errors)
                {
                    errors.Append($"{error.Code} "); 
                }
                _logger.LogWarn($"Failed to register {user}. Errors: {errors}");
            } else {
                _logger.LogInfo($"{user} registered successfully.");
            }
            return register;
        }

        public async Task<SignInResult> UserLoginAsync(UserInfo userInfo)
        {
            var signin = await _signInManager.PasswordSignInAsync(userInfo.EmailAddress,userInfo.Password,
                                                            isPersistent: false, lockoutOnFailure: false);
            if (!signin.Succeeded)
            {
                _logger.LogWarn($"Failed to login {userInfo.EmailAddress}.");
            } else {
                _logger.LogInfo($"{userInfo.EmailAddress} logged in successfully.");
            }
            return signin;
        }
            

        public async Task<List<string>> GetRolesListAsync() =>
            await _dbContext.Roles.Select(x => x.Name).ToListAsync();

        public async Task<int> AssignUserRoleAsync(EditRoleDTO editRoleDTO)
        {
            var user = await _userManager.FindByIdAsync(editRoleDTO.UserId);
            if (user == null)
            {
                _logger.LogWarn($"User {editRoleDTO.UserId} was not found.");
                return -1;
            }
            
            try
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
                _logger.LogInfo($"Added user {user.Email} to {editRoleDTO.RoleName} role.");
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to add user {user.Email} to {editRoleDTO.RoleName} role. Exception: {ex}");
                return 0;
            }
        }

        public async Task<int> RemoveUserRoleAsync(EditRoleDTO editRoleDTO)
        {
            var user = await _userManager.FindByIdAsync(editRoleDTO.UserId);
            if (user == null)
            {
                _logger.LogWarn($"User {editRoleDTO.UserId} was not found.");
                return -1;
            }
            
            try
            {
                await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
                _logger.LogInfo($"Removed user {user.Email} from {editRoleDTO.RoleName} role.");
                return 1;
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to remove user {user.Email} to {editRoleDTO.RoleName} role. Exception: {ex}");
                return 0;
            }
        }

        public async Task<UserToken> RenewUserBearerTokenAsync(string emailAddress) => 
            await BuildToken(emailAddress);

        public async Task<UserToken> BuildToken(string emailAddress)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, emailAddress),
                new Claim(ClaimTypes.Email, emailAddress),
            };

            var identityUser = await _userManager.FindByEmailAsync(emailAddress);
            var userClaims = await _userManager.GetClaimsAsync(identityUser);
            //var userRoles = await _userManager.GetRolesAsync(identityUser);

            claims.AddRange(userClaims);

            // foreach (var userRole in userRoles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role, userRole));
            //     var role = await _roleManager.FindByNameAsync(userRole);
            //     if(role != null)
            //     {
            //         var roleClaims = await _roleManager.GetClaimsAsync(role);
            //         foreach(Claim roleClaim in roleClaims)
            //         {
            //             claims.Add(roleClaim);
            //         }
            //     }
            // }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.Now.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        public async Task<int> UpdateUserAsync(UserUpdateDTO userUpdateDTO)
        {
            if (string.IsNullOrWhiteSpace(userUpdateDTO.CurrentEmailAddress))
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                userUpdateDTO.CurrentEmailAddress = currentUser.Email;
            }

            var user = await _userManager.FindByEmailAsync(userUpdateDTO.CurrentEmailAddress);
            if (user == null)
            {
                _logger.LogWarn($"User {userUpdateDTO.CurrentEmailAddress} was not found.");
                return -1;
            }
            
            if (!string.IsNullOrEmpty(userUpdateDTO.NewEmailAddress))
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, userUpdateDTO.NewEmailAddress);
                await _userManager.ChangeEmailAsync(user, userUpdateDTO.NewEmailAddress,token);
                await _userManager.UpdateNormalizedEmailAsync(user);
                await _userManager.SetUserNameAsync(user, userUpdateDTO.NewEmailAddress);
                await _userManager.UpdateNormalizedUserNameAsync(user);
                _logger.LogInfo($"Changed {userUpdateDTO.CurrentEmailAddress} email to {userUpdateDTO.NewEmailAddress}");
            }

            if (!string.IsNullOrEmpty(userUpdateDTO.NewPassword) && await _userManager.CheckPasswordAsync(user, userUpdateDTO.CurrentPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.NewPassword);
                _logger.LogInfo($"User {user.Email} password changed.");
            }

            if (userUpdateDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await userUpdateDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(userUpdateDTO.Picture.FileName);
                    user.Picture = await _fileStorageService.EditFile(content,
                                                                    extension,
                                                                    _containerName, 
                                                                    user.Picture, 
                                                                    userUpdateDTO.Picture.ContentType);
                }
            }
            
            user = _mapper.Map(userUpdateDTO, user);
            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"User {user.Email} updated successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to update user {user.Email}. Exception: {ex}");
                return 0;
            }
        }

        public async Task<UserDetailsDTO> GetCurrentUserDetailsAsync()
        {
            var user = await this.GetCurrentUserAsync();

            if (user == null)
                return null;
            
            var userDetails =  _mapper.Map<UserDetailsDTO>(user);
            var userRoles = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Role);
            foreach (var role in userRoles)
            {
                userDetails.Roles.Add(role.Value);
            }
            return userDetails;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var user = await _userManager.Users.Include(x => x.FavoriteMovies)
                                            .Include(x => x.MoviesRatings)
                                            .Include(x => x.Country)
                                            .Include(x => x.Comments)
                                            .FirstOrDefaultAsync(x => x.Email == this.GetCurrentUserEmail());
            if (user == null)
                return null;
            
            return user;
        }

        public string GetCurrentUserEmail() => 
            _httpContextAccessor.HttpContext.User.Identity.Name;

        public async Task<int> SaveUserRatingAsync(MovieRatingDTO movieRatingDTO)
        {
            if (movieRatingDTO.UserId == null)
            {
                var userEmail = this.GetCurrentUserEmail();
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                movieRatingDTO.UserId = user.Id.ToString();
            }

            return await _ratingService.SaveRatingAsync(movieRatingDTO);
        }

        public async Task<int> SaveUserFavoriteMoviesAsync(UserFavoriteMoviesDTO userFavoriteMoviesDTO)
        {
            if (userFavoriteMoviesDTO.UserId == null)
            {
                var userEmail = this.GetCurrentUserEmail();
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                userFavoriteMoviesDTO.UserId = user.Id.ToString();
            }

            return await _userFavoriteMoviesService.SaveUserFavoriteMoviesAsync(userFavoriteMoviesDTO);
        }
    }
}