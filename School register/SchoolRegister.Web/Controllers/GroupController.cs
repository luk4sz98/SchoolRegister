

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Web.Controllers
{
    [Authorize(Roles = "Teacher, Admin, Student")]
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly ISubjectService _subjectService;
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;
        public GroupController(ILogger logger, IMapper mapper, IStringLocalizer localizer, IGroupService groupService, ISubjectService subjectService, UserManager<User> userManager, IStudentService studentService) : base(logger, mapper, localizer)
        {
            _groupService = groupService;
            _subjectService = subjectService;
            _userManager = userManager;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (_userManager.IsInRoleAsync(user, "Admin").Result || _userManager.IsInRoleAsync(user, "Teacher").Result)
                return View(_groupService.GetGroups());
            else if (_userManager.IsInRoleAsync(user, "Student").Result)
                return RedirectToAction("Details", "Student", new { studentId = user.Id });
            else
                return View("Error");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrEditGroup(int? id = null)
        {
            if (id.HasValue)
            {
                var groupVm = await _groupService.GetGroupAsync(x => x.Id == id);
                ViewBag.ActionType = Localizer["EditGroup"];
                return View(Mapper.Map<AddOrUpdateGroupVm>(groupVm));
            }
            ViewBag.ActionType = Localizer["AddGroup"];
            return View();

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrEditGroup(AddOrUpdateGroupVm model)
        {
            if (ModelState.IsValid)
            {
                await _groupService.AddOrUpdateGroupAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AttachSubjectToGroup(int subjectId)
        {
            var groups = _groupService.GetGroups();

            ViewBag.Subject = await _subjectService.GetSubjectAsync(i => i.Id == subjectId);
            IEnumerable<GroupVm> subjectGroup = ViewBag.Subject.Groups;
            var groupsDifference = groups.Where(x => !subjectGroup.Any(s => x.Id == s.Id)).ToList();

            ViewBag.GroupsSelectList = new SelectList(groupsDifference.Select(g => new
            {
                Text = $"{g.Name}",
                Value = g.Id
            }), "Value", "Text");

            return View();
        }

        public async Task<IActionResult> Details(int groupId)
        {
            var groupVm = await _groupService.GetGroupAsync(x => x.Id == groupId);
            return View(groupVm);

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetIdToDelete(int groupId)
        {
            ViewBag.Id = groupId;
            return PartialView();
        }

        [HttpPost, ActionName("GetIdToDelete")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int groupId)
        {
            await _groupService.RemoveGroupAsync(groupId);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AttachSubjectToGroup(int subjectId, string groupName)
        {
            if (ModelState.IsValid)
            {
                var model = new AttachDetachSubjectGroupVm
                {
                    SubjectId = subjectId,
                    GroupId = Convert.ToInt32(groupName)
                };
                await _groupService.AttachSubjectToGroupAsync(model);
                return RedirectToAction("Index", "Subject");
            }
            return View();

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DetachSubjectFromGroup(int subjectId)
        {
            var groups = _groupService.GetGroups();

            ViewBag.Subject = await _subjectService.GetSubjectAsync(i => i.Id == subjectId);
            IEnumerable<GroupVm> subjectGroup = ViewBag.Subject.Groups;

            ViewBag.GroupsSelectList = new SelectList(subjectGroup.Select(g => new
            {
                Text = $"{g.Name}",
                Value = g.Id
            }), "Value", "Text");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DetachSubjectFromGroup(int subjectId, string groupName)
        {
            if (ModelState.IsValid)
            {
                var model = new AttachDetachSubjectGroupVm
                {
                    SubjectId = subjectId,
                    GroupId = Convert.ToInt32(groupName)
                };
                await _groupService.RemoveSubjectFromGroupAsync(model);
                return RedirectToAction("Index", "Subject");
            }
            return View();

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AttachStudentToGroup(int studentId)
        {
            var groups = _groupService.GetGroups();
            ViewBag.Student = await _studentService.GetStudentAsync(s => s.Id == studentId);

            var studentGroup = ViewBag.Student.Group;
            var groupsDifference = studentGroup == null ? groups : groups.Where(x => x.Id != studentGroup.Id && x.Name != studentGroup.Name);

            ViewBag.GroupsSelectList = new SelectList(groupsDifference.Select(g => new
            {
                Text = $"{g.Name}",
                Value = g.Id
            }), "Value", "Text");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AttachStudentToGroup(int studentId, string groupName)
        {
            if (ModelState.IsValid)
            {
                var model = new AttachStudentToGroupVm
                {
                    Id = studentId,
                    GroupId = Convert.ToInt32(groupName)
                };
                await _groupService.AttachStudentToGroupVmAsync(model);
                return RedirectToAction("Index", "Student");
            }
            return View();

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DetachStudentFromGroup(int studentId)
        {
            ViewBag.Student = await _studentService.GetStudentAsync(s => s.Id == studentId);
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DetachStudentFromGroup(int studentId, string groupName)
        {
            if (ModelState.IsValid)
            {
                var model = new AttachStudentToGroupVm
                {
                    Id = studentId,
                    GroupId = Convert.ToInt32(groupName),
                };
                await _groupService.RemoveStudentFromGroupAsync(model);
                return RedirectToAction("Index", "Student");

            }
            return View();
        }

    }
}