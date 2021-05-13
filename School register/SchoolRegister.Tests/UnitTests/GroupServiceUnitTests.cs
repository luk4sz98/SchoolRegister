using System;
using System.Linq;
using SchoolRegister.DAL.EF;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegister.Tests.UnitTests
{
    public class GroupServiceUnitTests : BaseUnitTests
    {
        private readonly IGroupService _groupService;
        public GroupServiceUnitTests(ApplicationDbContext dbContext, IGroupService groupService) : base(dbContext)
        {
            _groupService = groupService;
        }


        [Fact]
        public async void AddNewGroupCorrectly()
        {
            var groupVm = new AddOrUpdateGroupVm()
            {
                Name = "Nowa grupa"
            };

            var expected = DbContext.Group.Count(); //ilość aktualna grup
            var newGroup = await _groupService.AddOrUpdateGroupAsync(groupVm);
            Assert.NotNull(newGroup);
            Assert.Equal(expected + 1, DbContext.Group.Count());

        }

        [Fact]
        public async void UpdateGroupCorrectly()
        {
            var groupVm = new AddOrUpdateGroupVm()
            {
                Id = 1,
                Name = "Grupa testowa"
            };
            var group = await _groupService.AddOrUpdateGroupAsync(groupVm);

            Assert.Equal(group.Name, groupVm.Name);
        }

        [Fact]
        public async void AddOrUpdateGroupThrowNull()
        {
            AddOrUpdateGroupVm groupVm = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _groupService.AddOrUpdateGroupAsync(groupVm));

        }

        [Fact]
        public async void RemoveGroupAsync()
        {
            int groupIdToRemove = 3;
            var expected = DbContext.Group.Count();
            var result = await _groupService.RemoveGroupAsync(groupIdToRemove);
            Assert.True(result);
            Assert.Equal(expected - 1, DbContext.Group.Count());
        }

        [Fact]
        public async void RemoveGroupAsyncNonExistGroup()
        {
            int groupIdToRemove = DbContext.Group.Max(g => g.Id) + 1;
            Func<Task<bool>> act = async () => await _groupService.RemoveGroupAsync(groupIdToRemove);
            await Assert.ThrowsAsync<ArgumentNullException>(act);

        }

        [Fact]
        public async void GetGroupAsync()
        {
            var groupName = "PAI";
            Assert.NotNull(await _groupService.GetGroupAsync(g => g.Name == groupName));
        }

        [Fact]
        public void GetGroups()
        {
            int groupFiltr = 1;
            Assert.NotNull(_groupService.GetGroups(g => g.Id <= groupFiltr));
        }

        [Fact]
        public async void GetGroupAsyncNullExpression()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _groupService.GetGroupAsync(null));
        }

        [Fact]
        public void GetAllGroups()
        {
            var groups = _groupService.GetGroups();
            Assert.NotNull(groups);
            Assert.NotEmpty(groups);
            Assert.Equal(3, groups.Count());
        }
        [Fact]
        public async void AttachStudentToGroupAsync()
        {
            var attachStudentToGroup = new AttachStudentToGroupVm
            {
                Id = 5,
                GroupId = 2
            };

            var studentVm = await _groupService.AttachStudentToGroupVmAsync(attachStudentToGroup);

            Assert.NotNull(studentVm);
            Assert.Equal(2, studentVm.GroupId);

        }

        [Fact]
        public async void RemoveStudentFromGroupAsync()
        {
            int studentId = 5;
            var model = new AttachStudentToGroupVm { Id = studentId };
            var result = await _groupService.RemoveStudentFromGroupAsync(model);

            var studentVm = await DbContext.Users.OfType<Student>().FirstOrDefaultAsync(x => x.Id == studentId);

            Assert.True(result);
            Assert.Null(studentVm.GroupId);
            Assert.Null(studentVm.Group);
        }

        [Fact]
        public async void RemoveStudentFromGroupAsyncIdLessThanZero()
        {
            int studentId = -5;
            var model = new AttachStudentToGroupVm { Id = studentId };
            await Assert.ThrowsAsync<ArgumentException>(async () => await _groupService.RemoveStudentFromGroupAsync(model));
        }
        [Fact]
        public async void RemoveStudentFromGroupAsyncNonExistentStudent()
        {
            int studentId = 20;
            var model = new AttachStudentToGroupVm { Id = studentId };
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _groupService.RemoveStudentFromGroupAsync(model));
        }

        [Fact]
        public async void AttachStudentToGroupAsyncNullVm()
        {
            AttachStudentToGroupVm attachStudentToGroup = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _groupService.AttachStudentToGroupVmAsync(attachStudentToGroup));
        }
        [Fact]
        public async void AttachStudentToGroupAsyncNonExistentStudent()
        {
            var attachStudentToGroup = new AttachStudentToGroupVm
            {
                Id = 20,
                GroupId = 3
            };
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _groupService.AttachStudentToGroupVmAsync(attachStudentToGroup));
        }

        [Fact]
        public async void AttachSubjectToGroup()
        {
            var attachSubjectGroupVm = new AttachDetachSubjectGroupVm()
            {
                GroupId = 1,
                SubjectId = 4
            };
            await _groupService.AttachSubjectToGroupAsync(attachSubjectGroupVm);
            var group = await _groupService.GetGroupAsync(g => g.Id == attachSubjectGroupVm.GroupId);
            Assert.NotNull(group);
            Assert.NotNull(group.Subjects.FirstOrDefault(s => s.Name == "Administracja Intenetowymi Systemami Baz Danych"));

        }

        [Fact]
        public async void DetachSubjectFromGroup()
        {
            var detachSubjectGroupVm = new AttachDetachSubjectGroupVm()
            {
                GroupId = 2,
                SubjectId = 4
            };
            var result = await _groupService.RemoveSubjectFromGroupAsync(detachSubjectGroupVm);
            var group = await _groupService.GetGroupAsync(g => g.Id == detachSubjectGroupVm.GroupId);
            Assert.True(result);
            Assert.NotNull(group);
            Assert.Null(group.Subjects.FirstOrDefault(s => s.Name == "Administracja Intenetowymi Systemami Baz Danych"));
        }

    }
}