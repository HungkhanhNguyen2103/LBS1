using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Images;
using System;
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

        public async Task<ReponderModel<string>> TextGenerateToSpeech(string input)
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

                var filename = $"{Guid.NewGuid().ToString()}.mp3";

                outputPath = Path.Combine(outputPath,filename);
                using (FileStream stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    speech.ToStream().CopyTo(stream);
                    result.Message = "Tạo thành công";
                    result.Data = outputPath;
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
                //var imageOption = new ImageGenerationOptions
                //{
                //    Size = GeneratedImageSize.W512xH512
                //    //Quality = GeneratedImageQuality.Standard
                //};
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
    }

    public class AIConfiguration
    {
        public string Key { get; set; }
    }
}
