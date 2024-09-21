using HotCatCafe.BLL.ViewModels.SubCategoryViewModels;
using HotCatCafe.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotCatCafe.BLL.ViewModels.CategoryViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Kategori Id")]
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Kategori Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Kategori Aktiflik")]
        public bool IsActive { get; set; }
        [Display(Name = "Kategori Durum")]
        public DataStatus Status { get; set; }

        public List<SubCategoryViewModel>? SubCategories { get; set; }
    }
}
