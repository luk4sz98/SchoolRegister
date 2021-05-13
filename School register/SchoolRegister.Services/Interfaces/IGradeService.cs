
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeVm>> GetGradesReportForStudentAsync(GetGradesReportVm getGradesReportVm);
        Task<GradeVm> AddGradeToStudentAsync(AddGradeToStudentVm addGradeToStudent);
    }
}