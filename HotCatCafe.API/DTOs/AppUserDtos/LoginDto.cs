using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.API.DTOs.AppUserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email Boş Geçilemez")]
        [EmailAddress(ErrorMessage = "Email formatında bir değer girin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
