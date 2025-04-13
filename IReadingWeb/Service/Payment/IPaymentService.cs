using BusinessObject.BaseModel;

namespace IReadingWeb.Service.Payment
{
    public interface IPaymentService
    {
        Task<ReponderModel<string>> PaymentSuccess(string email, int type, int paymentKey,long orderId);
    }
}
