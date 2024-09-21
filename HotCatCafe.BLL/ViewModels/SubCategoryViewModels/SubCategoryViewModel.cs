using HotCatCafe.BLL.ViewModels.CategoryViewModels;
using HotCatCafe.BLL.ViewModels.ProductViewModels;
using HotCatCafe.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.SubCategoryViewModels
{
    public class SubCategoryViewModel
    {
        [Display(Name = "Alt Kategori Id")]
        public int Id { get; set; }
        [Display(Name = "Alt Kategori Adı")]
        public string SubCategoryName { get; set; }
        [Display(Name = "Üst Kategori Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Üst Kategori Adı")]
        public string? CategoryName { get; set; }

        [Display(Name = "Alt Kategori Aktiflik")]
        public bool IsActive { get; set; }
        [Display(Name = "Alt Kategori Durum")]
        public DataStatus Status { get; set; }
        public List<ProductViewModel>? Products { get; set; }
        public List<CategoryViewModel>? CategoryViewModels { get; set; }
    }
}
