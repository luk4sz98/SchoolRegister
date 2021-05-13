
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectVm> AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm);
        Task<SubjectVm> GetSubjectAsync(Expression<Func<Subject, bool>> filterExpressions);
        IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterExpressions = null);

        Task<SubjectVm> AttachTeacherToSubjectAsync(AttachDetachTeacherToSubjectVm attachToTeacherVm);
        Task<SubjectVm> DetachTeacherFromSubjectAsync(AttachDetachTeacherToSubjectVm attachToTeacherVm);

        Task<bool> RemoveSubjectAsync(int groupId);

    }
}