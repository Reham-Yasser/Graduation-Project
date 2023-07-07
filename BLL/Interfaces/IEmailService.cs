using BLL.Interfaces;
using BLL.ModelService;

namespace BLL.Interfaces
{
    public interface IEmailService
    {

        void SendEmail(Message message);

    }
}
