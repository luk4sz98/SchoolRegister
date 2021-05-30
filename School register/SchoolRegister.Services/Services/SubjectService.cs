
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.DataModels;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SchoolRegister.Services.Services
{
    public class SubjectService : BaseService, ISubjectService
    {
        public SubjectService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger, userManager)
        {
        }

        public async Task<SubjectVm> AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm)
        {
            try
            {
                if (addOrUpdateVm == null)
                    throw new ArgumentNullException($"{addOrUpdateVm} is null");

                var subjectEntity = Mapper.Map<Subject>(addOrUpdateVm);

                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                {
                    //subjectEntity.Id = DbContext.Subject.Max(i => i.Id) + 1;
                    await DbContext.Subject.AddAsync(subjectEntity);
                }

                else
                {
                    var subjectToUpdate = await DbContext.Subject.FirstOrDefaultAsync(s => s.Id == addOrUpdateVm.Id);
                    subjectToUpdate.Description = addOrUpdateVm.Description;
                    subjectToUpdate.Name = addOrUpdateVm.Name;
                    subjectToUpdate.TeacherId = addOrUpdateVm.TeacherId;
                }
                await DbContext.SaveChangesAsync();

                var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task<SubjectVm> AttachTeacherToSubjectAsync(AttachDetachTeacherToSubjectVm attachToTeacherVm)
        {
            try
            {
                if (attachToTeacherVm == null)
                    throw new ArgumentNullException($"{attachToTeacherVm} is null");

                var subjectEntity = await DbContext.Subject.FirstOrDefaultAsync(s => s.Id == attachToTeacherVm.SubjectId);

                if (subjectEntity == null)
                    throw new ArgumentException($"There is no subject with {attachToTeacherVm.SubjectId}-id.");

                subjectEntity.TeacherId = attachToTeacherVm.TeacherId;
                await DbContext.SaveChangesAsync();

                return Mapper.Map<SubjectVm>(subjectEntity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task<SubjectVm> DetachTeacherFromSubjectAsync(AttachDetachTeacherToSubjectVm attachToTeacherVm)
        {
            try
            {
                if (attachToTeacherVm == null)
                    throw new ArgumentNullException($"{attachToTeacherVm} is null");

                var subjectEntity = await DbContext.Subject.FirstOrDefaultAsync(s => s.Id == attachToTeacherVm.SubjectId);

                if (subjectEntity == null)
                    throw new ArgumentException($"There is no subject with {attachToTeacherVm.SubjectId}-id.");

                subjectEntity.TeacherId = null;
                await DbContext.SaveChangesAsync();

                return Mapper.Map<SubjectVm>(subjectEntity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<SubjectVm> GetSubjectAsync(Expression<Func<Subject, bool>> filterExpressions)
        {
            try
            {
                if (filterExpressions == null)
                    throw new ArgumentNullException($"{filterExpressions} is null.");

                var subjectEntity = await DbContext.Subject.FirstOrDefaultAsync(filterExpressions);
                var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterExpressions = null)
        {
            try
            {
                var subjectEntities = DbContext.Subject.AsQueryable();
                if (filterExpressions != null)
                    subjectEntities = subjectEntities.Where(filterExpressions);
                var subjectVms = Mapper.Map<IEnumerable<SubjectVm>>(subjectEntities);
                return subjectVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> RemoveSubjectAsync(int subjectId)
        {
            try
            {
                var subjectEntity = await DbContext.Subject.FindAsync(subjectId);
                if (subjectEntity != null)
                {
                    DbContext.Subject.Remove(subjectEntity);
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentNullException($"Subject with id {subjectId} not found");

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}