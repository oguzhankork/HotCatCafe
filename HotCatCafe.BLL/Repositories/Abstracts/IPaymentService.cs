using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Abstracts
{
    public interface IPaymentService
    {
        Task<string>CreatePaymentAsync(Payment payment);

        IEnumerable<Payment> GetAllPayment();

        IEnumerable<Payment> GetPaymentByDate(DateTime? startTime, DateTime? endTime);
    }
}
