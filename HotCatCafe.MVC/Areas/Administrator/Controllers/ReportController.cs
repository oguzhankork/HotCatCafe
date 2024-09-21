using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.OrderDetailViewModels;
using HotCatCafe.BLL.ViewModels.PaymentViewModels;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ReportController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IPaymentService _paymentService;

        public ReportController(IOrderDetailService orderDetailService, IPaymentService paymentService)
        {
            _orderDetailService = orderDetailService;
            _paymentService = paymentService;
        }
        public IActionResult Index(string sortOrderDetail)
        {
            var orderDetail = _orderDetailService.GetOrderDetails().Select(x => new OrderDetailViewModel
            {
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                OrderId = x.OrderId,
                Quantity = x.Quantity,
                ProductId = x.ProductId,
                CreatedTime = x.CreatedDate
            }).ToList();
            switch (sortOrderDetail)
            {
                case "date_desc":
                    orderDetail = orderDetail.OrderByDescending(o => o.CreatedTime).ToList();
                    break;
                case "name_asc":
                    orderDetail = orderDetail.OrderBy(o => o.ProductName).ToList();
                    break;
                case "name_desc":
                    orderDetail = orderDetail.OrderByDescending(o => o.ProductName).ToList();
                    break;
                case "quantity_asc":
                    orderDetail = orderDetail.OrderBy(o => o.Quantity).ToList();
                    break;
                case "quantity_desc":
                    orderDetail = orderDetail.OrderByDescending(o => o.Quantity).ToList();
                    break;
                default:
                    orderDetail = orderDetail.OrderBy(o => o.UnitPrice).ToList();
                    break;
            }
            return View(orderDetail);
        }
        [HttpPost]
        public IActionResult GetOrderDetailByDate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                TempData["Error"] = "Başlangıç tarihi bitiş tarihinden büyük olamaz.";
                return RedirectToAction("Index");
            }

            var orderDetail = _orderDetailService.GetOrderDetailsByDate(startDate, endDate).Select(x => new OrderDetailViewModel
            {
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                OrderId = x.OrderId,
                Quantity = x.Quantity,
                CreatedTime = x.CreatedDate

            }).ToList();


            if (orderDetail == null)
            {
                TempData["Error"] = "Belirtilen tarih aralığında sipariş bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(orderDetail);
        }

        public IActionResult GetOrderDetailByBestSeller()
        {
            var bestSeller = _orderDetailService.GetOrderDetailByBestSeller().Select(x => new OrderDetailViewModel
            {
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                CreatedTime = x.CreatedDate
            }).ToList();

            return View(bestSeller);
        }
        public IActionResult GetOrderDetailByLeastSoldProduct()
        {
            var bestSeller = _orderDetailService.GetOrderDetailByLessSeller().Select(x => new OrderDetailViewModel
            {
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                CreatedTime = x.CreatedDate
            }).ToList();

            return View(bestSeller);
        }

        public IActionResult GetAllPayment(DateTime? startDate, DateTime? endDate)
        {
            if (startDate!=null&&endDate!=null)
            {
                if (startDate==null)
                {
                    TempData["Error"] = "Başlangıç tarihi boş olamaz.";
                    return View();
                }
                if (endDate == null)
                {
                    TempData["Error"] = "Bitiş tarihi boş olamaz.";
                    return View();
                }
                if (startDate > endDate)
                {
                    TempData["Error"] = "Başlangıç tarihi bitiş tarihinden büyük olamaz.";
                    return View();
                }
                var result = _paymentService.GetPaymentByDate(startDate, endDate).Select(x => new PaymentViewModel
                {
                    OrderId = x.OrderId,
                    TotalPayment = x.TotalPayment,
                    PaymentType = x.PaymentType,
                    CreatedDate = x.CreatedDate,
                }).ToList();
                ViewBag.StartDate = startDate;
                ViewBag.EndDate = endDate;
                return View(result);
            }
            else
            {
                var result = _paymentService.GetAllPayment().OrderByDescending(x=>x.CreatedDate).Select(x => new PaymentViewModel
                {
                    OrderId = x.OrderId,
                    TotalPayment = x.TotalPayment,
                    PaymentType = x.PaymentType,
                    CreatedDate = x.CreatedDate,
                }).ToList();

                return View(result);
            }            
        }
    }
}
