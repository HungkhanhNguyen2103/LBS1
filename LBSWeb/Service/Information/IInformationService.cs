using BusinessObject.BaseModel;
using BusinessObject;

namespace LBSWeb.Service.Information
{
    public interface IInformationService
    {
        Task<ReponderModel<BasicKnowledge>> BasicKnowledge(string search);
        Task<ReponderModel<BasicKnowledge>> KnowledgeDetail(int id);
        Task<ReponderModel<Notification>> ListNotification();
        Task<ReponderModel<Notification>> NotificationDetail(int id);
        Task<ReponderModel<Conspectus>> ListConspectus(string username);
        Task<ReponderModel<Conspectus>> ConspectusDetail(int id);
        Task<ReponderModel<string>> UpdateConspectus(Conspectus model);
        Task<ReponderModel<string>> DeleteConspectus(int id);
    }
}
