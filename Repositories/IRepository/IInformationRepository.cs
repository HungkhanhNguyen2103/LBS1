using BusinessObject.BaseModel;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IInformationRepository
    {
        Task<ReponderModel<BasicKnowledge>> BasicKnowledge(string search);
        Task<ReponderModel<BasicKnowledge>> KnowledgeDetail(int id);
        Task<ReponderModel<Notification>> ListNotification();
        Task<ReponderModel<Notification>> NotificationDetail(int id);
        Task<ReponderModel<Conspectus>> ListConspectus(string username);
        Task<ReponderModel<Conspectus>> ConspectusDetail(int id);
        Task<ReponderModel<string>> UpdateConspectus(Conspectus model);
        Task<ReponderModel<string>> DeleteConspectus(int id);
        Task<ReponderModel<UserReport>> ListUserReport(string username, UserReportType userType);
        Task<ReponderModel<string>> CreateUserReport(UserReport userReport);
    }
}
