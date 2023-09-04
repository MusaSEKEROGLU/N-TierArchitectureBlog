using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace MyBlogSite.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = ("Lütfen Kullanıcı Adı Giriniz."))]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = ("Lütfen Şifre Giriniz."))]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
