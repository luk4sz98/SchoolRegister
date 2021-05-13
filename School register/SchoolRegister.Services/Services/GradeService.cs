
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Services
{
    public class GradeService : BaseService, IGradeService
    {
        public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger, userManager)
        {
        }

        public async Task<IEnumerable<GradeVm>> GetGradesReportForStudentAsync(GetGradesReportVm getGradesReportVm)
        {
            try
            {
                if (getGradesReportVm == null)
                    throw new ArgumentNullException("You must provide both parameters");

                var userEntity = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == getGradesReportVm.GetterUserId);
                if (userEntity == null)
                    throw new ArgumentException($"There is no user with id {getGradesReportVm.GetterUserId}.");

                if (!await UserManager.IsInRoleAsync(userEntity, "Student") && !await UserManager.IsInRoleAsync(userEntity, "Parent") && !await UserManager.IsInRoleAsync(userEntity, "Teacher"))
                    throw new UnauthorizedAccessException($"Current user does not have permission to see {getGradesReportVm.StudentId}-id student grades.");

                var gradesReportVm = await DbContext.Grades.Where(g => g.StudentId == getGradesReportVm.StudentId).ToListAsync();
                if (gradesReportVm == null || gradesReportVm.Count == 0)
                    throw new ArgumentNullException($"Student with {getGradesReportVm.StudentId} id does not exist or has no any grades.");

                return Mapper.Map<IEnumerable<Grade>, IEnumerable<GradeVm>>(gradesReportVm);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task<GradeVm> AddGradeToStudentAsync(AddGradeToStudentVm addGradeToStudent)
        {
            try
            {
                if (addGradeToStudent == null)
                    throw new ArgumentNullException("Grade can not be null");

                var teacherEntity = await DbContext.Users.FirstOrDefaultAsync(t => t.Id == addGradeToStudent.TeacherId);

                var studentEntity = await DbContext.Users.FirstOrDefaultAsync(s => s.Id == addGradeToStudent.StudentId);

                if (teacherEntity == null || studentEntity == null)
                    throw new ArgumentException($"There is no user with id {addGradeToStudent.StudentId} or {addGradeToStudent.TeacherId}.");

                if (!await UserManager.IsInRoleAsync(teacherEntity, "Teacher"))
                    throw new UnauthorizedAccessException("Only teacher are allowed to add a grade to student.");

                var grade = Mapper.Map<Grade>(addGradeToStudent);
                await DbContext.Grades.AddAsync(grade);
                await DbContext.SaveChangesAsync();

                var gradeVm = Mapper.Map<GradeVm>(grade);
                return gradeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /*         public async Task<IEnumerable<GradeVm>> GetGradesByStudent(GetGradesReportVm getGradesReportVm)
             {
                 try
                 {
                     if (getGradesReportVm.GetterUserId != getGradesReportVm.StudentId)
                         throw new ArgumentException("You can only see your grades");

                     var student = await DbContext.Users.OfType<Student>().FirstOrDefaultAsync(s => s.Id == getGradesReportVm.StudentId);

                     if (student == null)
                         throw new ArgumentNullException("Student is null");

                     if (!UserManager.IsInRoleAsync(student, "Student").Result)
                         throw new ArgumentException("User is not student");

                     var studentGradesVm = new List<GradeVm>();
                     foreach (var grade in student.Grades)
                     {
                         studentGradesVm.Add(Mapper.Map<GradeVm>(grade));
                     }

                     return studentGradesVm;
                 }
                 catch (Exception ex)
                 {
                     Logger.LogError(ex, ex.Message);
                     throw;
                 }
             }

             public IEnumerable<GradeVm> GetGradesByParent(GetGradesReportVm getGradesReportVm)
             {
                 try
                 {
                     var parent = DbContext.Users.OfType<Parent>().FirstOrDefault(s => s.Id == getGradesReportVm.GetterUserId);

                     if (parent == null)
                         throw new ArgumentNullException("Parent is null");

                     if (!UserManager.IsInRoleAsync(parent, "Parent").Result)
                         throw new ArgumentException("User is not parent");

                     var studentsGrades = new List<GradeVm>();

                     //Jeśli nie ma podanego id studenta, to rodzic uzyskuje oceny wszystkich swoich dzieci
                     if (getGradesReportVm.StudentId == null)
                     {
                         foreach (var student in parent.Students)
                         {
                             foreach (var grade in student.Grades)
                             {
                                 studentsGrades.Add(Mapper.Map<GradeVm>(grade));
                             }
                         }
                     }
                     else
                     {
                         var parentStudent = parent.Students.FirstOrDefault(s => s.Id == getGradesReportVm.StudentId);
                         if (parentStudent == null)
                             throw new ArgumentNullException("parent can only see their child's grades");

                         foreach (var grade in parentStudent.Grades)
                         {
                             studentsGrades.Add(Mapper.Map<GradeVm>(grade));
                         }
                     }



                     return studentsGrades;

                 }
                 catch (Exception ex)
                 {
                     Logger.LogError(ex, ex.Message);
                     throw;
                 }
             }

             public GradeVm AddGradeToStudent(AddGradeToStudent addGradeToStudent)
             {
                 try
                 {
                     if (addGradeToStudent == null)
                         throw new ArgumentNullException("Grade can not be null");

                     var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudent.TeacherId);

                     var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == addGradeToStudent.StudentId);

                     if (teacher == null || student == null)
                         throw new ArgumentNullException("Student or teacher can not be null");

                     var grade = Mapper.Map<Grade>(addGradeToStudent);
                     DbContext.Grades.Add(grade);
                     DbContext.SaveChanges();

                     var gradeVm = Mapper.Map<GradeVm>(grade);
                     return gradeVm;
                 }
                 catch (Exception ex)
                 {
                     Logger.LogError(ex, ex.Message);
                     throw;
                 }

             }

             public IEnumerable<GradeVm> GetGradesByTeacher(GetGradesReportVm getGradesReportVm)
             {
                 try
                 {
                     if (getGradesReportVm == null)
                         throw new ArgumentNullException("Id is required for GetGradesReport");

                     var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == getGradesReportVm.GetterUserId);
                     var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == getGradesReportVm.StudentId);

                     if (teacher == null || student == null)
                         throw new ArgumentNullException("User can not be null");

                     var studentGrades = new List<GradeVm>();

                     foreach (var grade in student.Grades)
                     {
                         studentGrades.Add(Mapper.Map<GradeVm>(grade));
                     }

                     return studentGrades;
                 }
                 catch (Exception ex)
                 {
                     Logger.LogError(ex, ex.Message);
                     throw;
                 }
             }
         } */
    }
}