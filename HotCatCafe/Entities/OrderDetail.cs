using HotCatCafe.Model.Base;

namespace HotCatCafe.Model.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int TableSessionId { get; set; }
        public TableSession TableSession { get; set; }
    }
}
