using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class UserViewModel
    {
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
