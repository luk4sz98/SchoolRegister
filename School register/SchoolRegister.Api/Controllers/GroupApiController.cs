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
    [Authorize(Roles = "Student, Teacher, Admin")]
    public class GroupApiController : BaseApiController
    {
        private readonly IGroupService _groupService;
        private readonly ISubjectService _subjectService;
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;
        public GroupApiController(ILogger logger, IMapper mapper, IGroupService groupService, ISubjectService subjectService, UserManager<User> userManager, IStudentService studentService) : base(logger, mapper)
        {
            _groupService = groupService;
            _subjectService = subjectService;
            _userManager = userManager;
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                if (await _userManager.IsInRoleAsync(user, "Admin") ||
                await _userManager.IsInRoleAsync(user, "Teacher"))
                    return Ok(_groupService.GetGroups());
                else if (await _userManager.IsInRoleAsync(user, "Student"))
                {
                    if (user is Student student)
                        return Ok(await _studentService.GetStudentAsync(s => s.Id == student.Id));
                    else
                        return BadRequest("Error occurred");
                }
                else
                    return BadRequest("Error occurred");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest("Error occurred");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                if (await _userManager.IsInRoleAsync(user, "Admin") || await _userManager.IsInRoleAsync(user, "Teacher"))
                    return Ok(await _groupService.GetGroupAsync(s => s.Id == id));
                else if (await _userManager.IsInRoleAsync(user, "Student"))
                {
                    if (user is Student student)
                        return Ok(await _studentService.GetStudentAsync(s => s.Id == student.Id));
                    else
                        return BadRequest("Error occurred");
                }
                else
                    return BadRequest("Error occurred");
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            return await PostOrPutGroup(addOrUpdateGroupVm);
        }




        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _groupService.RemoveGroupAsync(id);
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


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            return await PostOrPutGroup(addOrUpdateGroupVm);
        }


        private async Task<IActionResult> PostOrPutGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            try
            {
                if (ModelState == null || !ModelState.IsValid)
                    return BadRequest(ModelState);
                var subjectVm = await _groupService.AddOrUpdateGroupAsync(addOrUpdateGroupVm);
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
