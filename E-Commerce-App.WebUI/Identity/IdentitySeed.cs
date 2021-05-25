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
            /* Roles */
            if (await roleManager.FindByNameAsync(ROLE_ADMIN) == null)
                await roleManager.CreateAsync(new IdentityRole(ROLE_ADMIN));
            if (await roleManager.FindByNameAsync(ROLE_CUSTOMER) == null)
                await roleManager.CreateAsync(new IdentityRole(ROLE_CUSTOMER));

            // admin
            var a_username = configuration["Data:Admin:username"];
            var a_fullname = configuration["Data:Admin:fullname"];
            var a_email = configuration["Data:Admin:email"];
            var a_password = configuration["Data:Admin:password"];
            var a_role = configuration["Data:Admin:role"];

            await CreateUser(new UserStruct(a_username, a_fullname, a_email, a_password, a_role), userManager, roleManager);

            // user
            var u_username = configuration["Data:User:username"];
            var u_fullname = configuration["Data:User:fullname"];
            var u_email = configuration["Data:User:email"];
            var u_password = configuration["Data:User:password"];
            var u_role = configuration["Data:User:role"];

            await CreateUser(new UserStruct(u_username, u_fullname, u_email, u_password, u_role), userManager, roleManager);
        }
        public static async Task CreateUser(UserStruct userStruct, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await userManager.FindByEmailAsync(userStruct.email) == null)
            {
                var user = new User { UserName = userStruct.username, Email = userStruct.email, FullName = userStruct.fullname, EmailConfirmed = true };

                var result = await userManager.CreateAsync(user, userStruct.password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, userStruct.role);
            }
        }
    }
    public struct UserStruct
    {
        public UserStruct(string username, string fullname, string email, string password, string role)
        {
            this.username = username;
            this.fullname = fullname;
            this.email = email;
            this.password = password;
            this.role = role;
        }

        public string username { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }

    }

}
