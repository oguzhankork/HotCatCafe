using HotCatCafe.API.DTOs.CategoryDtos;
using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.CategoryViewModels;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        public CategoryController(ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (_userManager.GetUserId(HttpContext.User) == null)
            {
                return BadRequest("Lütfen Giriş Yapın");
            }
            var category = _categoryService.GetAllCategories().Select(x => new CategoryDto
            {
                Id = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description,
            }).ToList();
            return Ok(category);
        }
    }
}
