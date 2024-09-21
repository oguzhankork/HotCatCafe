using HotCatCafe.Model.Base;
using HotCatCafe.Model.Enums;

namespace HotCatCafe.Model.Entities
{
    public class Payment : BaseEntity
    {
        public decimal TotalPayment { get; set; }
        public PaymentType PaymentType { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
