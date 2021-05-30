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
    public class SubjectGroupApiController : BaseApiController
    {
        private readonly IGroupService _groupService;
        private readonly UserManager<User> _userManager;
        public SubjectGroupApiController(ILogger logger, IMapper mapper,
        IGroupService groupService, UserManager<User> userManagersubjectService,
        UserManager<User> userManager) : base(logger, mapper)
        {
            _groupService = groupService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
        {
            try
            {
                if (ModelState == null || !ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = await _groupService.AttachSubjectToGroupAsync(attachDetachSubjectGroupVm);
                return Ok(new { success = result });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest("Error occurred");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
        {
            try
            {
                var result = await _groupService.RemoveSubjectFromGroupAsync(attachDetachSubjectGroupVm);
                return Ok(new { success = result });
            }
            catch (ArgumentNullException ane)
            {
                Logger.LogError(ane, ane.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest("Error occurred");
            }
        }

    }
}
