using HotCatCafe.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Ürün ID")]
        public int ProductId { get; set; }
        [Display(Name = "Ürün Ad")]
        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Kategori")]
        [Required(ErrorMessage ="Kategori Alanı Seçilmedi")]
        public int SubCategoryId { get; set; }
        [Display(Name = "Alt Kategori")]
        public string? SubCategoryName { get; set; }
        [Display(Name = "Ürün Fiyat")]
        [Required(ErrorMessage = "Fiyat Alanı Boş Geçilemez")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Aktiflik")]
        public bool IsActive { get; set; }
        [Display(Name = "Ürün Stok")]
        [Required(ErrorMessage = "Stok Boş Geçilemez")]
        public short UnitInStock { get; set; }
        [Display(Name ="Minimum Ürün Stok")]
        public short? MinStockLevel {  get; set; }
        [Display(Name = "Ürün Görsel")]
        public string? ImagePath { get; set; }

        [Display(Name = "Ürün Durum")]
        public DataStatus Status { get; set; }
        public short Quantity { get; set; }

    }
}
