using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGPT_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string prompt)
        {
            string apiKey = "Key";
            string answer = string.Empty;

            var openAI = new OpenAIAPI(apiKey);

            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = prompt;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 4000;

            var result = openAI.Completions.CreateCompletionAsync(completionRequest);
            if (result is not null)
            {
                foreach (var item in result.Result.Completions)
                {
                    answer = item.Text;
                }

                return Ok(answer);
            }
            else
            {
                return BadRequest("No found");
            }
        }

    }
}
