using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.CategoryViewModels;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public CategoryController(ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _categoryService = categoryService;
            _userManager = userManager;
        }
        public IActionResult Index(int tableId)
        {
            if (_userManager.GetUserId(HttpContext.User) == null)
            {
                TempData["Error"] = "Lütfen Giriş Yapın";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TableId = tableId;
            var category = _categoryService.GetAllCategories().Select(x => new CategoryViewModel
            {
                Id = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description,
            }).ToList();
            return View(category);
        }
    }
}
