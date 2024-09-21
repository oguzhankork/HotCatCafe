using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.AppUserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Boş Geçilemez")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email formatında bir değer girin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
