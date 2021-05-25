using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.Helper;
using E_Commerce_App.WebUI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.ViewModels.UserViewModel;

namespace E_Commerce_App.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(ICartService cartService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender)
        {
            _cartService = cartService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        // Pages
        //[Route("signin")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [Route("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null) return RedirectToAction("Index", "Home");
            var model = new ResetPasswordViewModel { Token = token };
            return View();
        }
        // Helper
        private async Task<bool> EmailExist(string email)
        {
            var resultUser = await _userManager.FindByEmailAsync(email);
            if (resultUser != null) return resultUser.Email != null ? true : false;
            return false;
        }
        // Helper
        private async Task SendVerificationEmail(User user, string email, string baseUrl)
        {
            //var siteUrl = "https://localhost:5001";
            //var html = $"lütfen email hesabınızı onaylamak için <a href='{siteUrl + baseUrl}'>linke</a> tıklayınız.";
            ////await _emailSender.SendEmailAsync(model.Email, "hesabınızı onaylayınız.", html);

            // generate token
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = Url.Action("ConfirmEmail", "Account", new
            {
                userId = user.Id,
                token = code
            });
            Console.Write(url);
            // email
            var siteUrl = "https://localhost:44373";
            var html = $"lütfen email hesabınızı onaylamak için <a href='{siteUrl + url}'>linke</a> tıklayınız.";
            await _emailSender.SendEmailAsync(user.Email, "hesabınızı onaylayınız.", html);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null) return Json(new { message = "Email adresi veya parola hatalı." });

                if (!await _userManager.IsEmailConfirmedAsync(user))
                    return Json(new { message = "Email adresinizi onaylamak için lütfen maillerinizi kontrol ediniz." });

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (result.Succeeded)
                {
                    ViewData["user"] = user.Id;
                    return Redirect(model.ReturnUrl ?? "~/");
                }

                else return Json(new { message = "Email adresi veya parola hatalı." });
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                //CreateMessage("geçersiz token", "geçersiz token", "danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    // cart objesini oluşturalım
                    await _cartService.InitializeCart(user.Id);
                    //CreateMessage("hesabınız onaylandı", "hesabınız onaylandı.", "success");
                    return View();
                }
            }
            //CreateMessage("böyle biri yok", "böyle biri yok", "warning");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // email exist control
                if (await EmailExist(model.Email)) return Json(new { message = "E-mail adresi ile zaten kayıt yapılmış." });

                var user = new User { FullName = model.FullName, Email = model.Email, UserName = model.FullName + "__" + DateTime.Now.ToString("dd-mm-HH-mm-ss-f") };
                var resultUser = await _userManager.CreateAsync(user, model.Password);


                // default user role adding
                await _userManager.AddToRoleAsync(user, "customer");
                if (resultUser.Succeeded)
                {
                    // generate token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var baseUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token });

                    // email operations
                    await SendVerificationEmail(user, user.Email, baseUrl);

                    return Json(new { message="Kullanıcı kaydı başarılı. Lütfen mail adresinizi doğrulayın."});
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email)) return View();

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return View();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // generate token
            var url = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token });

            // email 
            var siteUrl = "https://localhost:5001";
            var html = $"lütfen hesap şifrenizi değiştirmek için <a href='{siteUrl + url}'>linke</a> tıklayınız.";
            //await _emailSender.SendEmailAsync(Email, "Şifre Değiştirme.", html);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null) return RedirectToAction("Index", "Home");

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded) return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
    }
}
