using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Repositories.Repository;

namespace LBSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController
    {
        private readonly IInformationRepository _informationRepository;
        public InformationController(IInformationRepository informationRepository)
        {
            _informationRepository = informationRepository;
        }

        [Route("GetListNoteManager")]
        [HttpGet]
        public async Task<ReponderModel<NoteManager>> GetListNoteManager()
        {
            var result = await _informationRepository.GetListNoteManager();
            return result;
        }

        [Route("GetUserProfile")]
        [HttpGet]
        public async Task<ReponderModel<UserProfileModel>> GetUserProfile(string username)
        {
            var result = await _informationRepository.GetUserProfile(username);
            return result;
        }

        [Route("StatisticBook")]
        [HttpGet]
        public async Task<ReponderModel<StatisticBookModel>> StatisticBook(string username)
        {
            var result = await _informationRepository.StatisticBook(username);
            return result;
        }

        [Route("GetRoomByAuthor")]
        [HttpGet]
        public async Task<ReponderModel<RoomModel>> GetRoomByAuthor(string username, string chapterBookId)
        {
            var result = await _informationRepository.GetRoomByAuthor(username,chapterBookId);
            return result;
        }

        [Route("GetListMessageByRoom")]
        [HttpGet]
        public async Task<ReponderModel<RoomModel>> GetListMessageByRoom(string roomName)
        {
            var result = await _informationRepository.GetListMessageByRoom(roomName);
            return result;
        }

        [Route("GetListUserReportComment")]
        [HttpGet]
        public async Task<ReponderModel<UserReportCommentModel>> GetListUserReportComment(int userReportId)
        {
            var result = await _informationRepository.GetListUserReportComment(userReportId);
            return result;
        }

        [Route("CreateUserReportComment")]
        [HttpPost]
        public async Task<ReponderModel<string>> CreateUserReportComment(UserReportComment comment)
        {
            var result = await _informationRepository.CreateUserReportComment(comment);
            return result;
        }

        [Route("SendMessage")]
        [HttpPost]
        public async Task<ReponderModel<string>> SendMessage(Messenger messenger)
        {
            var result = await _informationRepository.SendMessage(messenger);
            return result;
        }

        [Route("GetRoomByManager")]
        [HttpGet]
        public async Task<ReponderModel<RoomModel>> GetRoomByManager(string username, string chapterBookId)
        {
            var result = await _informationRepository.GetRoomByManager(username, chapterBookId);
            return result;
        }

        [Route("BasicKnowledge")]
        [HttpPost]
        public async Task<ReponderModel<BasicKnowledge>> BasicKnowledge(RequestModel model)
        {
            var result = await _informationRepository.BasicKnowledge(model.Data);
            return result;
        }

        [Route("ListNotification")]
        [HttpGet]
        public async Task<ReponderModel<Notification>> ListNotification()
        {
            var result = await _informationRepository.ListNotification();
            return result;
        }

        [Route("UpdateNotification")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateNotification(Notification model)
        {
            var result = await _informationRepository.UpdateNotification(model);
            return result;
        }

        [Route("DeleteNotification")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteNotification(int id)
        {
            var result = await _informationRepository.DeleteNotification(id);
            return result;
        }

        [Route("UpdateBasicKnowledge")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateBasicKnowledge(BasicKnowledge model)
        {
            var result = await _informationRepository.UpdateBasicKnowledge(model);
            return result;
        }

        [Route("DeleteBasicKnowledge")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteBasicKnowledge(int id)
        {
            var result = await _informationRepository.DeleteBasicKnowledge(id);
            return result;
        }

        [Route("NotificationDetail")]
        [HttpGet]
        public async Task<ReponderModel<Notification>> NotificationDetail(int id)
        {
            var result = await _informationRepository.NotificationDetail(id);
            return result;
        }

        [Route("ConspectusDetail")]
        [HttpGet]
        public async Task<ReponderModel<Conspectus>> ConspectusDetail(int id)
        {
            var result = await _informationRepository.ConspectusDetail(id);
            return result;
        }

        [Route("ListConspectus")]
        [HttpGet]
        public async Task<ReponderModel<Conspectus>> ListConspectus(string username)
        {
            var result = await _informationRepository.ListConspectus(username);
            return result;
        }

        [Route("DeleteConspectus")]
        [HttpGet]
        public async Task<ReponderModel<string>> DeleteConspectus(int id)
        {
            var result = await _informationRepository.DeleteConspectus(id);
            return result;
        }

        [Route("UpdateConspectus")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateConspectus(Conspectus model)
        {
            var result = await _informationRepository.UpdateConspectus(model);
            return result;
        }

        [Route("KnowledgeDetail")]
        [HttpGet]
        public async Task<ReponderModel<BasicKnowledge>> KnowledgeDetail(int id)
        {
            var result = await _informationRepository.KnowledgeDetail(id);
            return result;
        }

        [Route("ListUserReport")]
        [HttpGet]
        public async Task<ReponderModel<UserReport>> ListUserReport(string username, int userReport)
        {
            var userReportEnum = (UserReportType)userReport;
            var result = await _informationRepository.ListUserReport(username, userReportEnum);
            return result;
        }

        [Route("CreateUserReport")]
        [HttpPost]
        public async Task<ReponderModel<string>> CreateUserReport(UserReport userReport)
        {
            var result = await _informationRepository.CreateUserReport(userReport);
            return result;
        }

        [Route("OpenUserReport")]
        [HttpGet]
        public async Task<ReponderModel<string>> OpenUserReport(int id)
        {
            var result = await _informationRepository.OpenUserReport(id);
            return result;
        }

        [Route("CloseUserReport")]
        [HttpGet]
        public async Task<ReponderModel<string>> CloseUserReport(int id)
        {
            var result = await _informationRepository.CloseUserReport(id);
            return result;
        }

        [Route("UserReport")]
        [HttpGet]
        public async Task<ReponderModel<UserReport>> UserReport(int id)
        {
            var result = await _informationRepository.UserReport(id);
            return result;
        }
    }
}
