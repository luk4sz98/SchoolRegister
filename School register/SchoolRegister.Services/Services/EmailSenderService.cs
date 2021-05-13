

using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Services
{
    public class EmailSenderService : BaseService, IEmailSenderService
    {
        private readonly SmtpClient _smtpClient;
        public EmailSenderService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager, SmtpClient smtpClient) : base(dbContext, mapper, logger, userManager)
        {
            _smtpClient = smtpClient;
        }

        public async Task<bool> SendEmailAsync(EmailRequestVm emailRequestVm)
        {
            try
            {
                if (emailRequestVm == null)
                    throw new ArgumentNullException("Email can not be null.");

                var teacher = await DbContext.Users.FirstOrDefaultAsync(t => t.Id == emailRequestVm.TeacherId);

                var parent = await DbContext.Users.FirstOrDefaultAsync(p => p.Id == emailRequestVm.ParentId);


                if (parent == null || teacher == null)
                    throw new ArgumentException($"There is no user with id {emailRequestVm.TeacherId} or {emailRequestVm.ParentId}");

                if (!await UserManager.IsInRoleAsync(teacher, "Teacher") || !await UserManager.IsInRoleAsync(parent, "Parent"))
                    throw new InvalidOperationException("Sender must be a teacher, and recipient must be a parent.");

                using (MailMessage message = new MailMessage(teacher.Email, parent.Email, emailRequestVm.EmailSubject, emailRequestVm.EmailBody))
                {
                    if (emailRequestVm.Attachments != null)
                    {
                        foreach (var attachment in emailRequestVm.Attachments)
                        {
                            string fileName = Path.GetFileName(attachment.FileName);
                            message.Attachments.Add(new Attachment(attachment.OpenReadStream(), fileName));
                        }
                    }
                    await _smtpClient.SendMailAsync(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}