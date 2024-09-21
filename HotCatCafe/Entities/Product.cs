using HotCatCafe.Model.Base;

namespace HotCatCafe.Model.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
        public short? MinStockLevel { get; set; }
        public string? ImagePath { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
