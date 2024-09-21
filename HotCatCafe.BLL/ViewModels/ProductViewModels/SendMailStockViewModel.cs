using HotCatCafe.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.ProductViewModels
{
    public class SendMailStockViewModel
    {
        [Display(Name = "Ürün ID")]
        public int ProductId { get; set; }
        [Display(Name = "Ürün Ad")]        
        public string? ProductName { get; set; }
       
        public string? MailBody { get; set; }
        [Display(Name ="Satın Alma Personeli")]
        public string? PurchaseUserId { get; set; }
    }
}
