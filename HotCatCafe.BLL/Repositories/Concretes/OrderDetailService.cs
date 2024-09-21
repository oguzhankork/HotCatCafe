using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public OrderDetailService(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<string> CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                return await _orderDetailRepository.Create(orderDetail);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailByBestSeller()
        {
            var bestSeller = _orderDetailRepository.GetAll().Include(x => x.Product).GroupBy(y => y.ProductId).Select(z => new OrderDetail
            {
                ProductId = z.Key,
                ProductName = z.FirstOrDefault().Product.ProductName,
                UnitPrice = z.FirstOrDefault().Product.UnitPrice,
                Quantity = (short)z.Sum(od => (int)od.Quantity)
            }).OrderByDescending(x => x.Quantity).ToList();
            return bestSeller;
        }

        public IEnumerable<OrderDetail> GetOrderDetailByLessSeller()
        {
            var lessSeller = _orderDetailRepository.GetAll().Include(x => x.Product).GroupBy(y => y.ProductId).Select(z => new OrderDetail
            {
                ProductId = z.Key,
                ProductName = z.FirstOrDefault().Product.ProductName,
                UnitPrice = z.FirstOrDefault().Product.UnitPrice,
                Quantity = (short)z.Sum(od => (int)od.Quantity)
            }).OrderBy(x => x.Quantity).ToList();
            return lessSeller;
        }

        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return _orderDetailRepository.GetAll().Where(x => x.OrderId == orderId);
        }

        public OrderDetail GetOrderDetailByProductId(int productId)
        {
            return _orderDetailRepository.GetAll().FirstOrDefault(x => x.ProductId == productId);
        }

        public OrderDetail GetOrderDetailByTableSessionId(int tableSessionId, int productId)
        {
            return _orderDetailRepository.GetAll().FirstOrDefault(x => x.TableSessionId == tableSessionId && x.ProductId == productId);

        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return _orderDetailRepository.GetAll();
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByDate(DateTime startDate, DateTime endDate)
        {
            return _orderDetailRepository.GetAll().Where(x => x.Order.CreatedDate >= startDate && x.Order.CreatedDate <= endDate).ToList();
           
        }

        public async Task<string> UpdateOrderDetail(OrderDetail orderDetail)
        {
            return await _orderDetailRepository.Update(orderDetail);
        }
    }
}
