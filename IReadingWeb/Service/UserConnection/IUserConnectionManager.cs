using BusinessObject.BaseModel;
using BusinessObject;

namespace IReadingWeb.Service.UserConnection
{
    public interface IUserConnectionManager
    {
        void AddConnection(string username, string connectionId);
        void RemoveConnection(string connectionId);
        List<string> GetConnections(string username);
        Task<ReponderModel<string>> SendMessage(Messenger messenger);
    }
}
