using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.ViewModels.CreditCardViewModels;
using HotCatCafe.Model.Entities;
using HotCatCafe.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.MVC.Controllers
{
    public class TableController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITableService _tableService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ITableSessionService _tableSessionService;
        private readonly IPaymentService _paymentService;

        public TableController(UserManager<AppUser> userManager, ITableService tableService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService, ITableSessionService tableSessionService, IPaymentService paymentService)
        {
            _userManager = userManager;
            _tableService = tableService;
            _productService = productService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _tableSessionService = tableSessionService;
            _paymentService = paymentService;
        }
        public IActionResult IndexTest(int tableId)
        {
            if (_userManager.GetUserId(HttpContext.User) == null)
            {
                TempData["Error"] = "Lütfen Giriş Yapın";
                return RedirectToAction("Login", "Home");
            }

            ViewBag.TableId = tableId;

            var table = _tableService.GetTableById(tableId);
            if (table == null)
            {
                TempData["Error"] = "Masa Bulunamadı";
                return RedirectToAction("Index", "Home");
            }

            var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
            if (tableSession == null)
            {
                TempData["Error"] = "Masada Aktif Oturum Bulunamadı";
                return RedirectToAction("Index", "Home");
            }
            var orderDetails = _orderService.GetOrderByTableSessionId(tableSession.ID).OrderDetails.ToList();
            if (orderDetails.Count < 1)
            {
                TempData["Error"] = "Masada Ürün Bulunamadı";
                return RedirectToAction("Index", "Home");
            }
            return View(orderDetails);
        }
        public async Task<IActionResult> AddToTableTest(int id, int tableId)
        {
            if (_userManager.GetUserId(HttpContext.User) == null)
            {
                TempData["Error"] = "Lütfen Giriş Yapın";
                return RedirectToAction("Login", "Home");
            }

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                TempData["Error"] = "Ürün Bulunamadı";
                return RedirectToAction("Index", new { tableId });
            }

            var table = _tableService.GetTableById(tableId);
            if (table == null)
            {
                TempData["Error"] = "Masa Bulunamadı";
                return RedirectToAction("Index", "Home");
            }

            AppUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı Bulunamadı";
                return RedirectToAction("Index", "Home");
            }

            var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
            if (tableSession == null)
            {
                Random rnd = new Random();
                tableSession = new TableSession
                {
                    Table = table,
                    TableId = table.ID,
                    SessionNumber = $"S-{rnd.Next(0, 100000)}",
                    StartTime = DateTime.Now,
                    IsActive = true,
                    OrderDetails = new List<OrderDetail>()
                };
                Order order = new Order
                {
                    OrderNumber = $"O-{rnd.Next(0, 100000)}",
                    User = user,
                    Table = table,
                    PaymentControl = false,
                    TableSession = tableSession
                };
                OrderDetail orderDetail = new OrderDetail
                {
                    Product = product,
                    ProductName = product.ProductName,
                    ProductId = product.ID,
                    UnitPrice = product.UnitPrice,
                    Quantity = 1,
                    TableSession = tableSession,
                    Order = order
                };

                tableSession.OrderDetails.Add(orderDetail);
                await _tableSessionService.CreateTableSessionAsync(tableSession);
            }
            else
            {
                var order = _orderService.GetOrderByTableSessionId(tableSession.ID);

                var controlOrderDetail = order.OrderDetails.FirstOrDefault(x => x.ProductId == product.ID && x.OrderId == order.ID);

                if (controlOrderDetail != null)
                {
                    controlOrderDetail.Quantity += 1;
                }
                else
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        Product = product,
                        ProductName = product.ProductName,
                        ProductId = product.ID,
                        UnitPrice = product.UnitPrice,
                        Quantity = 1,
                        TableSession = tableSession,
                        Order = order,
                        OrderId = order.ID
                    };
                    order.OrderDetails.Add(orderDetail);
                }
                await _tableSessionService.UpdateTableSessionAsync(tableSession);
            }
            product.UnitInStock -= 1;
            await _productService.UpdateProductAsync(product);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateItemTest(int tableId, int productId, short newQuantity)
        {

            var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
            if (tableSession == null)
            {
                TempData["Error"] = "Masada Aktif Oturum Bulunamadı";
                return RedirectToAction("Index", "Home");
            }
            var order = _orderService.GetOrderByTableSessionId(tableSession.ID);

            var orderDetail = order.OrderDetails.FirstOrDefault(x => x.ProductId == productId);

            var product = _productService.GetProductById(productId);

            if (newQuantity == 0)
            {
                product.UnitInStock += orderDetail.Quantity;
                order.OrderDetails.Remove(orderDetail);
            }
            else
            {
                product.UnitInStock -= (short)(newQuantity - orderDetail.Quantity);
                orderDetail.Quantity = newQuantity;
            }
            await _tableSessionService.UpdateTableSessionAsync(tableSession);
            await _productService.UpdateProductAsync(product);

            return RedirectToAction("IndexTest", new { tableId });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteItemTest(int tableId, int productId)
        {

            var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
            if (tableSession == null)
            {
                TempData["Error"] = "Masada Aktif Oturum Bulunamadı";
                return RedirectToAction("Index", "Home");
            }
            var order = _orderService.GetOrderByTableSessionId(tableSession.ID);

            var orderDetail = order.OrderDetails.FirstOrDefault(x => x.ProductId == productId);

            if (orderDetail == null)
            {
                TempData["Error"] = "Sipariş Detayı Bulunamadı";
                return RedirectToAction("Index", "Home");
            }
            order.OrderDetails.Remove(orderDetail);
            await _orderService.UpdateOrder(order);
            await _tableSessionService.UpdateTableSessionAsync(tableSession);
            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                product.UnitInStock += orderDetail.Quantity;
                await _productService.UpdateProductAsync(product);
            }
            return Json(new { success = true, message = "Ürün masadan kaldırıldı." });

        }
        [HttpGet]
        public IActionResult GetPaymentTest(decimal? totalPayment)
        {
            if (totalPayment == null)
            {
                TempData["Error"] = "Ödeme Tutarı Bulunamadı";
                return RedirectToAction("Index", "Home");
            }
            var model = new CreditCardViewModel
            {
                SubTotal = totalPayment.Value / 100
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GetPaymentTest(CreditCardViewModel creditCardVM, int tableId)
        {
            if (ModelState.IsValid)
            {
                var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
                var table = _tableService.GetTableById(tableId);
                var order = _orderService.GetOrderByTableSessionId(tableSession.ID);

                tableSession.EndTime = DateTime.Now;
                tableSession.IsActive = false;
                tableSession.UpdatedDate = DateTime.Now;
                table.TableSituation = TableSituation.FREE;

                Payment payment = new Payment
                {
                    TotalPayment = creditCardVM.SubTotal,
                    PaymentType = PaymentType.CREDITCARD,
                    Order = order,
                    OrderId = order.ID
                };
                await _paymentService.CreatePaymentAsync(payment);

                order.Payment = payment;
                order.PaymentId = payment.ID;
                order.PaymentControl = true;

                await _orderService.UpdateOrder(order);
                await _tableSessionService.UpdateTableSessionAsync(tableSession);
                await _tableService.UpdateTableAsync(table);



                TempData["Success"] = "Ödeme Başarıyla Alındı";
                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = "Kredi Kartı Bilgilerinde Sorun Çıktı";
            return View(creditCardVM);
        }
    }
}
