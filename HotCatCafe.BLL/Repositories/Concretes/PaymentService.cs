using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.Model.Entities;

namespace HotCatCafe.BLL.Repositories.Concretes
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;

        public PaymentService(IRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public Task<string> CreatePaymentAsync(Payment payment)
        {
            return _paymentRepository.Create(payment);
        }

        public IEnumerable<Payment> GetAllPayment()
        {
            return _paymentRepository.GetAll();
        }

        public IEnumerable<Payment> GetPaymentByDate(DateTime? startTime, DateTime? endTime)
        {
            return _paymentRepository.GetAll().Where(x=>x.CreatedDate>=startTime && x.CreatedDate<=endTime).ToList();
        }
    }
}
