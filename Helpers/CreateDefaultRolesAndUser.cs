using System;
using System.Security.Claims;
using System.Threading.Tasks;
using dadachMovie.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace dadachMovie.Helpers
{
    public static class ServiceExtensions
    {
        public static async Task CreateDefaultRolesAndUser(this IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                    roleResult = await RoleManager.CreateAsync(new Role() {Name = roleName, DisplayName = roleName});
            }

            var user = await UserManager.FindByEmailAsync("admin@email.com");
            if(user == null)
            {
                var poweruser = new User
                {
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    FirstName = "Default",
                    LastName = "Admin",
                    RegisterDate = DateTimeOffset.Now,
                    CountryId = 106
                };
                string adminPassword = "P@ssw0rd";

                var createPowerUser = await UserManager.CreateAsync(poweruser, adminPassword);
                if (createPowerUser.Succeeded)
                    await UserManager.AddClaimAsync(poweruser, new Claim(ClaimTypes.Role, "Admin"));
            }
        }
    }
}