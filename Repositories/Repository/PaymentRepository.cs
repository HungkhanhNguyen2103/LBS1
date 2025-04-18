﻿using Azure;
using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly LBSDbContext _lBSDbContext;
        private readonly PayOS _payOS;
        private readonly UserManager<Account> _userManager;
        public PaymentRepository(PayOS payOS, LBSDbContext lBSDbContext, UserManager<Account> userManager)
        {
            _payOS = payOS;
            _lBSDbContext = lBSDbContext;
            _userManager = userManager;
        }
        public async Task<ReponderModel<string>> CreatePaymentLink(PaymentRequestModel model)
        {
            var result = new ReponderModel<string>();
            try
            {
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                List<ItemData> items = new List<ItemData>();
                foreach (var item1 in model.items)
                {
                    var item = new ItemData(item1.name, item1.quantity, item1.price);
                    items.Add(item);
                }
                var domain = model.domain + "/Admin";
                var cancelUrl = $"{domain}/CancelPayment";
                var successUrl = $"{domain}/PaymentSuccess?email={model.buyerEmail}&type={model.type}&paymentKey={model.paymentKey}";
                PaymentData paymentData = new PaymentData(orderCode, model.amount, model.description, items, cancelUrl, successUrl);
                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);
                result.Data = createPayment.checkoutUrl;
                result.Message = "Tạo link thanh toán thành công";
                result.IsSussess = true;
                return result;
            }
            catch (Exception exception)
            {
                result.Message = exception.Message;
            }
            return result;
        }

        public async Task<ReponderModel<PaymentItem>> GetListPayment(PaymentItemType type)
        {
            var result = new ReponderModel<PaymentItem>();
            var paymentItems = await _lBSDbContext.PaymentItems.Where(x => x.Type == type).ToListAsync();
            result.DataList = paymentItems; 
            result.IsSussess = true;
            return result;
        }

        public async Task<ReponderModel<string>> PaymentSuccess(string email, int type, int paymentKey, long orderId)
        {
            var result = new ReponderModel<string>();
            var paymentItem = await _lBSDbContext.PaymentItems.FirstOrDefaultAsync(x => x.Id == paymentKey);
            if (paymentItem == null)
            {
                result.Message = "Không có dữ liệu thanh toán";
                return result;
            }
            try
            {
                var paymentResult = await _payOS.getPaymentLinkInformation(orderId);
                if (paymentResult == null || paymentResult.status != "PAID")
                {
                    result.Message = "Link thanh toán không hợp lệ";
                    return result;
                }

            }
            catch (Exception)
            {
                result.Message = "Link thanh toán không hợp lệ";
                return result;
            }

            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                result.Message = "Tài khoản không tồn tại";
                return result;
            }

            var orderTranscation = await _lBSDbContext.UserTranscations.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if(orderTranscation != null)
            {
                result.Message = "Đơn hàng đã được thanh toán";
                return result;
            }


            // hủy gói vẫn còn giá trị với member
            var typeEnum = (PaymentItemType)type;
            var userMemberOld = await _lBSDbContext.UserTranscations.FirstOrDefaultAsync(c => c.UserName == user.UserName && c.Type == PaymentItemType.Membership && c.ExpireDate != null && c.ExpireDate > DateTime.UtcNow);
            if (typeEnum == PaymentItemType.Membership && userMemberOld != null)
            {
                userMemberOld.ExpireDate = null;
            }
            //end

            var userTranscation = new UserTranscation
            {
                PaymentItemId = paymentKey,
                Type = typeEnum,
                Price = paymentItem.Amount,
                UserId = user.Id,
                OrderId = orderId,
                UserName = user.UserName,
                CreateDate = DateTime.UtcNow,
            };

            switch (paymentKey)
            {
                //IREADING 3 THÁNG
                case 5:
                    userTranscation.ExpireDate = DateTime.UtcNow.AddMonths(3);
                    break;
                //IREADING 6 THÁNG
                case 6:
                    userTranscation.ExpireDate = DateTime.UtcNow.AddMonths(6);
                    break;
                //IREADING 7 THÁNG
                case 7:
                    userTranscation.ExpireDate = DateTime.UtcNow.AddMonths(12);
                    break;
                default:
                    userTranscation.ExpireDate = null;
                    break;
            }

            _lBSDbContext.UserTranscations.Add(userTranscation);

            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Thanh toán thành công";
            result.IsSussess = true;
            return result;
        }
    }
}
