using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.API.DTOs.CreditCardDtos
{
    public class CreditCardDto
    {
        [Required(ErrorMessage = "İsim Alanı boş Geçilemez")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soy İsim Alanı boş Geçilemez")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Kart Numarası boş Geçilemez")]
        public string CardNumber { get; set; }
        // [RegularExpression] ifadesi, bir kredi kartının son kullanım tarihini belirli bir formatta (MM/YY) doğrulamak için kullanılan doğrulamadır.
        [Required(ErrorMessage = "Son Kullanım Tarihi Alanı boş Geçilemez")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Geçerli bir Son Kullanma Tarihi giriniz (MM/YY).")]
        public string EndTime { get; set; }
        [Required(ErrorMessage = "Cvv Alanı Boş Geçilemez")]
        public string CvvNo { get; set; }
        public decimal SubTotal { get; set; }
        
    }
}
