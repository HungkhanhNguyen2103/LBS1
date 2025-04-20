using BusinessObject;
using BusinessObject.BaseModel;
using Newtonsoft.Json;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly LBSDbContext _lBSDbContext;
        private IAccountRepository _accountRepository;
        public NotificationRepository(LBSDbContext lBSDbContext,IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _lBSDbContext = lBSDbContext;
        }

        public async Task<ReponderModel<string>> SendPushNotification(FcmMessageModel message)
        {
            var result = new ReponderModel<string>();
            var serverKey = "YOUR_FIREBASE_SERVER_KEY"; // từ Firebase Console
            var senderId = "YOUR_SENDER_ID"; // App ID hoặc project number

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + serverKey);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Sender", "id=" + senderId);

            var jsonMessage = JsonConvert.SerializeObject(message);
            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://fcm.googleapis.com/fcm/send", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
