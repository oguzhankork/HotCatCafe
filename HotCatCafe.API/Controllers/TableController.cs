using HotCatCafe.API.DTOs.CreditCardDtos;
using HotCatCafe.API.DTOs.OrderDetailDtos;
using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.Model.Entities;
using HotCatCafe.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotCatCafe.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TableController : ControllerBase
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
        [HttpGet("{tableId}")]
        public IActionResult Index(int tableId)
        {
            if (_userManager.GetUserId(HttpContext.User) == null)
            {
                return BadRequest("Lütfen Giriş Yapın");
            }

            var table = _tableService.GetTableById(tableId);
            if (table == null)
            {
                return BadRequest("Masa Bulunamadı");
            }

            var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
            if (tableSession == null)
            {
                return BadRequest("Masada Aktif Oturum Bulunamadı");
            }
            var orderDetails = _orderService.GetOrderByTableSessionId(tableSession.ID).OrderDetails;
            if (orderDetails.Count < 1)
            {
                return BadRequest("Masada Ürün Bulunamadı");
            }
            var orderDetailDto = orderDetails.Select(x => new OrderDetailDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                OrderId = x.OrderId,
            }).ToList();
            return Ok(orderDetailDto);
        }
        [HttpGet("{id}/{tableId}")]
        public async Task<IActionResult> AddToTable(int id, int tableId)
        {
            if (_userManager.GetUserId(HttpContext.User) == null)
            {
                return BadRequest("Lütfen Giriş Yapın");
            }

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return BadRequest("Ürün Bulunamadı");
            }

            var table = _tableService.GetTableById(tableId);
            if (table == null)
            {
                return BadRequest("Masa Bulunamadı");
            }

            AppUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("Kullanıcı Bulunamadı");
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
            return Ok("Ürün Masaya Eklendi");
        }
        [HttpPost("{tableId}/{productId}/{newQuantity}")]
        public async Task<IActionResult> UpdateItem(int tableId, int productId, short newQuantity)
        {
            var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
            if (tableSession == null)
            {
                return BadRequest("Masada Aktif Oturum Bulunamadı");
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

            return Ok("Ürün Güncellendi");
        }

        [HttpPost("{tableId}/{productId}")]
        public async Task<IActionResult> DeleteItem(int tableId, int productId)
        {

            var tableSession = _tableSessionService.GetActiveTableSessionByTableId(tableId);
            if (tableSession == null)
            {
                return BadRequest("Masada Aktif Oturum Bulunamadı");
            }
            var order = _orderService.GetOrderByTableSessionId(tableSession.ID);

            var orderDetail = order.OrderDetails.FirstOrDefault(x => x.ProductId == productId);

            if (orderDetail == null)
            {
                return BadRequest("Sipariş Detayı Bulunamadı");
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
            return Ok("Ürün masadan kaldırıldı.");

        }
        [HttpPost("{tableId}")]
        public async Task<IActionResult> GetPayment(CreditCardDto creditCardDto, int tableId)
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
                    TotalPayment = creditCardDto.SubTotal,
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

                return Ok($"{payment.TotalPayment}₺ Ödeme Başarıyla Alındı");
            }
            return BadRequest("Kredi Kartı Bilgilerinde Sorun Çıktı");
        }
    }
}
