using System.Threading.Tasks;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmailAsync(EmailRequestVm emailRequestVm);
    }
}
