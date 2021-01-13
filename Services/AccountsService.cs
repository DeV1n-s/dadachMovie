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
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileStorageService _fileStorageService;
        private readonly string _containerName = "users";

        public AccountsService(UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            IConfiguration configuration,
                            AppDbContext dbContext,
                            IMapper mapper,
                            IHttpContextAccessor httpContextAccessor,
                            IFileStorageService fileStorageService)
            : base(dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _fileStorageService = fileStorageService;
        }

        public async Task<Paging<UserDTO>> GetUsersPagingAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Users.GridifyQueryableAsync(gridifyQuery,null);
            return new Paging<UserDTO> {Items = queryable.Query.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }

        public async Task<UserToken> RegisterUserAsync(UserCreationDTO userCreationDTO)
        {
            var user = new User { UserName = userCreationDTO.EmailAddress, Email = userCreationDTO.EmailAddress,
                                FirstName = userCreationDTO.FirstName, LastName = userCreationDTO.LastName,
                                RegisterDate = DateTimeOffset.Now};

            var result = await _userManager.CreateAsync(user, userCreationDTO.Password);
            if (!result.Succeeded)       
                return null;
            
            return await BuildToken(userCreationDTO.EmailAddress);
        }

        public async Task<UserToken> UserLoginAsync(UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.EmailAddress,userInfo.Password,
                                                                isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return null;
            
            return await BuildToken(userInfo.EmailAddress);
        }

        public async Task<List<string>> GetRolesListAsync() =>
            await _dbContext.Roles.Select(x => x.Name).ToListAsync();

        public async Task<int> AssignUserRoleAsync(EditRoleDTO editRoleDTO)
        {
            var user = await _userManager.FindByIdAsync(editRoleDTO.UserId);
            if (user == null)
                return -1;
            
            try
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> RemoveUserRoleAsync(EditRoleDTO editRoleDTO)
        {
            var user = await _userManager.FindByIdAsync(editRoleDTO.UserId);
            if (user == null)
                return -1;
            
            try
            {
                await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<UserToken> RenewUserBearerTokenAsync(string emailAddress) =>
            await BuildToken(emailAddress);

        private async Task<UserToken> BuildToken(string emailAddress)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, emailAddress),
                new Claim(ClaimTypes.Email, emailAddress)
            };

            var identityUser = await _userManager.FindByEmailAsync(emailAddress);
            var claimsDB = await _userManager.GetClaimsAsync(identityUser);

            claims.AddRange(claimsDB);

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
                userUpdateDTO.CurrentEmailAddress = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _userManager.FindByEmailAsync(userUpdateDTO.CurrentEmailAddress);
            if (user == null)
                return -1;
            
            if (!string.IsNullOrEmpty(userUpdateDTO.NewEmailAddress))
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, userUpdateDTO.NewEmailAddress);
                await _userManager.ChangeEmailAsync(user, userUpdateDTO.NewEmailAddress,token);
                await _userManager.UpdateNormalizedEmailAsync(user);
                await _userManager.SetUserNameAsync(user, userUpdateDTO.NewEmailAddress);
                await _userManager.UpdateNormalizedUserNameAsync(user);
            }

            if (!string.IsNullOrEmpty(userUpdateDTO.NewPassword) && await _userManager.CheckPasswordAsync(user, userUpdateDTO.CurrentPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.NewPassword);
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
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<UserDTO> GetCurrentUserAsync()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.GetUserByEmailAsync(userEmail);
            if (user == null)
                return null;
            
            return user;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string emailAddress)
        {
            var user = await _userManager.FindByEmailAsync(emailAddress);
            if (user == null)
                return null;

            return _mapper.Map<UserDTO>(user);
        }
    }
}