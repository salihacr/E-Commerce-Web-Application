using E_Commerce_App.WebUI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.ViewModels.UserViewModel;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminDashboardController : Controller
    {

        private readonly UserManager<User> _userManager;

        public AdminDashboardController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Route("Admin/Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Admin/Profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new UserAccountViewModel() { FullName = user.FullName, Email = user.Email };
            return View(model);
        }

        [Route("Admin/ProfileEdit")]
        [HttpPost]
        public async Task<IActionResult> ProfileEdit(UserAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.Email = model.Email;
                user.FullName = model.FullName;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
                await _userManager.UpdateAsync(user);
                return Json(new { message = "Profil başarıyla güncellendi." });
            }
            return Redirect(nameof(Profile));
        }

    }
}
