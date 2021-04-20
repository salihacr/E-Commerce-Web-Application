using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_App.WebUI.Identity
{
    public static class IdentitySeed
    {
        const string ROLE_ADMIN = "admin";
        const string ROLE_CUSTOMER = "customer";

        public static async Task Seed(IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync(ROLE_ADMIN) == null)
                await roleManager.CreateAsync(new IdentityRole(ROLE_ADMIN));
            if (await roleManager.FindByNameAsync(ROLE_CUSTOMER) == null)
                await roleManager.CreateAsync(new IdentityRole(ROLE_CUSTOMER));


            var username = configuration["Data:Admin:username"];
            var fullname = configuration["Data:Admin:fullname"];
            var email = configuration["Data:Admin:email"];
            var password = configuration["Data:Admin:password"];
            var role = configuration["Data:Admin:role"];

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new User { UserName = username, Email = email, FullName = fullname, EmailConfirmed = true };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, role);
            }


        }
    }
}
