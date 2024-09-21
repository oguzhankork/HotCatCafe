using HotCatCafe.API.DTOs.AppUserDtos;
using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.TableViewModel;
using HotCatCafe.Common.EmailHelpers;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace HotCatCafe.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITableService _tableService;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, ITableService tableService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tableService = tableService;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var tableSelect = _tableService.GetAllTables().OrderBy(x => x.TableNumber).Select(x => new TableViewModel
            {
                TableId = x.ID,
                TableNumber = x.TableNumber,
                TableName = x.TableName
            }).ToList();

            return Ok(tableSelect);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,
                };
                var result = await _userManager.CreateAsync(user, registerDto.ConfirmPassword);
                if (result.Succeeded)
                {
                    var emailToken = _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var enCodeToken = HttpUtility.UrlEncode(emailToken.Result);

                    string confirmationLink = Url.Action("Activation", "Home", new { id = user.Id, token = enCodeToken }, Request.Scheme);

                    string body = $"Merhaba {registerDto.UserName} HotCat Cafe'ye Kayıt İşleminizi Tamamlamak İçin Aşağıdaki Linke Tıklayın. {confirmationLink}";

                    EmailSender.SendEmail(registerDto.Email, "Aktivasyon Maili", body);


                    return Ok($"Belirlemiş olduğunuz {registerDto.Email} adresine aktivasyon maili gönderilmiştir. Linke tıklayarak üyeliğinizi aktif ediniz. {confirmationLink}");
                }
                else
                {
                    BadRequest("Bir Hata Meydana Geldi");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest("Modelde Bir Sorun Meydana Geldi");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.Remember, false);

                    if (result.Succeeded)
                    {
                        return Ok($"{loginDto.Email}  Giriş Yaptı");
                    }
                }
                else
                {
                    return BadRequest("Kullanıcı Bulunamadı");
                }
            }
            return BadRequest("Kullanıcı Bilgilerinde Hata Oluştu");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            else
            {
                return BadRequest("Açık Oturum Bulunamadı");
            }
            return Ok("Çıkış Yapıldı");
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
                        return Ok("Hesabınız aktif hale getirildi");
                    }
                }
            }
            return BadRequest("ID veya Token Alanı Hatalı");
        }
    }
}
