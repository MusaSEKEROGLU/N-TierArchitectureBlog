using System.ComponentModel.DataAnnotations;

namespace MyBlogSite.Models
{
    public class UserSignUpViewModel
    {
        [Required(ErrorMessage =("Lütfen Ad Soyad Giriniz."))]
        [Display(Name = "Ad Soyad")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = ("Lütfen Kullanıcı Adı Giriniz."))]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = ("Lütfen Email Giriniz."))]
        [Display(Name = "Email Adres")]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Lütfen Şifre Giriniz."))]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = ("Şifreler eşleşmiyor."))]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
