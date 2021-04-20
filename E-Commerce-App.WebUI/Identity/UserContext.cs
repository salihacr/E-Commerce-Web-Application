using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.WebUI.Identity
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }
    }
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Photo { get; set; }
    }
}
