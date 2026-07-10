using EventHub_MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace EventHub_MVC.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                string[] roleNames = { "Admin", "User" };

                foreach (var roleName in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                string adminUsername = "admin_root";
                string adminEmail = "admin@eventhub.com";
                var defaultAdmin = await userManager.FindByNameAsync(adminUsername);

                if (defaultAdmin == null)
                {
                    defaultAdmin = await userManager.FindByEmailAsync(adminEmail);
                }

                if (defaultAdmin == null)
                {
                    var adminUser = new AppUser
                    {
                        UserName = adminUsername,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var createPowerUser = await userManager.CreateAsync(adminUser, "Admin@123");

                    if (createPowerUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
                else
                {
                    if (!await userManager.IsInRoleAsync(defaultAdmin, "Admin"))
                    {
                        await userManager.AddToRoleAsync(defaultAdmin, "Admin");
                    }
                }
            }
        }
    }
}