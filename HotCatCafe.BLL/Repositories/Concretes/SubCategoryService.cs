using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IRepository<SubCategory> _subCategoryRepository;

        public SubCategoryService(IRepository<SubCategory> subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<string> CreateSubCategoryAsync(SubCategory subCategory)
        {
            return  await _subCategoryRepository.Create(subCategory);
        }

        public async Task<string> DeleteSubCategory(SubCategory subCategory)
        {
            return await _subCategoryRepository.Delete(subCategory);
        }

        public async Task<string> DestroySubCategory(SubCategory subCategory)
        {
            return await _subCategoryRepository.DestroyData(subCategory);
        }

        public IEnumerable<SubCategory> GetActiveSubCategories()
        {
            return _subCategoryRepository.GetActives();
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            return _subCategoryRepository.GetAll();
        }

        public IEnumerable<SubCategory> GetPassiveSubCategories()
        {
            return _subCategoryRepository.GetPassives();
        }

        public List<SubCategory> GetSubCategoriesByCategoryId(int categoryId)
        {
            return _subCategoryRepository.GetAll().Where(x => x.CategoryId == categoryId).ToList();
        }

        public SubCategory GetSubCategoryById(int id)
        {
            return _subCategoryRepository.GetByID(id);
        }

        public async Task<string> UpdateSubCategoryAsync(SubCategory subCategory)
        {
            return await _subCategoryRepository.Update(subCategory);
        }
    }
}
