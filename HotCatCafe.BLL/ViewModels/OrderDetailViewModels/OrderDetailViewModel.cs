using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.ViewModels.OrderDetailViewModels
{
    public class OrderDetailViewModel
    {
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
