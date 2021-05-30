
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger, userManager)
        {
        }
        public async Task<bool> AttachSubjectToGroupAsync(AttachDetachSubjectGroupVm attachDetachSubjectToGroup)
        {
            try
            {
                if (attachDetachSubjectToGroup == null)
                    throw new ArgumentNullException("View model parameter is required.");

                var subjectEntity = await DbContext.Subject.FirstOrDefaultAsync(s => s.Id == attachDetachSubjectToGroup.SubjectId);

                var groupEntity = await DbContext.Group.FirstOrDefaultAsync(g => g.Id == attachDetachSubjectToGroup.GroupId);

                if (subjectEntity == null)
                    throw new ArgumentException($"There is no subject with {attachDetachSubjectToGroup.SubjectId}-id.");

                if (groupEntity == null)
                    throw new ArgumentException($"There is no group with {attachDetachSubjectToGroup.GroupId}.");

                var subjectGroupEntity = Mapper.Map<SubjectGroup>(attachDetachSubjectToGroup);

                await DbContext.SubjectGroup.AddAsync(subjectGroupEntity);
                await DbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> RemoveSubjectFromGroupAsync(AttachDetachSubjectGroupVm attachDetachSubjectToGroup)
        {
            try
            {
                if (attachDetachSubjectToGroup == null)
                    throw new ArgumentNullException($"Both parameter are required.");

                var subjectGroupEntity = await DbContext.SubjectGroup.Where(x => x.GroupId == attachDetachSubjectToGroup.GroupId && x.SubjectId == attachDetachSubjectToGroup.SubjectId).FirstOrDefaultAsync();
                if (subjectGroupEntity != null)
                {
                    DbContext.SubjectGroup.Remove(subjectGroupEntity);
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentNullException($"There is no subject group with id {attachDetachSubjectToGroup.SubjectId} and group {attachDetachSubjectToGroup.GroupId}.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<GroupVm> AddOrUpdateGroupAsync(AddOrUpdateGroupVm addOrRemoveGroupVm)
        {
            try
            {
                if (addOrRemoveGroupVm == null)
                    throw new ArgumentNullException("View model parameter is null.");

                var groupEntity = Mapper.Map<Group>(addOrRemoveGroupVm);

                if (!addOrRemoveGroupVm.Id.HasValue || addOrRemoveGroupVm.Id == 0)
                    await DbContext.Group.AddAsync(groupEntity);
                else
                {
                    var groupToUpdate = await DbContext.Group.FirstOrDefaultAsync(g => g.Id == addOrRemoveGroupVm.Id);
                    groupToUpdate.Name = addOrRemoveGroupVm.Name;
                }

                await DbContext.SaveChangesAsync();


                return Mapper.Map<GroupVm>(groupEntity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }


        public async Task<bool> RemoveGroupAsync(int primaryKey)
        {
            try
            {
                var groupEntity = await DbContext.Group.FindAsync(primaryKey);
                if (groupEntity != null)
                {
                    DbContext.Group.Remove(groupEntity);
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentNullException($"Group with id {primaryKey} not found");

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task<GroupVm> GetGroupAsync(Expression<Func<Group, bool>> filterExpressions)
        {
            try
            {
                if (filterExpressions == null)
                    throw new ArgumentNullException("filterExpressions is null");

                var groupEntity = await DbContext.Group.FirstOrDefaultAsync(filterExpressions);

                var groupVm = Mapper.Map<GroupVm>(groupEntity);

                return groupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterExpressions = null)
        {
            try
            {
                var groupEntities = DbContext.Group.AsQueryable();
                if (filterExpressions != null)
                    groupEntities = groupEntities.Where(filterExpressions);
                var groupVms = Mapper.Map<IEnumerable<GroupVm>>(groupEntities);
                return groupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<StudentVm> AttachStudentToGroupVmAsync(AttachStudentToGroupVm attachStudentToGroup)
        {
            try
            {
                if (attachStudentToGroup == null)
                    throw new ArgumentNullException("attachStudentToGroup is null");

                var student = await DbContext.Users.OfType<Student>().FirstOrDefaultAsync(i => i.Id == attachStudentToGroup.Id);

                if (student == null)
                    throw new ArgumentNullException($"There is no student with id {attachStudentToGroup.Id}.");

                /*  if (!await UserManager.IsInRoleAsync(student, "Student"))
                     throw new UnauthorizedAccessException($"User with id {attachStudentToGroup.Id} has no permission to add student to group."); */

                var group = await DbContext.Group.FirstOrDefaultAsync(g => g.Id == attachStudentToGroup.GroupId);
                if (group == null)
                    throw new ArgumentNullException($"There is no group with id {attachStudentToGroup.GroupId}.");

                //przypisanie studenta do grupy
                student.GroupId = attachStudentToGroup.GroupId;
                student.Group = group;


                await DbContext.SaveChangesAsync();

                var studentVm = Mapper.Map<StudentVm>(student);
                return studentVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> RemoveStudentFromGroupAsync(AttachStudentToGroupVm attachStudentToGroup)
        {
            try
            {
                if (attachStudentToGroup.Id <= 0)
                    throw new ArgumentException($"Id must be greater than 0");

                var student = await DbContext.Users.OfType<Student>().FirstOrDefaultAsync(s => s.Id == attachStudentToGroup.Id);

                if (student == null)
                    throw new ArgumentNullException($"There is no student with {attachStudentToGroup.Id}-id");
                else
                {
                    student.Group = null;
                    student.GroupId = null;
                    await DbContext.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }


    }
}