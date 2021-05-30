using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Api.Controllers
{
    [Authorize(Roles = "Teacher, Admin")]
    public class EmailApiController : BaseApiController
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly UserManager<User> _userManager;
        public EmailApiController(ILogger logger, IMapper mapper,
        IEmailSenderService emailSenderService,
        UserManager<User> userManager) : base(logger, mapper)
        {
            _emailSenderService = emailSenderService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Put(EmailRequestVm emailModel)
        {
            try
            {
                if (ModelState == null || !ModelState.IsValid)
                    return BadRequest(ModelState);
                var subjectVm = await _emailSenderService.SendEmailAsync(emailModel);
                return Ok(subjectVm);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest("Error occurred");
            }
        }
    }
}
