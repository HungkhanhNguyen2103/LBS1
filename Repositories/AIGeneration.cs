using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Images;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AIGeneration
    {
        private readonly string _apiKey;

        public AIGeneration(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<ReponderModel<string>> TextGenerate(string input)
        {
            var result = new ReponderModel<string>();
            var client = new ChatClient(
                model: "gpt-4o",
                apiKey: _apiKey
            );

            List<ChatMessage> messages =
            [
                new SystemChatMessage("You are a helpful assistant."),
                new UserChatMessage(input)
            ];
            try
            {
                ChatCompletion completion = await client.CompleteChatAsync(messages);
                result.Data = completion.Content[0].Text;
                result.IsSussess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ReponderModel<string>> TextGenerateToSpeech(string input, string filename)
        {
            var result = new ReponderModel<string>();
            AudioClient client = new AudioClient(
                model: "tts-1",
                apiKey: _apiKey
            );

            try
            {
                BinaryData speech = await client.GenerateSpeechAsync(
                        text: input,
                        voice: GeneratedSpeechVoice.Alloy
                );
                var outputPath = Path.Combine(AppContext.BaseDirectory, "Resource");
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }

                //var filename = $"{Guid.NewGuid().ToString()}.mp3";

                outputPath = Path.Combine(outputPath, filename);
                using (FileStream stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    speech.ToStream().CopyTo(stream);
                    result.Message = "Tạo thành công";
                    result.Data = filename;
                    result.IsSussess = true;
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ReponderModel<string>> TextGenerateToImage(string input)
        {
            var result = new ReponderModel<string>();
            ImageClient client = new(
                    model: "dall-e-3",
                    apiKey: _apiKey
            );

            try
            {
                var imageOption = new ImageGenerationOptions
                {
                    //Size = GeneratedImageSize.W512xH512
                    Quality = GeneratedImageQuality.Standard
                };
                GeneratedImage image = await client.GenerateImageAsync(prompt: input);
                var urlImage = image.ImageUri.OriginalString;
                if (string.IsNullOrEmpty(urlImage))
                {
                    result.Message = "Không tạo được hình ảnh";
                    return result;
                }
                result.Message = "Tạo thành công";
                result.IsSussess = true;
                result.Data = urlImage;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ReponderModel<SegmentModel>> AudioTranscription(string filename)
        {
            var result = new ReponderModel<SegmentModel>();
            AudioClient client = new (
                model: "whisper-1",
                apiKey:_apiKey
            );

            var options = new AudioTranscriptionOptions
            {
                ResponseFormat = AudioTranscriptionFormat.Verbose
            };

            try
            {
                var domain = "https://ireading.store";

                //local
                //domain = "https://localhost:7157";
                var audioFilePath = $"{domain}/api/Book/Audio/{filename}";
                var httpClient = new HttpClient();
                var audioStream = await httpClient.GetStreamAsync(audioFilePath);
                AudioTranscription transcription = await client.TranscribeAudioAsync(audioStream, filename, options);

                if (transcription.Segments.Count > 0)
                {
                    result.DataList = transcription.Segments.Select(c => new SegmentModel
                    {
                        StartTime = Math.Ceiling(c.StartTime.TotalSeconds),
                        EndTime = Math.Ceiling(c.EndTime.TotalSeconds),
                        Text = c.Text
                    }).ToList();
                    result.IsSussess = true;
                }
                else result.Message = "Lỗi chuyển đổi";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }


            return result;
        }
    }

    public class AIConfiguration
    {
        public string Key { get; set; }
    }
}
