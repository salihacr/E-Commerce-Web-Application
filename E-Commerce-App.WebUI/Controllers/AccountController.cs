using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
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
        [Route("my-profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new UserAccountViewModel() { FullName = user.FullName, Email = user.Email, NewPassword = "", RePassword = "" };
            return View(model);
        }
        public async Task<IActionResult> ProfileEdit(UserAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if ((model.Email.Equals(user.Email) && model.FullName.Equals(user.FullName))
                    && string.IsNullOrEmpty(model.NewPassword))
                {
                    return Redirect("/my-profile");
                }

                user.Email = model.Email;
                user.FullName = model.FullName;
                if (!string.IsNullOrEmpty(model.NewPassword))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.NewPassword);
                }
                await _userManager.UpdateAsync(user);
                return Json(new { success = true, message = "Profil bilgileri başarıyla güncellendi." });
            }
            return Redirect(nameof(Profile));
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
            var html2 = $"lütfen email hesabınızı onaylamak için <a href='{siteUrl + url}'>linke</a> tıklayınız.";
            var emailUrl = siteUrl + url;
            var html = Messages.EMAIL_CONFIRM_HTML(user.FullName, emailUrl);
            await _emailSender.SendEmailAsync(user.Email, "Kullanıcı Hesap Doğrulama", html);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // ürün düzenlede ürünün aktifliği değişiyor onu hidden olarak ekle
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null) return Json(new { message = "Email adresi veya parola hatalı.", errorType = 1 });

                if (!await _userManager.IsEmailConfirmedAsync(user))
                    return Json(new { message = "Email adresinizi onaylamak için lütfen maillerinizi kontrol ediniz.", errorType = 2 });

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (result.Succeeded)
                {
                    ViewData["user"] = user.Id;
                    return Json(new { success = true, redirectUrl = "/" });// Redirect(model.ReturnUrl ?? "~/");
                }

                else return Json(new { message = "Email adresi veya parola hatalı.", errorType = 1 });
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
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
                    //return Json(new { success=true, redirectUrl="/account/login", message="Kullanıcı kaydınız tamamlandı. Giriş yapabilirsiniz." });
                    return RedirectToAction(nameof(Login));
                }
            }
            return Json(new { message = "Böyle bir kullanıcı bulunamadı." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // email exist control
                if (await EmailExist(model.Email)) return Json(new { message = "E-mail adresi ile zaten kayıt yapılmış.", errorType = 3 });

                var user = new User { FullName = model.FullName, Email = model.Email, UserName = model.Email };
                var resultUser = await _userManager.CreateAsync(user, model.Password);


                // default user role adding
                await _userManager.AddToRoleAsync(user, "customer");
                if (resultUser.Succeeded)
                {
                    try
                    {
                        // generate token
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var baseUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token });

                        // email operations
                        await SendVerificationEmail(user, user.Email, baseUrl);
                        return Json(new { success = true, redirectUrl = "/account/login", message = "Kullanıcı kaydı başarılı. Lütfen mail adresinizi doğrulayın." });
                    }
                    catch (Exception)
                    {
                        await _userManager.DeleteAsync(user);
                        return Json(new { success = false, redirectUrl = "/account/register", message = "Kullanıcı kaydında hata yaşandı. Lütfen daha sonra tekrar deneyiniz." });
                    }
                }
                else if (!resultUser.Succeeded)
                {
                    return Json(new { message = "Parola en az, 6 karakter, 1 büyük harf, 1 sayısal ifade ve 1 noktalama işareti içermelidir.", success = false });
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
