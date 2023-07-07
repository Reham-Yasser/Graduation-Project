using System.ComponentModel.DataAnnotations;

namespace Edu_Chatbot.DTOS
{
    public class ResetPassword
    {
        [Required]
        public string Password { get; set; } = null;

        [Compare ("Password" , ErrorMessage = "The Password and The Confirmation Password do not match!.")]
        public string ConfirmPassword { get; set; } = null ;

        public string Email { get; set; } = null;

        public string Token { get; set; } = null;


    }
}
