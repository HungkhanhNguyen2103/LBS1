using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface INotificationRepository
    {
        Task<ReponderModel<string>> SendPushNotification(FcmMessageModel model);
    }
}
