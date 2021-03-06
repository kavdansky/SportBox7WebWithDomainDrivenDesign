﻿using Microsoft.AspNetCore.Identity;
using SportBox7.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Infrastructure.Persistence
{
    public static class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("johndoe@localhost").Result == null)
            {
                User user = new User("johndoe@localhost")
                {
                    UserName = "johndoe"
                };


                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Editor").Wait();
                }
            }


            if (userManager.FindByEmailAsync("kavdansky@mail.bg").Result == null)
            {
                User user = new User("kavdansky@mail.bg")
                {
                    UserName = "kavdansky"
                };


                IdentityResult result = userManager.CreateAsync(user, "Kavdansky21").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Editor").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Editor"
                };
                _ = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                _ = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
