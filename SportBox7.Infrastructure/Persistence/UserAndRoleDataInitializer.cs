using Microsoft.AspNetCore.Identity;
using SportBox7.Application.Features.Editors;
using SportBox7.Domain.Factories.Editors;
using SportBox7.Infrastructure.Identity;

namespace SportBox7.Infrastructure.Persistence
{
    public static class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IEditorFactory editorFactory, IEditorRepository editorRepository)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, editorFactory, editorRepository);
        }

        private static void SeedUsers(UserManager<User> userManager, IEditorFactory editorFactory, IEditorRepository editorRepository)
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
                    var editor = editorFactory.WithFirstName("Lyubomir")
                        .WithLastName("Kavdansky")
                        .Build();
                    editorRepository.Save(editor).Wait();
                    user.BecomeEditor(editor);
                    userManager.UpdateAsync(user).Wait();
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
