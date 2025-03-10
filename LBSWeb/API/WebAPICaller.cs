using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace LBSWeb.API
{
    public class WebAPICaller
    {
        private static IConfiguration _configuration;
        private readonly IHttpContextAccessor _context;
        //public static string _token { get; set; }

        public WebAPICaller(
            IConfiguration configuration,
            IHttpContextAccessor context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<T> Get<T>(string url, Dictionary<string, string> dctParams = null, TimeSpan? overrideTimeout = null)
        {
            var API_URL = Environment.GetEnvironmentVariable("API_URL");
            T obj = default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization =
                    //    new AuthenticationHeaderValue("Bearer",
                    //    _context.HttpContext.Session.GetString(CommonConstants.TOKEN));
                    if (overrideTimeout != null)
                    {
                        client.Timeout = overrideTimeout.GetValueOrDefault(TimeSpan.FromMinutes(3));
                    }
                    BuildUrlParams(ref url, dctParams);
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        obj = JsonConvert.DeserializeObject<T>(responseString);
                    }
                    else
                    {
                        return GetError<T>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                return GetError<T>(ex);
            }
            return await Task.FromResult(obj);
        }


        public async Task<T> Post<T>(string url, object JObj, TimeSpan? overrideTimeout = null)
        {
            var API_URL = Environment.GetEnvironmentVariable("API_URL");
            T obj = default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = overrideTimeout.GetValueOrDefault(TimeSpan.FromMinutes(3));

                    var content = CreateHttpContent(JObj);
                    var res = client.PostAsync(string.Format(url), content).Result;
                    //response
                    if (res.IsSuccessStatusCode)
                    {
                        var responseString = res.Content.ReadAsStringAsync().Result;
                        obj = JsonConvert.DeserializeObject<T>(responseString);
                    }
                    else
                    {
                        return GetError<T>(res);
                    }
                }
            }
            catch (Exception ex)
            {
                return GetError<T>(ex);
            }
            return await Task.FromResult(obj);
        }

        public HttpContent CreateHttpContent<T>(T obj)
        {
            if (obj == null)
                new StringContent("", Encoding.UTF8, "application/json");
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        private T GetError<T>(Exception ex)
        {
            T obj = Activator.CreateInstance<T>();
            var props = typeof(T).GetRuntimeProperties();
            var msg = ex.InnerException.Message;
            if (msg.ToLower().Contains("canceled"))
            {
                foreach (var prop in props)
                {
                    if (prop.Name == "Code")
                        prop.SetValue(obj, StatusCodes.Status408RequestTimeout);
                    if (prop.Name == "Message")
                        prop.SetValue(obj, "Hết thời gian kết nối!");
                }
            }
            else
            {
                foreach (var prop in props)
                {
                    if (prop.Name == "Code")
                        prop.SetValue(obj, StatusCodes.Status500InternalServerError);
                    if (prop.Name == "Message")
                        prop.SetValue(obj, "Xảy ra lỗi khi kết nối đến máy chủ!");
                }
            }
            return obj;
        }

        private T GetError<T>(HttpResponseMessage response)
        {
            T obj = Activator.CreateInstance<T>();
            var props = typeof(T).GetRuntimeProperties();
            var code = response.StatusCode.ToString();
            foreach (var prop in props)
            {
                if (prop.Name == "Code")
                    prop.SetValue(obj, response.StatusCode);
                if (prop.Name == "Message")
                    prop.SetValue(obj, "Mã lỗi: " + code);
            }
            return obj;
        }

        private void BuildUrlParams(ref string url, Dictionary<string, string> dctParams)
        {
            int index = 0;
            if (dctParams != null && dctParams.Count > 0)
            {
                foreach (var item in dctParams)
                {
                    if (index == 0)
                    {
                        url += "?" + item.Key + "=" + item.Value;
                    }
                    else
                    {
                        url += "&" + item.Key + "=" + item.Value;
                    }
                    index += 1;
                }
            }
        }


    }
}
