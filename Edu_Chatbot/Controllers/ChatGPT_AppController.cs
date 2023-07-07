using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace Edu_Chatbot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ChatGPT_AppController : BaseApiController
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string searchText)
        {
            string outputResult = "";
            var openai = new OpenAIAPI("kFKwAR3sqcyErdOpFQ75T3BlbkFJq7QfDQIjqgNvynsvD6vj");

            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = searchText;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 200;

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                outputResult += completion.Text;
            }

            return Ok(outputResult);

        }

    }
}
