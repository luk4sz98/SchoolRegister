using System.Linq;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using Xunit;
using System.Threading.Tasks;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Tests.UnitTests
{
    public class SubjectServiceUnitTests : BaseUnitTests
    {
        private readonly ISubjectService _subjectService;
        public SubjectServiceUnitTests(ApplicationDbContext dbContext, ISubjectService subjectService) : base(dbContext)
        {
            _subjectService = subjectService;
        }

        [Fact]
        public async void GetSubjectAsync()
        {
            var subject = await _subjectService.GetSubjectAsync(x => x.Name == "Programowanie obiektowe");
            Assert.NotNull(subject);
        }

        [Fact]
        public void GetSubjects()
        {
            var subjects = _subjectService.GetSubjects(x => x.Id > 2 && x.Id <= 4);
            Assert.NotNull(subjects);
            Assert.NotEmpty(subjects);
            Assert.Equal(2, subjects.Count());
        }

        [Fact]
        public void GetAllSubjects()
        {
            var subjects = _subjectService.GetSubjects();
            Assert.NotNull(subjects);
            Assert.NotEmpty(subjects);
            Assert.Equal(DbContext.Subject.Count(), subjects.Count());
        }
        [Fact]
        public async void AddNewSubject()
        {
            var newSubjectVm = new AddOrUpdateSubjectVm()
            {
                Name = "Zaawansowane programowanie internetowe",
                Description = "W ramach przedmiotu studenci tworzą rozwiazania w bibliotekach SPA",
                TeacherId = 1
            };
            var createdSubject = await _subjectService.AddOrUpdateSubject(newSubjectVm);
            Assert.NotNull(createdSubject);
            Assert.Equal("Zaawansowane programowanie internetowe", createdSubject.Name);
        }

        [Fact]
        public async void EditSubject()
        {
            var editSubjectVm = new AddOrUpdateSubjectVm()
            {
                Id = 1,
                Name = "Aplikacje webowe",
                Description = null,
                TeacherId = 1
            };
            var editedSubjectVm = await _subjectService.AddOrUpdateSubject(editSubjectVm);
            Assert.NotNull(editedSubjectVm);
            Assert.Equal("Aplikacje webowe", editedSubjectVm.Name);
            Assert.Null(editedSubjectVm.Description);

        }

        [Fact]
        public async void AttachTeacherToSubject()
        {
            var attachSubjectTeacher = new AttachDetachTeacherToSubjectVm()
            {
                SubjectId = 5,
                TeacherId = 2
            };
            var subject = await _subjectService.AttachTeacherToSubjectAsync(attachSubjectTeacher);
            Assert.NotNull(subject);
            Assert.True(subject.TeacherId == attachSubjectTeacher.TeacherId);
        }

        [Fact]
        public async void DetachTeacherToSubject()
        {
            var detachSubjectTeacher = new AttachDetachTeacherToSubjectVm()
            {
                SubjectId = 3,
                TeacherId = 2
            };
            var subject = await _subjectService.DetachTeacherFromSubjectAsync(detachSubjectTeacher);
            Assert.NotNull(subject);
            Assert.Null(subject.TeacherId);
            Assert.Null(subject.TeacherName);
        }
        [Fact]
        public async void RemoveSubjectAsync()
        {
            int subjectIdToRemove = 2;
            var expected = DbContext.Subject.Count();
            var result = await _subjectService.RemoveSubjectAsync(subjectIdToRemove);
            Assert.True(result);
            Assert.Equal(expected - 1, DbContext.Subject.Count());
        }
    }
}