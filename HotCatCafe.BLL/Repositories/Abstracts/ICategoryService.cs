using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();

        Category GetCategoryById(int id);

        Task<string> CreateCategory(Category category);
        Task<string> DeleteCategory(Category category);
        Task<string> UpdateCategory(Category category);
        IEnumerable<Category> GetActiveCategories();
        IEnumerable<Category> GetPassiveCategories();
        Task<string> DestroyCategory(Category category);
    }
}
