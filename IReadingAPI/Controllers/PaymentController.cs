using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Net.payOS;
using Repositories.IRepository;
using Repositories.Repository;
using BusinessObject;
using MailKit.Search;

namespace IReadingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IConfiguration _configuration;
        public PaymentController(IPaymentRepository paymentRepository, IConfiguration configuration)
        {
            _paymentRepository = paymentRepository;
            _configuration = configuration;
        }


        [Route("CreatePaymentLink")]
        [HttpPost]
        public async Task<ReponderModel<string>> CreatePaymentLink(PaymentRequestModel model)
        {
            model.domain = _configuration["WebPage:URL"].ToString();
            var result = await _paymentRepository.CreatePaymentLink(model);
            return result;
        }

        [Route("CheckEnoughCoins")]
        [HttpGet]
        public async Task<ReponderModel<int>> CheckEnoughCoins(string username, int amount)
        {
            var result = await _paymentRepository.CheckEnoughCoins(username, amount);
            return result;
        }

        [Route("GetListPayment")]
        [HttpGet]
        public async Task<ReponderModel<PaymentItem>> GetListPayment(int type)
        {
            var typeEnum = (PaymentItemType) type;
            var result = await _paymentRepository.GetListPayment(typeEnum);
            return result;
        }

        [Route("PaymentSuccess")]
        [HttpGet]
        public async Task<ReponderModel<string>> PaymentSuccess(string email, int type , int paymentKey,long orderId)
        {
            var result = await _paymentRepository.PaymentSuccess(email,type,paymentKey, orderId);
            return result;
        }

        [Route("PaymentItem")]
        [HttpPost]
        public async Task<ReponderModel<string>> PaymentItem(UserTransactionBook userTranscationBook)
        {
            var result = await _paymentRepository.PaymentItem(userTranscationBook);
            return result;
        }

        [Route("PaymentItem")]
        [HttpGet]
        public async Task<ReponderModel<UserTranscationBookModel>> GetHistoryPayment(string username)
        {
            var result = await _paymentRepository.GetHistoryPayment(username);
            return result;
        }
    }
}
