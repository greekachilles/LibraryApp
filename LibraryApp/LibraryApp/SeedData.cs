using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp
{
    public class SeedData
    {
        public static async Task InitAsync(
            IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await EnsureRolesAsync(roleManager);


            var userManager = services
                .GetRequiredService<UserManager<IdentityUser>>();

            await EnsureTestAdminAsync(userManager);
        }

        private static async Task EnsureTestAdminAsync(
            UserManager<IdentityUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "admin@library.local")
                .SingleOrDefaultAsync();

            if (testAdmin != null) return;

            testAdmin = new IdentityUser
            {
                UserName = "admin@library.local",
                Email = "admin@library.local"
            };

            await userManager.CreateAsync(
                testAdmin, "P@ssw0rd");

            await userManager.AddToRoleAsync(
                testAdmin, Constants.AdminRole);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExistsAdmin = await roleManager
                 .RoleExistsAsync(Constants.AdminRole);

            var alreadyExistsMember = await roleManager
                .RoleExistsAsync(Constants.MemberRole);


            if (!alreadyExistsAdmin)
            {
                await roleManager.CreateAsync(
               new IdentityRole(Constants.AdminRole));
            }

            if (!alreadyExistsMember)
            {
                await roleManager.CreateAsync(
               new IdentityRole(Constants.MemberRole));
            }

            return;

           
        }
    }
}
