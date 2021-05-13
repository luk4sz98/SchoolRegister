using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        Task<GroupVm> AddOrUpdateGroupAsync(AddOrUpdateGroupVm addOrRemoveGroupVm);
        Task<bool> RemoveGroupAsync(int primaryKey);
        Task<GroupVm> GetGroupAsync(Expression<Func<Group, bool>> filterExpressions);

        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterExpressions = null);

        Task<StudentVm> AttachStudentToGroupVmAsync(AttachStudentToGroupVm attachStudentToGroup);

        Task<bool> RemoveStudentFromGroupAsync(AttachStudentToGroupVm attachStudentToGroup);
        Task AttachSubjectToGroupAsync(AttachDetachSubjectGroupVm attachDetachSubjectToGroup);

        Task<bool> RemoveSubjectFromGroupAsync(AttachDetachSubjectGroupVm attachDetachSubjectToGroup);
    }
}