﻿using BusinessObject;
using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IPaymentRepository
    {
        Task<ReponderModel<string>> CreatePaymentLink(PaymentRequestModel model);
        Task<ReponderModel<PaymentItem>> GetListPayment(PaymentItemType type);
        Task<ReponderModel<string>> PaymentSuccess(string email,int type,int paymentKey, long orderId);
    }
}
