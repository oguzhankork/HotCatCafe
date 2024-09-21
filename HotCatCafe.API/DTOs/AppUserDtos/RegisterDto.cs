using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.API.DTOs.AppUserDtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Boş Geçilemez")]
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
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre (Tekrar) Boş Geçilemez")]
        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
