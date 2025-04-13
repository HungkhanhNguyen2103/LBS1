using BusinessObject.BaseModel;
using LBSWeb.API;
using LBSWeb.Common;

namespace IReadingWeb.Service.Payment
{
    public class PaymentService : IPaymentService
    {
        public static WebAPICaller _api;
        public PaymentService(WebAPICaller api)
        {
            _api = api;
        }

        public async Task<ReponderModel<string>> PaymentSuccess(string email, int type, int paymentKey, long orderId)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.PAYMENT_SUCCESS;
                var param = new Dictionary<string, string>();
                param.Add("email", email);
                param.Add("type", type.ToString());
                param.Add("paymentKey", paymentKey.ToString());
                param.Add("orderId", orderId.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
