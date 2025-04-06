using ImgurAPI.Core;
using ImgurAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ImageManager
    {
        private Imgur _imgur;
        public ImageManager(Imgur imgur)
        {
            _imgur = imgur;
        }
        //public async Task<string> GetAccessToken()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var requestData = new Dictionary<string, string>
        //    {
        //        { "client_id", ClientId },
        //        { "client_secret", ClientSecret },
        //        { "grant_type", "pin" },
        //        { "pin", PinCode }
        //    };

        //        var content = new FormUrlEncodedContent(requestData);
        //        var response = await client.PostAsync("https://api.imgur.com/oauth2/token", content);
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        Console.WriteLine("Access Token Response: " + responseString);
        //    }
        //}

        public async Task<ResponseModel<ImageModel>> UploadImage(string imageString,string type)
        {
            try
            {
                var model = new UploadImageModel
                {
                    Image = imageString,
                    Type = type
                };
                var result = await _imgur.UploadImage(model);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
 
        }
    }
}
