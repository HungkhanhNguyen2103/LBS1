using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.API;
using LBSWeb.Common;

namespace IReadingWeb.Service.UserConnection
{
    public class UserConnectionManager : IUserConnectionManager
    {
        private static readonly Dictionary<string, HashSet<string>> _userConnections = new Dictionary<string, HashSet<string>>() ;
        public static WebAPICaller _api;
        public UserConnectionManager(WebAPICaller api)
        {
            _api = api;
        }
        public void AddConnection(string username, string connectionId)
        {
            // lock => tránh ghi đè khi có nhiều request đến cùng lúc
            // HashSet cho trường hợp user có nhiều connectionId (mở nhiều tab)
            lock (_userConnections)
            {
                if (!_userConnections.ContainsKey(username))
                    _userConnections[username] = new HashSet<string>();

                _userConnections[username].Add(connectionId);
            }
        }

        public void RemoveConnection(string connectionId)
        {
            lock (_userConnections)
            {
                foreach (var user in _userConnections.Keys.ToList())
                {
                    _userConnections[user].Remove(connectionId);
                    if (_userConnections[user].Count == 0)
                        _userConnections.Remove(user);
                }
            }
        }

        public List<string> GetConnections(string username)
        {
            return _userConnections.ContainsKey(username)
                ? _userConnections[username].ToList()
                : new List<string>();
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
    }
}
