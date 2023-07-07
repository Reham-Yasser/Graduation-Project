using Edu_Chatbot.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Chatbot.Controllers
{
    [Route("errors/code")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {


        public ActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }





    }
}
