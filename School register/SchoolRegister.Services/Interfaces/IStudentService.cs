using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentVm> GetStudentAsync(Expression<Func<Student, bool>> filterExpressions);

        IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterExpressions = null);

        Task<bool> RemoveStudentAsync(int studentId);
    }
}