using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.AppUserViewModels;
using HotCatCafe.BLL.ViewModels.TableViewModel;
using HotCatCafe.Common.EmailHelpers;
using HotCatCafe.Model.Entities;
using HotCatCafe.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace HotCatCafe.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITableService _tableService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITableService tableService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tableService = tableService;
        }

        public IActionResult Index()
        {
            var tableSelect = _tableService.GetAllTables().OrderBy(x => x.TableNumber).Select(x => new TableViewModel
            {
                TableId = x.ID,
                TableNumber = x.TableNumber,
                TableName = x.TableName                
            }).ToList();

            ViewBag.TableSelect = tableSelect;

            return View(tableSelect);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName,
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.ConfirmPassword);
                if (result.Succeeded)
                {
                    var emailToken = _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var enCodeToken = HttpUtility.UrlEncode(emailToken.Result);

                    string confirmationLink = Url.Action("Activation", "Home", new { id = user.Id, token = enCodeToken }, Request.Scheme);

                    string body = $"Merhaba {registerViewModel.UserName} HotCat Cafe'ye Kayýt Ýþleminizi Tamamlamak Ýçin Aþaðýdaki Linke Týklayýn. {confirmationLink}";

                    EmailSender.SendEmail(registerViewModel.Email, "Aktivasyon Maili", body);


                    TempData["Success"] = $"Belirlemiþ olduðunuz {registerViewModel.Email} adresine aktivasyon maili gönderilmiþtir. Linke týklayarak üyeliðinizi aktif ediniz.";
                }
                else
                {
                    TempData["Error"] = "Bir Hata Meydana Geldi";
                }
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Bir Hata Meydana Geldi";
                return View(registerViewModel);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.Remember, false);

                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Giriþ Yapýldý";
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            else
            {
                return View(loginViewModel);
            }

        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            TempData["Error"] = "Çýkýþ Yapýldý";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activation(string id, string token)
        {
            if (id != null && token != null)
            {
                var existUser = await _userManager.FindByIdAsync(id);
                if (existUser != null)
                {
                    var decodeToken = HttpUtility.UrlDecode(token);
                    var result = await _userManager.ConfirmEmailAsync(existUser, decodeToken);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Hesabýnýz aktif hale getirildi";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
