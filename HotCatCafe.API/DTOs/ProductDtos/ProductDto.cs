using HotCatCafe.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.API.DTOs.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Kategori Alanı Seçilmedi")]
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        [Required(ErrorMessage = "Fiyat Alanı Boş Geçilemez")]
        public decimal UnitPrice { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Stok Boş Geçilemez")]
        public short UnitInStock { get; set; }
        public short? MinStockLevel { get; set; }
        public string? ImagePath { get; set; }
        public DataStatus Status { get; set; }
        public short Quantity { get; set; }
    }
}
