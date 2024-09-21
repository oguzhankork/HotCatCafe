using HotCatCafe.BLL.ViewModels.AppUserViewModels;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HotCatCafe.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserRoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRole> _roleManager;

        public UserRoleController(UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            var userRolesViewModel = new List<AppUserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRolesViewModel.Add(new AppUserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    UserRole = string.Join(", ", roles)
                });
            }

            return View(userRolesViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AddToRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole.Count>0)
            {
                TempData["Error"] = "Kullanıcının Mevcut Bir Rolü Var. İkinci Bir Rol Eklenemez";
                return RedirectToAction("Index");
            }
            AppUserViewModel appUserVM = new AppUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
            ViewBag.SelectRole = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(appUserVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(AppUserViewModel appUserVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(appUserVM.Id.ToString());
                if (user==null)
                {
                    TempData["Error"] = "Kullanıcı Bulunamadı.";
                    return RedirectToAction("Index");
                }
                var role = await _roleManager.FindByIdAsync(appUserVM.UserRole);
                if (role.Name==null)
                {
                    TempData["Error"] = "Rol Bulunamadı.";
                    return RedirectToAction("Index");
                }
                var result = await _userManager.AddToRoleAsync(user, role.Name.ToUpper());
                if (result.Succeeded)
                {
                    TempData["Success"] = "Kullanıcıya Yeni Rol Eklendi.";
                    return RedirectToAction("Index");
                }                
            }
            TempData["Error"] = "Gönderilen Bilgilerde Hata Oluştu.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }
            var userRole = await _userManager.GetRolesAsync(user);
            AppUserViewModel appUserVM = new AppUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                UserRole = userRole.FirstOrDefault()?.ToUpper() ?? string.Empty
            };
            ViewBag.UserRoleListItem = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(appUserVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppUserViewModel appUserVM)
        {
            var user = await _userManager.FindByIdAsync(appUserVM.Id.ToString());
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı Bulunamadı";
                return RedirectToAction("Index");
            }

            // Kullanıcının mevcut rollerini alıyoruz
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles == null || !userRoles.Any())
            {
                TempData["Error"]=("", "Kullanıcı hiçbir role sahip değil. Güncellemek İçin Önce Rol Ataması Yapmanız Gerekmektedir.");
                return View(appUserVM);
            }
            var normalizedUserRoles = userRoles.Select(role => role.ToUpper()).ToList();

            var removeRoleResult = await _userManager.RemoveFromRolesAsync(user, normalizedUserRoles);
            if (!removeRoleResult.Succeeded)
            {
                TempData["Error"] = "Kullanıcı Rolü Güncellenirken Bir Hata Oluştu";
                return View(appUserVM);
            }
            var newRole = await _roleManager.FindByIdAsync(appUserVM.UserRole);
            if (newRole==null)
            {
                TempData["Error"] = "Yeni Rol Ataması Sırasında Bir Hata Oluştu";
                return View(appUserVM);
            }           

            var addRoleResult = await _userManager.AddToRoleAsync(user, newRole.Name.ToUpper());

            if (!addRoleResult.Succeeded)
            {
                TempData["Error"] = "Kullanıcı Rolü Güncellenirken Bir Hata Meydana Geldi";
                return View(appUserVM);
            }
            TempData["Success"] = $"'{appUserVM.UserName.ToUpper()}' Adlı Kullanıcının '{normalizedUserRoles[0]}' Rolü '{newRole.Name.ToUpper()}' Rolü ile Güncellendi";
            return RedirectToAction("Index");
        }
    }


}
