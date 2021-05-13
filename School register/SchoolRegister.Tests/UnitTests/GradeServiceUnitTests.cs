using System;
using System.Linq;
using SchoolRegister.DAL.EF;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SchoolRegister.Tests.UnitTests
{
    public class GradeServiceUnitTests : BaseUnitTests
    {
        private readonly IGradeService _gradeService;
        public GradeServiceUnitTests(ApplicationDbContext dbContext, IGradeService gradeService) : base(dbContext)
        {
            _gradeService = gradeService;
        }


        [Fact]
        public async void GetGradesReportForStudentByTeacher()
        {
            var getGradesReportForStudentVm = new GetGradesReportVm()
            {
                StudentId = 5,
                GetterUserId = 1
            };

            var gradesReport = await _gradeService.GetGradesReportForStudentAsync(getGradesReportForStudentVm);
            Assert.NotNull(gradesReport);
        }

        [Fact]
        public async void GetGradesReportForStudentByStudent()
        {
            var getGradesReportForStudentVm = new GetGradesReportVm()
            {
                StudentId = 5,
                GetterUserId = 5
            };

            var gradesReport = await _gradeService.GetGradesReportForStudentAsync(getGradesReportForStudentVm);
            Assert.NotNull(gradesReport);
        }

        [Fact]
        public async void GetGradesReportForStudentByParent()
        {
            var getGradesReportForStudentVm = new GetGradesReportVm()
            {
                StudentId = 5,
                GetterUserId = 3
            };

            var gradesReport = await _gradeService.GetGradesReportForStudentAsync(getGradesReportForStudentVm);
            Assert.NotNull(gradesReport);
        }

        [Fact]
        public async void GetGradesReportForStudentNullVm()
        {
            GetGradesReportVm getGradesReport = null;

            //await Assert.ThrowsAsync<ArgumentNullException>(async () => await _gradeService.GetGradesReportForStudentAsync(getGradesReport));

            //albo u góry albo skorzystanie z delegata

            Func<Task<IEnumerable<GradeVm>>> act = async () => await _gradeService.GetGradesReportForStudentAsync(getGradesReport);
            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public async void GetGradesReportForStudentWithNoPermissions()
        {
            var getGradesReportForStudentVm = new GetGradesReportVm()
            {
                StudentId = 5,
                GetterUserId = 11
            };

            Func<Task<IEnumerable<GradeVm>>> act = async () => await _gradeService.GetGradesReportForStudentAsync(getGradesReportForStudentVm);
            await Assert.ThrowsAsync<UnauthorizedAccessException>(act);
        }

        [Fact]
        public async void GetGradesReportForStudentNonExistentUser()
        {
            var getGradesReportForStudentVm = new GetGradesReportVm()
            {
                StudentId = 15,
                GetterUserId = 2
            };

            Func<Task<IEnumerable<GradeVm>>> act = async () => await _gradeService.GetGradesReportForStudentAsync(getGradesReportForStudentVm);
            await Assert.ThrowsAsync<ArgumentException>(act);
        }

        [Fact]
        public async void GetGradesReportForStudentNoGrades()
        {
            var getGradesReportForStudentVm = new GetGradesReportVm()
            {
                StudentId = 3,
                GetterUserId = 1
            };

            Func<Task<IEnumerable<GradeVm>>> act = async () => await _gradeService.GetGradesReportForStudentAsync(getGradesReportForStudentVm);
            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public async void AddGradeToStudent()
        {
            var gradeVm = new AddGradeToStudentVm()
            {
                StudentId = 5,
                SubjectId = 1,
                GradeValue = GradeScale.DB,
                TeacherId = 1,
            };

            var grade = await _gradeService.AddGradeToStudentAsync(gradeVm);
            Assert.NotNull(grade);
            Assert.Equal(2, DbContext.Grades.Count());
        }
    }
}