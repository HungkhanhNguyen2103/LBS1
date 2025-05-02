using AspNetCoreHero.ToastNotification.Abstractions;
using IReadingWeb.Service.Payment;
using Microsoft.AspNetCore.Mvc;

namespace IReadingWeb.Controllers
{
    [Route("Payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly INotyfService _notyf;
        public PaymentController(IPaymentService paymentService, INotyfService notyf)
        {
            _notyf = notyf;
            _paymentService = paymentService;
        }

        //[HttpGet]
        [Route("PaymentSuccess")]
        public async Task<IActionResult> PaymentSuccess(string email, int type, int paymentKey, long orderCode)
        {
            var result = await _paymentService.PaymentSuccess(email, type, paymentKey, orderCode);
            //if (!result.IsSussess) return Redirect("/Payment/PaymentCancel");
            return View();
        }

        //[AllowAnonymous]
        [Route("PaymentCancel")]
        public IActionResult PaymentCancel()
        {
            return View();
        }

    }
}
