using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class UserViewModel
    {
        public class UserAccountViewModel
        {
            [Required(ErrorMessage = "Lütfen adınız ve soyadınızı giriniz.")]
            [StringLength(maximumLength: 40, MinimumLength = 4, ErrorMessage = "Ad ve soyad 5 ile 40 karakter arasında olmalıdır.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            [StringLength(maximumLength:30,MinimumLength =8, ErrorMessage ="Parola 8 ile 30 karakter arasında olmalıdır.")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage ="Şifreler aynı değil.")]
            public string RePassword { get; set; }
        }
        public class RegisterViewModel
        {
            [Required(ErrorMessage = "Lütfen adınız ve soyadınızı giriniz.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
        public class LoginViewModel
        {
            [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public string ReturnUrl { get; set; }
        }
        public class ResetPasswordViewModel
        {
            [Required]
            public string Token { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
