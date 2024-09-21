using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
