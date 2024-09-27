using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.ViewModels.TableViewModel
{
    public class TableViewModel
    {
        public int TableId { get; set; }
        public string TableNumber { get; set; }
        public string TableName { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public bool IsLocked { get; set; }
    }
}
