using HotCatCafe.Model.Base;

namespace HotCatCafe.Model.Entities
{
    public class TableSession : BaseEntity
    {
        public int TableId { get; set; }
        public Table Table { get; set; }
        public string SessionNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
