using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var result = _orderService.GetAllOrders().OrderByDescending(x=>x.CreatedDate).Select(x=>new OrderViewModel
            {
                OrderId=x.ID,
                OrderNumber=x.OrderNumber,
                TableId=x.TableId,
                UserId=x.UserId,   
                CreatedDate=x.CreatedDate,
            }).ToList();
            
            if (result != null)
            {
                return View(result);
            }
            return View();
        }
    }
}
