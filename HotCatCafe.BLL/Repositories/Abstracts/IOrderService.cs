using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface IOrderService
    {
        
        IEnumerable<Order> GetAllOrders();

        Task<string> UpdateOrder(Order  order);
        Task<string> CreateOrderAsync(Order order);

        Order GetOrderByTableSessionId(int tableSessionId);

        Order GetOrderById(int id);

    }
}
