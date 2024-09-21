using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<string> CreateOrderAsync(Order order)
        {
            try
            {
                return await _orderRepository.Create(order);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetByID(id);
        }
        public Order GetOrderByTableSessionId(int tableSessionId)
        {
            return _orderRepository.GetAll().Include(x=>x.OrderDetails).FirstOrDefault(x=>x.TableSessionId == tableSessionId);           
           
        }
        public Task<string> UpdateOrder(Order order)
        {
            return _orderRepository.Update(order);
        }
    }
}
