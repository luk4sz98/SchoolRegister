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
    [Authorize(Roles = "Teacher, Admin, Student, Parent")]
    public class StudentApiController : BaseApiController
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;
        private readonly UserManager<User> _userManager;
        public StudentApiController(ILogger logger, IMapper mapper,
        IStudentService studentService,IGroupService groupService,
        UserManager<User> userManager) : base(logger, mapper)
        {
            _studentService = studentService;
            _groupService = groupService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                if (await _userManager.IsInRoleAsync(user, "Admin") || await _userManager.IsInRoleAsync(user, "Teacher"))
                    return Ok(_studentService.GetStudents());
                else if (await _userManager.IsInRoleAsync(user, "Student"))
                {
                    if (user is Student student)
                        return Ok(await _studentService.GetStudentAsync(x => x.Id == student.Id));
                    return BadRequest("Student is assigned to role, but not to the student type.");
                }
                else if (await _userManager.IsInRoleAsync(user, "Parent"))
                {
                    if (user is Parent parent)
                        return Ok(_studentService.GetStudents(s => s.ParentId == user.Id));
                    return BadRequest("Parent is assigned to role, but not to the parent type.");
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
                if (await _userManager.IsInRoleAsync(user, "Admin") || await _userManager.IsInRoleAsync(user, "Teacher") || await _userManager.IsInRoleAsync(user, "Parent"))
                    return Ok(await _studentService.GetStudentAsync(s => s.Id == id));
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

        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _studentService.RemoveStudentAsync(id);
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

        [HttpDelete]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> DetachStudentFromGroup(AttachStudentToGroupVm attachStudentToGroupVm)
        {
            try
            {
                var result = await _groupService.RemoveStudentFromGroupAsync(attachStudentToGroupVm);
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

        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> AttachStudentFromGroup(AttachStudentToGroupVm attachStudentToGroupVm)
        {
            try
            {
                if (ModelState == null || !ModelState.IsValid)
                    return BadRequest(ModelState);
                var studentVm = await _groupService.AttachStudentToGroupVmAsync(attachStudentToGroupVm);
                return Ok(studentVm);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest("Error occurred");
            }
        }
    }
}
