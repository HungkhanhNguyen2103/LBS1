using Azure;
using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
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
        private readonly LBSMongoDBContext _mongoContext;
        private readonly LBSDbContext _lBSDbContext;
        private readonly PayOS _payOS;
        private readonly UserManager<Account> _userManager;
        public PaymentRepository(PayOS payOS, LBSDbContext lBSDbContext, UserManager<Account> userManager, LBSMongoDBContext mongoDBContext)
        {
            _payOS = payOS;
            _lBSDbContext = lBSDbContext;
            _userManager = userManager;
            _mongoContext = mongoDBContext;
        }

        public async Task<ReponderModel<int>> CheckEnoughCoins(string username, int amount)
        {
            var result = new ReponderModel<int>();
            var paidPackage = await _lBSDbContext.UserTranscations.Include(c => c.PaymentItem).Where(c => c.UserName == username).ToListAsync();
            var userTranscations = await _lBSDbContext.UserTranscationBooks.Where(c => c.UserName == username).ToListAsync();
            var totalPaidRemaining = paidPackage.Sum(c => c.Amount) - userTranscations.Sum(c => c.Amount);
            result.Data = totalPaidRemaining;
            if (totalPaidRemaining < amount)
            {
                result.Message = "Số dư không đủ";
                return result;
            }
            result.IsSussess = true;
            result.Message = "Số dư đủ";
            return result;
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
                var domain = model.domain + "/Payment";
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

        public async Task<ReponderModel<UserTranscationBookModel>> GetHistoryPayment(string username)
        {
            var result = new ReponderModel<UserTranscationBookModel>();
            var userTransication = await _lBSDbContext.UserTranscations.Include(c => c.PaymentItem).Where(x => x.UserName == username).ToListAsync();
            foreach (var item in userTransication)
            {
                result.DataList.Add(new UserTranscationBookModel
                {
                    Id = item.Id,
                    PaymentName = item.PaymentItem.PaymentName,
                    PaymentNameEnum = PaymentNameEnum.Deposit,
                    Price = item.PaymentItem.Amount,
                    CreateDate = item.CreateDate.AddHours(7).ToString("HH:mm dd-MM-yyyy"),
                    CreateDateFormat = item.CreateDate.AddHours(7),
                });
            }

            var userTranscationBook = await _lBSDbContext.UserTranscationBooks.Include(c => c.Book).Where(x => x.UserName == username).ToListAsync();

            var chapterIds = userTranscationBook.Where(c => !string.IsNullOrEmpty(c.ChapterId)).Select(c => c.ChapterId).ToList();
            var filter = Builders<BookChapter>.Filter.In(c => c.Id, chapterIds);
            var chapters = await _mongoContext.BookChapters.Find(filter).ToListAsync();
            foreach (var item in userTranscationBook)
            {
                var paymentName = string.Empty;

                if (!string.IsNullOrEmpty(item.ChapterId))
                {
                    var chapter = chapters.FirstOrDefault(c => c.Id == item.ChapterId);
                    var book = await _lBSDbContext.Books.FirstOrDefaultAsync(x => x.Id == chapter.BookId);
                    paymentName = $"Mở khóa chương {chapter.ChapterName} - sách {book.Name}";
                }
                else if (item.BookId != -1)
                {
                    var book = await _lBSDbContext.Books.FirstOrDefaultAsync(x => x.Id == item.BookId);
                    paymentName = $"Mở khóa sách {book.Name}";
                }

                result.DataList.Add(new UserTranscationBookModel
                {
                    Id = item.Id,
                    PaymentName = paymentName,
                    PaymentNameEnum = PaymentNameEnum.Pay,
                    Price = item.Amount,
                    CreateDate = item.CreateDate.AddHours(7).ToString("HH:mm dd-MM-yyyy"),
                    CreateDateFormat = item.CreateDate.AddHours(7),
                });
            }
            result.DataList = result.DataList.OrderByDescending(c => c.CreateDateFormat).ToList();    
            result.IsSussess = true;
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

        public async Task<ReponderModel<string>> PaymentItem(UserTransactionBook userTranscationBook)
        {
            var result = new ReponderModel<string>();
            var price = 0;
            if(userTranscationBook == null)
            {
                result.Message = "Dữ liệu không hợp lệ";
                return result;
            }

            var user = await _userManager.FindByNameAsync(userTranscationBook.UserName);
            if(user == null)
            {
                result.Message = "Không tồn tại người dùng";
                return result;
            }



            var asQuery = _lBSDbContext.UserTranscationBooks.Where(c => c.UserName == userTranscationBook.UserName).AsQueryable();
            if (!string.IsNullOrEmpty(userTranscationBook.ChapterId))
            {
                var resultPayment = await asQuery.FirstOrDefaultAsync(x => x.ChapterId == userTranscationBook.ChapterId && x.Type == userTranscationBook.Type);
                if(resultPayment != null)
                {
                    result.Message = "Chương đã được thanh toán";
                    return result;
                }

                var filter = Builders<BookChapter>.Filter.Eq(c => c.Id, userTranscationBook.ChapterId);
                var chapter = await _mongoContext.BookChapters.Find(filter).FirstOrDefaultAsync();
                if (chapter == null)
                {
                    result.Message = "Không tồn tại chương";
                    return result;
                }

                price = chapter.Price;

            }
            else if (userTranscationBook.BookId != -1)
            {
                var resultPayment = await asQuery.FirstOrDefaultAsync(x => x.BookId == userTranscationBook.BookId && x.Type == userTranscationBook.Type);
                if (resultPayment != null)
                {
                    result.Message = "Sách đã được thanh toán";
                    return result;
                }

                var book = await _lBSDbContext.Books.FirstOrDefaultAsync(x => x.Id == userTranscationBook.BookId);  
                if(book == null)
                {
                    result.Message = "Không tồn tại sách";
                    return result;
                }
                price = book.Price;
            }
            userTranscationBook.Amount = price;
            userTranscationBook.CreateDate = DateTime.UtcNow;
            _lBSDbContext.UserTranscationBooks.Add(userTranscationBook);

            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Thanh toán thành công";
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

            var userTranscation = new UserTransaction
            {
                PaymentItemId = paymentKey,
                Type = typeEnum,
                Price = paymentItem.Amount,
                UserId = user.Id,
                OrderId = orderId,
                UserName = user.UserName,
                Amount = paymentItem.Amount,
                CreateDate = DateTime.UtcNow,
            };

            if(paymentItem.ExpiredMinute != 0)
            {
                userTranscation.ExpireDate = DateTime.UtcNow.AddMinutes(paymentItem.ExpiredMinute);
            }
            
            _lBSDbContext.UserTranscations.Add(userTranscation);

            await _lBSDbContext.SaveChangesAsync();
            result.Message = "Thanh toán thành công";
            result.IsSussess = true;
            return result;
        }
    
    }
}
