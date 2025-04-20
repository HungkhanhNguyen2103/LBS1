using BusinessObject.BaseModel;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Repositories
{
    public class GoogleCredentialService
    {
        private string projectId = "iread-44e54";
        private static GoogleCredential credential;


        public async Task<ReponderModel<string>> SendToDevice(string deviceToken,string token)
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
                              ""token"": ""{token}""
                            }}
                          }}
                    }}";
                var accessToken = await GetAccessToken();
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

        private async Task<string> GetAccessToken()
        {
            try
            {
                if (credential == null)
                {
                    credential = GoogleCredential.FromFile($"{Directory.GetCurrentDirectory()}/service-account.json").CreateScoped("https://www.googleapis.com/auth/firebase.messaging");
                    var accessToken = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();
                    return accessToken;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }


    }
}
