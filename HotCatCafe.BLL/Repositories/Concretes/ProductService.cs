using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<string> CreateProductAsync(Product product)
        {
            return await _productRepository.Create(product);
        }

        public IEnumerable<Product> GetActiveProducts()
        {
            return _productRepository.GetActives().Where(x => x.IsActive == true).ToList();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetMinStockProduct()
        {
            return _productRepository.GetAll().Where(x => x.UnitInStock < x.MinStockLevel||x.UnitInStock<x.MinStockLevel+10).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetByID(productId);
        }

        public List<Product> GetProductBySubCategoryId(int subCategoryId)
        {
            return _productRepository.GetAll().Where(x => x.SubCategoryId == subCategoryId).ToList();
        }

        public async Task<string> UpdateProductAsync(Product product)
        {
           return await _productRepository.Update(product);
        }
    }
}
