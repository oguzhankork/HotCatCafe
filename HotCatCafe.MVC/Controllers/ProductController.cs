using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id, int tableId)
        {
            ViewBag.TableId = tableId;
            var product=_productService.GetProductBySubCategoryId(id);
            if (product != null)
            {
                var result = product.Select(x => new ProductViewModel
                {
                    ProductId = x.ID,
                    ProductName = x.ProductName,
                    SubCategoryId = x.SubCategoryId,
                    UnitPrice = x.UnitPrice,
                    UnitInStock = x.UnitInStock,
                    ImagePath = x.ImagePath,
                    Status = x.Status,
                    IsActive = x.IsActive,
                }).ToList();
                return View(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
