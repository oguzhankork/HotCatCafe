using HotCatCafe.API.DTOs.ProductDtos;
using HotCatCafe.BLL.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductBySubCategoryId(id);
            if (product != null)
            {
                var result = product.Select(x => new ProductDto
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
                return Ok(result);
            }
            else
            {
                return BadRequest("Belirtilen Id ye Göre Ürün Bulunamadı");
            }
        }
    }
}
