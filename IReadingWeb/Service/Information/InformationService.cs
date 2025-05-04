using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.API;
using LBSWeb.Common;

namespace LBSWeb.Service.Information
{
    public class InformationService : IInformationService
    {
        public static WebAPICaller _api;
        public InformationService(WebAPICaller api)
        {
            _api = api;
        }

        public async Task<ReponderModel<BasicKnowledge>> BasicKnowledge(string search)
        {
            var res = new ReponderModel<BasicKnowledge>();
            try
            {
                var model = new RequestModel
                {
                    Data = search,
                };
                string url = PathUrl.INFO_LIST_BASICKNOWLEDGE;
                res = await _api.Post<ReponderModel<BasicKnowledge>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> CloseUserReport(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.INFO_CLOSE_USERREPORT;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<Conspectus>> ConspectusDetail(int id)
        {
            var res = new ReponderModel<Conspectus>();
            try
            {
                string url = PathUrl.INFO_DETAIL_CONSPECTUS;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<Conspectus>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> CreateUserReport(UserReport model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.INFO_CREATE_USERREPORT;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> CreateUserReportComment(UserReportComment model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.INFO_CREATE_COMMENT_USERREPORT;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeleteBasicKnowledge(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.INFO_DELETE_BASICKNOWLEDGE;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeleteConspectus(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.INFO_DELETE_CONSPECTUS;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeleteNotification(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.INFO_DELETE_NOTIFICATION;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<RoomModel>> GetListMessageByRoom(string roomName)
        {
            var res = new ReponderModel<RoomModel>();
            try
            {
                string url = PathUrl.INFO_GET_LISTMESSAGE;
                var param = new Dictionary<string, string>();
                param.Add("roomName", roomName);
                res = await _api.Get<ReponderModel<RoomModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<UserReportCommentModel>> GetListUserReportComment(int userReportId)
        {
            var res = new ReponderModel<UserReportCommentModel>();
            try
            {
                string url = PathUrl.INFO_ALL_COMMENT_USERREPORT;
                var param = new Dictionary<string, string>();
                param.Add("userReportId", userReportId.ToString());
                res = await _api.Get<ReponderModel<UserReportCommentModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<RoomModel>> GetRoomByAuthor(string username, string chapterBookId)
        {
            var res = new ReponderModel<RoomModel>();
            try
            {
                string url = PathUrl.INFO_GET_ROOM_AUTHOR;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                param.Add("chapterBookId", chapterBookId);
                res = await _api.Get<ReponderModel<RoomModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<RoomModel>> GetRoomByManager(string username, string chapterBookId)
        {
            var res = new ReponderModel<RoomModel>();
            try
            {
                string url = PathUrl.INFO_GET_ROOM_MANAGER;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                param.Add("chapterBookId", chapterBookId);
                res = await _api.Get<ReponderModel<RoomModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BasicKnowledge>> KnowledgeDetail(int id)
        {
            var res = new ReponderModel<BasicKnowledge>();
            try
            {
                string url = PathUrl.INFO_DETAIL_BASICKNOWLEDGE;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<BasicKnowledge>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<Conspectus>> ListConspectus(string username)
        {
            var res = new ReponderModel<Conspectus>();
            try
            {
                string url = PathUrl.INFO_LIST_CONSPECTUS;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                res = await _api.Get<ReponderModel<Conspectus>>(url,param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<Notification>> ListNotification()
        {
            var res = new ReponderModel<Notification>();
            try
            {
                string url = PathUrl.INFO_LIST_NOTIFICATION;
                res = await _api.Get<ReponderModel<Notification>>(url);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<UserReport>> ListUserReport(string username, UserReportType userType)
        {
            var res = new ReponderModel<UserReport>();
            try
            {
                int userTypeInt = (int)userType;
                string url = PathUrl.INFO_LIST_USERREPORT;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                param.Add("userReport", userTypeInt.ToString());
                res = await _api.Get<ReponderModel<UserReport>>(url,param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<Notification>> NotificationDetail(int id)
        {
            var res = new ReponderModel<Notification>();
            try
            {
                string url = PathUrl.INFO_DETAIL_NOTIFICATION;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<Notification>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> OpenUserReport(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.INFO_OPEN_USERREPORT;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> SendMessage(Messenger model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.INFO_SEND_MESSAGE;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<StatisticBookModel>> StatisticBook(string username)
        {
            var res = new ReponderModel<StatisticBookModel>();
            try
            {
                string url = PathUrl.INFO_STATISTIC_BOOK;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                res = await _api.Get<ReponderModel<StatisticBookModel>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateBasicKnowledge(BasicKnowledge model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.INFO_UPDATE_BASICKNOWLEDGE;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateConspectus(Conspectus model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                res.Message = "Tên đại cương không để trống";
                return res;
            }
            try
            {
                string url = PathUrl.INFO_UPDATE_CONSPECTUS;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateNotification(Notification model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.INFO_UPDATE_NOTIFICATION;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<UserReport>> UserReport(int id)
        {
            var res = new ReponderModel<UserReport>();
            try
            {
                string url = PathUrl.INFO_DETAIL_USERREPORT;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<UserReport>>(url, param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
