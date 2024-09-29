using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.ProductViewModels;
using HotCatCafe.BLL.ViewModels.SubCategoryViewModels;
using HotCatCafe.Common.ImageHelpers;
using HotCatCafe.Common.ProductHelper;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotCatCafe.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]    
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProductController(IProductService productService, ISubCategoryService subCategoryService, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _productService = productService;
            _subCategoryService = subCategoryService;
            _userManager = userManager;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var product = _productService.GetAllProduct().OrderBy(x => x.UnitInStock).Select(x => new ProductViewModel
            {
                ProductId = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitInStock = x.UnitInStock,
                MinStockLevel = x.MinStockLevel,
                SubCategoryId = x.SubCategoryId,
                Status = x.Status,
                ImagePath = x.ImagePath,
            }).ToList();
            return View(product);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.SubCategoryListItem = _subCategoryService.GetAllSubCategories().Select(x => new SubCategoryViewModel
            {
                SubCategoryName = x.SubCategoryName,
                Id = x.ID

            }).Select(s => new SelectListItem
            {
                Text = s.SubCategoryName,
                Value = s.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel, IFormFile? ImagePath)
        {
            if (ModelState.IsValid)
            {
                if (ImagePath == null)
                {
                    Product product = new Product
                    {
                        ID = productViewModel.ProductId,
                        ProductName = productViewModel.ProductName,
                        UnitPrice = productViewModel.UnitPrice,
                        UnitInStock = productViewModel.UnitInStock,
                        MinStockLevel = productViewModel.MinStockLevel,
                        SubCategoryId = productViewModel.SubCategoryId,
                        Status = productViewModel.Status,
                    };
                    var result = await _productService.CreateProductAsync(product);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    var imageResult = ImageHelper.Upload(ImagePath.FileName);
                    if (imageResult == "0")
                    {
                        TempData["Error"] = "Görsel izin verilen formatta değil";
                        return RedirectToAction("Index","Product");
                    }
                    else
                    {
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\productImages", imageResult);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                           await ImagePath.CopyToAsync(stream);
                        }

                        Product product = new Product
                        {
                            ID = productViewModel.ProductId,
                            ProductName = productViewModel.ProductName,
                            UnitPrice = productViewModel.UnitPrice,
                            UnitInStock = productViewModel.UnitInStock,
                            MinStockLevel = productViewModel.MinStockLevel,
                            SubCategoryId = productViewModel.SubCategoryId,
                            Status = productViewModel.Status,
                            ImagePath = imageResult
                        };
                        var result = await _productService.CreateProductAsync(product);
                        return RedirectToAction("Index", "Product");
                    }
                }

            }
            else
            {
                return View(productViewModel);
            }
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.SubCategoryListItem = _subCategoryService.GetAllSubCategories().Select(x => new SubCategoryViewModel
            {
                SubCategoryName = x.SubCategoryName,
                Id = x.ID
            }).Select(s => new SelectListItem
            {
                Text = s.SubCategoryName,
                Value = s.Id.ToString()
            });
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                ProductViewModel productVM = new ProductViewModel
                {
                    ProductId = product.ID,
                    ProductName = product.ProductName,
                    SubCategoryId = product.SubCategoryId,
                    ImagePath = product.ImagePath,
                    UnitPrice = product.UnitPrice,
                    UnitInStock = product.UnitInStock,
                    MinStockLevel = product.MinStockLevel,
                    IsActive = product.IsActive,
                    Status = product.Status
                };
                if (productVM != null)
                {
                    return View(productVM);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ID = productVM.ProductId,
                    ProductName = productVM.ProductName,
                    SubCategoryId = productVM.SubCategoryId,
                    ImagePath = productVM.ImagePath,
                    UnitPrice = productVM.UnitPrice,
                    UnitInStock = productVM.UnitInStock,
                    MinStockLevel = productVM.MinStockLevel,
                    IsActive = productVM.IsActive,
                    Status = productVM.Status
                };
                await _productService.UpdateProductAsync(product);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(productVM);
            }
        }
        public IActionResult GetDetailProduct(int id)
        {
            var product = _productService.GetProductBySubCategoryId(id);
            if (product != null)
            {
                var productSubCategory = product.Select(x => new ProductViewModel
                {
                    ProductId = x.ID,
                    ProductName = x.ProductName,
                    SubCategoryId = x.SubCategoryId,
                    Status = x.Status,
                    UnitPrice = x.UnitPrice,
                    UnitInStock = x.UnitInStock,
                    IsActive = x.IsActive,
                    ImagePath = x.ImagePath

                }).ToList();
                return View(productSubCategory);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> SendMailStock()
        {
            ViewBag.ProductListItem = _productService.GetMinStockProduct().Select(x => new SendMailStockViewModel
            {
                ProductId = x.ID,
                ProductName = x.ProductName              
            }).Select(s => new SelectListItem
            {
                Text = s.ProductName,
                Value = s.ProductId.ToString()
            });

            var user = await _userManager.GetUsersInRoleAsync("Purchase");
            ViewBag.PurchaseList = user.Select(x => new AppUser { Id = x.Id, UserName = x.UserName }).Select(x => new SelectListItem
            {
                Text = x.UserName,
                Value = x.Id.ToString(),
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMailStock(SendMailStockViewModel sendMailStockVM)
        {
            if (ModelState.IsValid)
            {
              var product= _productService.GetProductById(sendMailStockVM.ProductId);

                var purchaseEmployee =await _userManager.FindByIdAsync(sendMailStockVM.PurchaseUserId);

                if (purchaseEmployee != null)
                {
                    string mailBody = $"Sayın {purchaseEmployee.UserName}.\n\n\n{product.ProductName} ürünü ile alakalı" +" "+ sendMailStockVM.MailBody;

                    ProductOrderMail.SendEmailToPurchase(purchaseEmployee.Email, mailBody);

                    TempData["Success"] = "Ürün Talebi İlgili Departmana İletildi";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Satın Alma Personeli Maili Bulunamadı.";
                    return View(sendMailStockVM);
                }                
            }
            else
            {
                return View(sendMailStockVM);
            }
        }
    }
}
