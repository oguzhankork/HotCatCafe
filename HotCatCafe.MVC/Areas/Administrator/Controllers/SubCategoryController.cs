using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.CategoryViewModels;
using HotCatCafe.BLL.ViewModels.SubCategoryViewModels;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotCatCafe.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int id)
        {
            var result = _subCategoryService.GetSubCategoriesByCategoryId(id);
            if (result != null)
            {
                var subCategories = result.Select(x => new SubCategoryViewModel
                {
                    Id = x.ID,
                    SubCategoryName = x.SubCategoryName,
                    CategoryId = x.CategoryId,
                    IsActive = x.IsActive,
                    Status = x.Status
                }).ToList();
                return View(subCategories);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryListItem = _categoryService.GetAllCategories().Select(x => new CategoryViewModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.ID
            }).Select(s => new SelectListItem
            {
                Text = s.CategoryName,
                Value = s.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryViewModel subCategoryVM)
        {
            if (ModelState.IsValid)
            {
                var subCategory = new SubCategory
                {
                    ID = subCategoryVM.Id,
                    SubCategoryName = subCategoryVM.SubCategoryName,
                    CategoryId = subCategoryVM.CategoryId,
                    Status = subCategoryVM.Status
                };
                await _subCategoryService.CreateSubCategoryAsync(subCategory);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(subCategoryVM);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.CategoryListItem = _categoryService.GetAllCategories().Select(x => new CategoryViewModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.ID
            }).Select(s => new SelectListItem
            {
                Text = s.CategoryName,
                Value = s.Id.ToString()
            });
            var subCategory = _subCategoryService.GetSubCategoryById(id);
            SubCategoryViewModel categoryViewModel = new SubCategoryViewModel
            {
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                IsActive = subCategory.IsActive,
                Status = subCategory.Status
            };
            if (subCategory != null)
            {
                return View(categoryViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(SubCategoryViewModel subCategoryVM)
        {
            if (ModelState.IsValid)
            {
                SubCategory subCategory = new SubCategory
                {
                    ID = subCategoryVM.Id,
                    SubCategoryName = subCategoryVM.SubCategoryName,
                    CategoryId = subCategoryVM.CategoryId,
                    Status = subCategoryVM.Status,
                    IsActive = subCategoryVM.IsActive
                };
                var result = await _subCategoryService.UpdateSubCategoryAsync(subCategory);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View("Index", "Category");
            }
        }
        public IActionResult GetDetail(int id)
        {
            var subCategory = _subCategoryService.GetSubCategoriesByCategoryId(id);
            if (subCategory != null)
            {
                var selectedSubCategory = subCategory.Select(x => new SubCategoryViewModel
                {
                    Id = x.ID,
                    SubCategoryName = x.SubCategoryName,
                    CategoryId = x.CategoryId,
                    IsActive = x.IsActive,
                    Status = x.Status
                }).ToList();
                return View(selectedSubCategory);
            }
            return RedirectToAction("Index");
        }
    }
}
