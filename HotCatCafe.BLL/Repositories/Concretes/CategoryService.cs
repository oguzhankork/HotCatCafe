using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<string> CreateCategory(Category category)
        {
            return await _categoryRepository.Create(category);
        }

        public async Task<string> DeleteCategory(Category category)
        {
            return await _categoryRepository.Delete(category);
        }

        public async Task<string> DestroyCategory(Category category)
        {
            return await _categoryRepository.DestroyData(category);
        }

        public IEnumerable<Category> GetActiveCategories()
        {
            return _categoryRepository.GetActives();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetByID(id);
        }

        public IEnumerable<Category> GetPassiveCategories()
        {
            return _categoryRepository.GetPassives();
        }

        public async Task<string> UpdateCategory(Category category)
        {
            return await _categoryRepository.Update(category);
        }
    }
}
