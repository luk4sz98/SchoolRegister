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
    public class SubjectApiController : BaseApiController
    {
        private readonly ISubjectService _subjectService;
        private readonly UserManager<User> _userManager;
        public SubjectApiController(ILogger logger, IMapper mapper,
        ISubjectService subjectService,
        UserManager<User> userManager) : base(logger, mapper)
        {
            _subjectService = subjectService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                    return Ok(_subjectService.GetSubjects());
                else if (await _userManager.IsInRoleAsync(user, "Teacher"))
                {
                    if (user is Teacher teacher)
                        return Ok(_subjectService.GetSubjects(x => x.TeacherId == teacher.Id));
                    return BadRequest("Teacher is assigned to role, but not to the Teacher type.");
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
                    return Ok(await _subjectService.GetSubjectAsync(s => s.Id == id));
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
        public async Task<IActionResult> Post([FromBody] AddOrUpdateSubjectVm addOrUpdateSubjectVm)
        {
            return await PostOrPutSubject(addOrUpdateSubjectVm);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromForm] AddOrUpdateSubjectVm addOrUpdateSubjectVm)
        // public IActionResult Put([FromBody] AddOrUpdateSubjectVm addOrUpdateSubjectVm, int id) // Optional Id param
        {
            return await PostOrPutSubject(addOrUpdateSubjectVm);
        }


        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _subjectService.RemoveSubjectAsync(id);
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
        // helper method
        private async Task<IActionResult> PostOrPutSubject(AddOrUpdateSubjectVm addOrUpdateSubjectVm)
        {
            try
            {
                if (ModelState == null || !ModelState.IsValid)
                    return BadRequest(ModelState);
                var subjectVm = await _subjectService.AddOrUpdateSubject(addOrUpdateSubjectVm);
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
