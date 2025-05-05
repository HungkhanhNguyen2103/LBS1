using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LBSWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit.Encodings;
using Newtonsoft.Json;
using OpenAI;
using OpenAI.Interfaces;
using OpenAI.Managers;
//using OpenAI.Audio;
using OpenAI.ObjectModels.RequestModels;



//using OpenAI.Audio;
using Repositories;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
//using OpenAI.GPT3;
//using OpenAI.GPT3.Managers;
//using OpenAI.GPT3.ObjectModels.RequestModels;
//using OpenAI.GPT3.ObjectModels;

namespace LBSWeb.Controllers
{
    //[Authorize]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf, IConfiguration configuration)
		{
			_logger = logger;
			_notyf = notyf;
			_configuration = configuration;
		}


        public async Task<IActionResult> Index()
		{
            
            //    var httpClient = new HttpClient();
            //    var audioStream = await httpClient.GetStreamAsync("https://ireading.store/api/Book/Audio/4f215c61-15c7-463d-b235-377715584567.mp3");
            //    using var memoryStream = new MemoryStream();
            //    await audioStream.CopyToAsync(memoryStream);
            //    byte[] audioBytes = memoryStream.ToArray();

            //    var result = await _openAiService.Audio.CreateTranscription(new AudioCreateTranscriptionRequest
            //    {
            //        FileName = "test.mp3",
            //        File = audioBytes,
            //        Model = "whisper-1",
            //        ResponseFormat = "verbose_json"
            //    });
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            //var requestData1 = new
            //{
            //    model = "tts-1",
            //    input = "The quick brown fox jumped over the lazy dog.",
            //    voice = "alloy"
            //};
            //var apiKey = "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";

            //var apiUrl = "https://api.openai.com/v1/audio/speech";


            //AudioClient client = new(
            //        model: "tts-1",
            //        apiKey: apiKey
            //);

            //BinaryData speech = client.GenerateSpeech(
            //    text: $@"Lorem Ipsum là gì?
            //        Lorem Ipsum chỉ đơn giản là một đoạn văn bản giả, được dùng vào việc trình bày và dàn trang phục vụ cho in ấn. Lorem Ipsum đã được sử dụng như một văn bản chuẩn cho ngành công nghiệp in ấn từ những năm 1500, khi một họa sĩ vô danh ghép nhiều đoạn văn bản với nhau để tạo thành một bản mẫu văn bản. Đoạn văn bản này không những đã tồn tại năm thế kỉ, mà khi được áp dụng vào tin học văn phòng, nội dung của nó vẫn không hề bị thay đổi. Nó đã được phổ biến trong những năm 1960 nhờ việc bán những bản giấy Letraset in những đoạn Lorem Ipsum, và gần đây hơn, được sử dụng trong các ứng dụng dàn trang, như Aldus PageMaker.

            //        Tại sao lại sử dụng nó?
            //        Chúng ta vẫn biết rằng, làm việc với một đoạn văn bản dễ đọc và rõ nghĩa dễ gây rối trí và cản trở việc tập trung vào yếu tố trình bày văn bản. Lorem Ipsum có ưu điểm hơn so với đoạn văn bản chỉ gồm nội dung kiểu ""Nội dung, nội dung, nội dung"" là nó khiến văn bản giống thật hơn, bình thường hơn. Nhiều phần mềm thiết kế giao diện web và dàn trang ngày nay đã sử dụng Lorem Ipsum làm đoạn văn bản giả, và nếu bạn thử tìm các đoạn ""Lorem ipsum"" trên mạng thì sẽ khám phá ra nhiều trang web hiện vẫn đang trong quá trình xây dựng. Có nhiều phiên bản khác nhau đã xuất hiện, đôi khi do vô tình, nhiều khi do cố ý (xen thêm vào những câu hài hước hay thông tục).
            //        Nó đến từ đâu?
            //        Trái với quan điểm chung của số đông, Lorem Ipsum không phải chỉ là một đoạn văn bản ngẫu nhiên. Người ta tìm thấy nguồn gốc của nó từ những tác phẩm văn học la-tinh cổ điển xuất hiện từ năm 45 trước Công Nguyên, nghĩa là nó đã có khoảng hơn 2000 tuổi. Một giáo sư của trường Hampden-Sydney College (bang Virginia - Mỹ) quan tâm tới một trong những từ la-tinh khó hiểu nhất, ""consectetur"", trích từ một đoạn của Lorem Ipsum, và đã nghiên cứu tất cả các ứng dụng của từ này trong văn học cổ điển, để từ đó tìm ra nguồn gốc không thể chối cãi của Lorem Ipsum. Thật ra, nó được tìm thấy trong các đoạn 1.10.32 và 1.10.33 của ""De Finibus Bonorum et Malorum"" (Đỉnh tối thượng của Cái Tốt và Cái Xấu) viết bởi Cicero vào năm 45 trước Công Nguyên. Cuốn sách này là một luận thuyết đạo lí rất phổ biến trong thời kì Phục Hưng. Dòng đầu tiên của Lorem Ipsum, ""Lorem ipsum dolor sit amet..."" được trích từ một câu trong đoạn thứ 1.10.32.

            //        Trích đoạn chuẩn của Lorem Ipsum được sử dụng từ thế kỉ thứ 16 và được tái bản sau đó cho những người quan tâm đến nó. Đoạn 1.10.32 và 1.10.33 trong cuốn ""De Finibus Bonorum et Malorum"" của Cicero cũng được tái bản lại theo đúng cấu trúc gốc, kèm theo phiên bản tiếng Anh được dịch bởi H. Rackham vào năm 1914.
            //        Làm thế nào để có nó?
            //        Có rất nhiều biến thể của Lorem Ipsum mà bạn có thể tìm thấy, nhưng đa số được biến đổi bằng cách thêm các yếu tố hài hước, các từ ngẫu nhiên có khi không có vẻ gì là có ý nghĩa. Nếu bạn định sử dụng một đoạn Lorem Ipsum, bạn nên kiểm tra kĩ để chắn chắn là không có gì nhạy cảm được giấu ở giữa đoạn văn bản. Tất cả các công cụ sản xuất văn bản mẫu Lorem Ipsum đều được làm theo cách lặp đi lặp lại các đoạn chữ cho tới đủ thì thôi, khiến cho lipsum.com trở thành công cụ sản xuất Lorem Ipsum đáng giá nhất trên mạng. Trang web này sử dụng hơn 200 từ la-tinh, kết hợp thuần thục nhiều cấu trúc câu để tạo ra văn bản Lorem Ipsum trông có vẻ thật sự hợp lí. Nhờ thế, văn bản Lorem Ipsum được tạo ra mà không cần một sự lặp lại nào, cũng không cần chèn thêm các từ ngữ hóm hỉnh hay thiếu trật tự.",
            //    voice: GeneratedSpeechVoice.Alloy
            //);

            //string outputPath = "speech.mp3";
            //using (FileStream stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            //{
            //    speech.ToStream().CopyTo(stream);
            //}

            //using FileStream stream = System.IO.File.OpenWrite("speech.mp3");
            //speech.ToStream().CopyTo(stream);

            //var requestData = new
            //{
            //    model = "gpt-4o-mini",
            //    messages = new[]
            //    {
            //        new { role = "system", content = "You are a helpful assistant." },
            //        new { role = "user", content = "Viết cho tôi tóm tắt về tác phẩm 'Người lái đò sông đà'" }
            //    },
            //    max_tokens = 1000,
            //};


            //using (var httpClient = new HttpClient())
            //{

            //    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            //    var jsonContent = JsonConvert.SerializeObject(requestData1);
            //    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            //    var response = await httpClient.PostAsync(apiUrl, content);

            //    BinaryData speech = client.GenerateSpeech(
            //        text: "The quick brown fox jumped over the lazy dog.",
            //        voice: GeneratedSpeechVoice.Alloy
            //    );

            //    using FileStream stream = File.OpenWrite("speech.mp3");
            //    speech.ToStream().CopyTo(stream);

            //    var responseContent = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(responseContent);
            //}
            return Redirect("/Account/Login");
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
