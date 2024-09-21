using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(Product product);
        IEnumerable<Product> GetAllProduct();
        List<Product> GetProductBySubCategoryId(int subCategoryId);

        IEnumerable<Product> GetActiveProducts();
        Product GetProductById(int productId);
        Task<string> UpdateProductAsync(Product product);

        IEnumerable<Product> GetMinStockProduct();
    }
}
