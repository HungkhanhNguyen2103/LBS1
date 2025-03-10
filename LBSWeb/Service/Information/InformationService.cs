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

        public async Task<ReponderModel<string>> UpdateConspectus(Conspectus model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
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
    }
}
