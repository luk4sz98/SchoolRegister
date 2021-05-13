using System;
using System.Linq;
using SchoolRegister.DAL.EF;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Xunit;
using SchoolRegister.Services.Services;

namespace SchoolRegister.Tests.UnitTests
{
    public class TeacherServiceUnitTests : BaseUnitTests
    {
        private readonly ITeacherService _teacherService;
        public TeacherServiceUnitTests(ApplicationDbContext dbContext, ITeacherService teacherService) : base(dbContext)
        {
            _teacherService = teacherService;
        }

        [Fact]
        public async void GetTeacher()
        {
            var teacher = await _teacherService.GetTeacherAsync(x => x.UserName == "t1@eg.eg");
            Assert.NotNull(teacher);
        }

        [Fact]
        public void GetTeachers()
        {
            var teachers = _teacherService.GetTeachers(x => x.Title.Contains("inż."));
            Assert.NotNull(teachers);
            Assert.NotEmpty(teachers);
            Assert.Equal(2, teachers.Count());
        }

        [Fact]
        public void GetAllTeachers()
        {
            var teachers = _teacherService.GetTeachers();
            Assert.NotNull(teachers);
            Assert.NotEmpty(teachers);

        }

    }
}