using HotCatCafe.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.AppUserViewModels
{
    public class AppUserViewModel
    {
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Email Onay")]
        public bool EmailConfirm { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Adres")]
        public string? Address { get; set; }
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
        [Display(Name = "Kullanıcı Rol")]
        public string UserRole { get; set; }
    }
}
