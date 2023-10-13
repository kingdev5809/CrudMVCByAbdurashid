using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Check if the admin user exists
            var adminUser = await userManager.FindByNameAsync("admin");

            if (adminUser == null)
            {
                // Create the admin user if it doesn't exist
                var admin = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@example.com"
                };

                var result = await userManager.CreateAsync(admin, "YourPassword");
                if (result.Succeeded)
                {
    
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
