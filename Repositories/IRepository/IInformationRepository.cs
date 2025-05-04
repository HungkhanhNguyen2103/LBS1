using BusinessObject.BaseModel;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Repositories.IRepository
{
    public interface IInformationRepository
    {
        Task<ReponderModel<BasicKnowledge>> BasicKnowledge(string search);
        Task<ReponderModel<string>> UpdateBasicKnowledge(BasicKnowledge model);
        Task<ReponderModel<string>> DeleteBasicKnowledge(int id);
        Task<ReponderModel<BasicKnowledge>> KnowledgeDetail(int id);
        Task<ReponderModel<Notification>> ListNotification();
        Task<ReponderModel<Notification>> NotificationDetail(int id);
        Task<ReponderModel<string>> UpdateNotification(Notification model);
        Task<ReponderModel<string>> DeleteNotification(int id);
        Task<ReponderModel<Conspectus>> ListConspectus(string username);
        Task<ReponderModel<Conspectus>> ConspectusDetail(int id);
        Task<ReponderModel<string>> UpdateConspectus(Conspectus model);
        Task<ReponderModel<string>> DeleteConspectus(int id);
        Task<ReponderModel<UserReport>> ListUserReport(string username, UserReportType userType);
        Task<ReponderModel<UserReport>> UserReport(int id);
        Task<ReponderModel<string>> CreateUserReport(UserReport userReport);
        Task<ReponderModel<string>> CloseUserReport(int id);
        Task<ReponderModel<string>> OpenUserReport(int id);
        Task<ReponderModel<RoomModel>> GetRoomByAuthor(string username, string chapterBookId);
        Task<ReponderModel<RoomModel>> GetRoomByManager(string username, string chapterBookId);
        Task<ReponderModel<RoomModel>> GetListMessageByRoom(string roomName);
        Task<ReponderModel<string>> SendMessage(Messenger messenger);
        Task<ReponderModel<string>> CreateUserReportComment(UserReportComment comment);
        Task<ReponderModel<UserReportCommentModel>> GetListUserReportComment(int userReportId);
        Task<ReponderModel<NoteManager>> GetListNoteManager();
        Task<ReponderModel<UserProfileModel>> GetUserProfile(string username);
        //Task<ReponderModel<NoteManager>> UpdateNoteManager(NoteManager model);
        Task<ReponderModel<StatisticBookModel>> StatisticBook(string username);


    }
}
