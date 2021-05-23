
using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SchoolRegister.Services.Services
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger, userManager)
        {
        }

        public async Task<StudentVm> GetStudentAsync(Expression<Func<Student, bool>> filterExpressions)
        {
            try
            {
                if (filterExpressions == null)
                    throw new ArgumentNullException("filterExpressions is null");

                var studentEntity = await DbContext.Users.OfType<Student>().FirstOrDefaultAsync(filterExpressions);

                var studentVm = Mapper.Map<StudentVm>(studentEntity);
                return studentVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterExpressions = null)
        {
            try
            {
                var studentEntities = DbContext.Users.OfType<Student>().AsQueryable();
                if (filterExpressions != null)
                    studentEntities = studentEntities.Where(filterExpressions);
                var studentVms = Mapper.Map<IEnumerable<StudentVm>>(studentEntities);
                return studentVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> RemoveStudentAsync(int studentId)
        {
            try
            {
                var studentEntity = await DbContext.Users.OfType<Student>().FirstOrDefaultAsync(x => x.Id == studentId);
                if (studentEntity != null)
                {
                    DbContext.Remove(studentEntity);
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentNullException($"There is no student with id {studentId}");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}