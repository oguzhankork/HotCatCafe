using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface ISubCategoryService
    {
        //Tüm Alt Kategoriler
        IEnumerable<SubCategory> GetAllSubCategories();
        //Kategori ID sine göre alt kategoriler
        List<SubCategory> GetSubCategoriesByCategoryId(int categoryId);

        //ID ye göre Alt Kategori Getirme
        SubCategory GetSubCategoryById(int id);
        //Alt Kategori Oluşturma
        Task<string> CreateSubCategoryAsync(SubCategory subCategory);
        //Alt Kategori Silme
        Task<string> DeleteSubCategory(SubCategory subCategory);
        //Alt Kategori Güncelleme
        Task<string> UpdateSubCategoryAsync(SubCategory subCategory);
        //Aktif Alt Kategorileri Getirme
        IEnumerable<SubCategory> GetActiveSubCategories();
        //Pasif Alt Kategorileri Getirme
        IEnumerable<SubCategory> GetPassiveSubCategories();
        //Alt Kategori Yok Etme
        Task<string> DestroySubCategory(SubCategory subCategory);
    }
}
