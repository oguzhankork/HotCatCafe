using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.CategoryViewModels;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var category = _categoryService.GetAllCategories().Select(x=>new CategoryViewModel
            {
                Id=x.ID,
                CategoryName=x.CategoryName,
                Description=x.Description,
                Status=x.Status,
                IsActive=x.IsActive,
            }).ToList();
            if (category != null)
            {
                return View(category);
            }
            return View("Index","Home");
            
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    CategoryName = categoryViewModel.CategoryName,
                    Description = categoryViewModel.Description,
                };
                await _categoryService.CreateCategory(category);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category=_categoryService.GetCategoryById(id);
            if (category != null)
            {
                CategoryViewModel categoryVM = new CategoryViewModel
                {
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    IsActive= category.IsActive,
                    Status= category.Status
                };
                return View(categoryVM);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    ID=categoryVM.Id,
                    CategoryName = categoryVM.CategoryName,
                    Description = categoryVM.Description,
                    IsActive = categoryVM.IsActive,
                    Status = categoryVM.Status
                };
                await _categoryService.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryVM);
            }
        }
       



    }
}
