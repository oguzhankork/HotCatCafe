using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.OrderDetailViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index(int orderId)
        {
           var result= _orderDetailService.GetOrderDetailByOrderId(orderId).Select(x=>new OrderDetailViewModel
           {
               OrderId= orderId,
               ProductName=x.ProductName,
               UnitPrice=x.UnitPrice,
               Quantity=x.Quantity,
           }).ToList();
            return View(result);
        }
    }
}
