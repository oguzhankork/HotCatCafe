using HotCatCafe.Model.Base;

namespace HotCatCafe.Model.Entities
{
    public class Order:BaseEntity
    {
        public string OrderNumber { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public int TableSessionId { get; set; }
        public TableSession TableSession { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public bool PaymentControl { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
