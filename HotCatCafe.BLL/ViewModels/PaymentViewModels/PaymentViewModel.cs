using HotCatCafe.Model.Entities;
using HotCatCafe.Model.Enums;

namespace HotCatCafe.BLL.ViewModels.PaymentViewModels
{
    public class PaymentViewModel
    {
        public decimal TotalPayment { get; set; }
        public PaymentType PaymentType { get; set; }
        public int OrderId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
