using System;
using System.Threading.Tasks;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Xunit;

namespace SchoolRegister.Tests.UnitTests
{
    public class EmailSenderServiceUnitTests : BaseUnitTests
    {
        private readonly IEmailSenderService _emailSenderService;
        public EmailSenderServiceUnitTests(ApplicationDbContext dbContext, IEmailSenderService emailSenderService) : base(dbContext)
        {
            _emailSenderService = emailSenderService;
        }

        [Fact]
        public async void SendEmailTrue()
        {
            var emailVm = new EmailRequestVm
            {
                TeacherId = 1,
                ParentId = 3,
                EmailBody = "Test email body",
                EmailSubject = "Test email subject",
                Attachments = null
            };

            var result = await _emailSenderService.SendEmailAsync(emailVm);
            Assert.True(result);
        }

        [Fact]
        public async void SendEmailNullEmailVm()
        {
            EmailRequestVm emailRequestVm = null;

            Func<Task<bool>> act = async () => await _emailSenderService.SendEmailAsync(emailRequestVm);

            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public async void SendEmailIncorrectUserId()
        {
            var emailRequestVm = new EmailRequestVm
            {
                TeacherId = 30,
                ParentId = 3,
                EmailBody = "Test email body",
                EmailSubject = "Test email subject"
            };

            Func<Task<bool>> act = async () => await _emailSenderService.SendEmailAsync(emailRequestVm);


            var exception = await Assert.ThrowsAsync<ArgumentException>(act);
            Assert.Equal(exception.Message, $"There is no user with id {emailRequestVm.TeacherId} or {emailRequestVm.ParentId}");

        }

        [Fact]
        public async void SendEmailWrongUserRole()
        {
            var emailRequestVm = new EmailRequestVm
            {
                TeacherId = 5,
                ParentId = 3,
                EmailBody = "Test email body",
                EmailSubject = "Test email subject"
            };

            Func<Task<bool>> act = async () => await _emailSenderService.SendEmailAsync(emailRequestVm);
            await Assert.ThrowsAsync<InvalidOperationException>(act);
        }
    }
}