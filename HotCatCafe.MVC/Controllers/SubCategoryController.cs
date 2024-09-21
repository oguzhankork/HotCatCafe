using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.SubCategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }
        public IActionResult Index(int id,int tableId)
        {
            ViewBag.TableId = tableId;
            var subCategory = _subCategoryService.GetSubCategoriesByCategoryId(id);
            if (subCategory != null)
            {
                var result = subCategory.Select(x => new SubCategoryViewModel
                {
                    Id = x.ID,
                    SubCategoryName = x.SubCategoryName,
                }).ToList();

                return View(result);
            }
            return RedirectToAction("Index");
        }
    }
}
