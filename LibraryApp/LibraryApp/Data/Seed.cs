using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Data
{
    public class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            //add custom roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //creating admin user

            var adminUser = new IdentityUser
            {
                UserName = configuration.GetSection("AppSettings")["UserEmail"],
                Email = configuration.GetSection("AppSettings")["UserEmail"]
            };

            string userPassword = configuration.GetSection("AppSettings")["UserPassword"];
            var createUser = await userManager.CreateAsync(adminUser, userPassword);

            if (createUser.Succeeded)
            {
                //assign "Admin" role
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
