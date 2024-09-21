using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.AppUserViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Boş Geçilemez")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email formatında bir değer girin")]
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                var userArray = value.Split("@");
                UserName = userArray[0];
                _email = value;
            }
        }
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre (Tekrar) Boş Geçilemez")]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
