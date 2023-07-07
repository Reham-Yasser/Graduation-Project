using DAL;
using Edu_Chatbot.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Chatbot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController <T> :BaseApiController where T : class
    {
        private readonly EduChatbot_DB_Context Context;

        public BuggyController(EduChatbot_DB_Context context)
        {
            Context = context;
        }

        [HttpGet("notFound")]
        public async Task<ActionResult<T>> GetNotFound()
        {
            var item = await Context.Set<T>().FindAsync(100);
            if (item == null) return NotFound(new ApiResponse(404));
            return Ok();
        }

        [HttpGet("serverError")]

        public ActionResult GetServerError()
        {
            var item = Context.Set<T>().Find(30);
            var strItem = item.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]

        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


        [HttpGet("badrequest/{id}")]

        public ActionResult GetBadRequestById(int id)
        {
            return Ok();
        }


    }
}
