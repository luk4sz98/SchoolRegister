using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Xunit;

namespace SchoolRegister.Tests.UnitTests
{
    public class StudentServiceUnitTests : BaseUnitTests
    {
        private readonly IStudentService _studentService;
        public StudentServiceUnitTests(ApplicationDbContext dbContext, IStudentService studentService) : base(dbContext)
        {
            _studentService = studentService;
        }

        [Fact]
        public async void GetStudent()
        {
            var student = await _studentService.GetStudentAsync(s => s.Id == 8);
            Assert.NotNull(student);
        }

        [Fact]
        public void GetStudents()
        {
            var students = _studentService.GetStudents(s => s.Id >= 5 && s.Id <= 7);
            Assert.NotNull(students);
            Assert.NotEmpty(students);
            Assert.Equal(3, students.Count());
        }

        [Fact]
        public void GetAllStudents()
        {
            var students = _studentService.GetStudents();
            Assert.NotNull(students);
            Assert.NotEmpty(students);
            Assert.Equal(6, students.Count());
        }
    }
}