using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.CreditCardViewModels
{
    public class CreditCardViewModel
    {
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "İsim Alanı boş Geçilemez")]
        public string FirstName { get; set; }
        [Display(Name = "Soy İsim")]
        [Required(ErrorMessage = "Soy İsim Alanı boş Geçilemez")]
        public string LastName { get; set; }
        [Display(Name = "Kart Numarası")]
        [Required(ErrorMessage = "Kart Numarası boş Geçilemez")]
        public string CardNumber { get; set; }
        [Display(Name = "Son Kullanma Tarihi")]
        [Required(ErrorMessage = "Son Kullanım Tarihi Alanı boş Geçilemez")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Geçerli bir Son Kullanma Tarihi giriniz (MM/YY).")]
        public string EndTime { get; set; }
        [Display(Name = "Cvv Numarası")]
        [Required(ErrorMessage = "Cvv Alanı Boş Geçilemez")]
        public string CvvNo { get; set; }
        public decimal SubTotal { get; set; }
    }
}
