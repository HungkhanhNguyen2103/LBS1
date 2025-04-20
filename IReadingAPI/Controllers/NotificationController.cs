using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Repositories.Repository;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Text;
using BusinessObject.BaseModel;

namespace IReadingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private string projectId = "iread-44e54";
        private readonly INotificationRepository _notificationRepository;
        private readonly GoogleCredential credential = GoogleCredential.FromFile($"{Directory.GetCurrentDirectory()}/service-account.json")
                        .CreateScoped("https://www.googleapis.com/auth/firebase.messaging");

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [Route("SendToDevice")]
        [HttpGet]
        public async Task<ReponderModel<string>> SendToDevice(string deviceToken)
        {
            var result = new ReponderModel<string>();
            try
            {

                var messageJson = $@"
                        {{
                          ""message"": {{
                            ""token"": ""{deviceToken}"",
                            ""notification"": {{
                              ""title"": ""Xác thực email"",
                              ""body"": ""Bạn đã xác thực tài khoản thành công!""
                            }},
                            ""data"": {{
                              ""screen"": ""verified"",
                              ""test"": ""tssst"",
                            }}
                          }}
                    }}";
                var accessToken = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var content = new StringContent(messageJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"https://fcm.googleapis.com/v1/projects/{projectId}/messages:send", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(responseBody);
                    result.Data = jsonResponse["name"].ToString();
                    result.IsSussess = true;
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    result.Message = errorResponse;
                    //result.Status = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

        }
    }
}
