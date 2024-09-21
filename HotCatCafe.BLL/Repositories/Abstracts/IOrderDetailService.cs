using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        Task<string> CreateOrderDetail(OrderDetail orderDetail);

        IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId);

        Task<string> UpdateOrderDetail(OrderDetail orderDetail);

        OrderDetail GetOrderDetailByProductId(int productId);

        OrderDetail GetOrderDetailByTableSessionId(int tableSessionId,int productId);

        IEnumerable<OrderDetail> GetOrderDetailsByDate(DateTime startTime,DateTime endTime);

        IEnumerable<OrderDetail> GetOrderDetailByBestSeller();

        IEnumerable<OrderDetail> GetOrderDetailByLessSeller();
    }
}
