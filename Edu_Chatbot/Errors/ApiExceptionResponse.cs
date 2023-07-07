namespace Edu_Chatbot.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {

        public string Details { get; set; }

        public ApiExceptionResponse(int statusCode, string message = null, string Details = null) : base(statusCode, message)
        {
            this.Details = Details;
        }


    }
}
