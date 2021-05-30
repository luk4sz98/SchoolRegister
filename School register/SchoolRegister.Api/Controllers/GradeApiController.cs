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
    public class GradeApiController : BaseApiController
    {
        private readonly IGradeService _gradeService;
        private readonly UserManager<User> _userManager;
        public GradeApiController(ILogger logger, IMapper mapper,
        IGradeService gradeService,
        UserManager<User> userManager) : base(logger, mapper)
        {
            _gradeService = gradeService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Post([FromBody] AddGradeToStudentVm addGradeToStudentVm)
        {
            try
            {
                if (!ModelState.IsValid || ModelState == null)
                    return BadRequest(ModelState);
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                addGradeToStudentVm.TeacherId = user.Id;
                var gradeVm = await _gradeService.AddGradeToStudentAsync(addGradeToStudentVm);
                return Ok(gradeVm);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest("Error occurred");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Teacher, Student, Parent")]
        public async Task<IActionResult> Get([FromBody] GetGradesReportVm getGradesReportVm)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                if (await _userManager.IsInRoleAsync(user, "Parent") || await _userManager.IsInRoleAsync(user, "Teacher") || await _userManager.IsInRoleAsync(user, "Student"))
                    return Ok(await _gradeService.GetGradesReportForStudentAsync(getGradesReportVm));
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
    }
}
