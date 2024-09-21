using HotCatCafe.API.DTOs.SubCategoryDtos;
using HotCatCafe.BLL.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var subCategory = _subCategoryService.GetSubCategoriesByCategoryId(id);
            if (subCategory != null)
            {
                var result = subCategory.Select(x => new SubCategoryDto
                {
                    Id = x.ID,
                    SubCategoryName = x.SubCategoryName,
                }).ToList();

                return Ok(result);
            }
            return BadRequest("Belirtilen Id ye Ait Alt Kategori Bulunamadı");
        }
    }
}
