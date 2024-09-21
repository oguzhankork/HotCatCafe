namespace HotCatCafe.API.DTOs.OrderDetailDtos
{
    public class OrderDetailDto
    {
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
