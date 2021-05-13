using AutoMapper;
using System.Linq;
using SchoolRegister.ViewModels.VM;
using SchoolRegister.BLL.DataModels;
using System.Collections.Generic;
using System;

namespace SchoolRegister.Web.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Subject, SubjectVm>()
                        .ForMember(dest => dest.TeacherName, x => x.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                        .ForMember(dest => dest.Groups, x => x.MapFrom(src => src.SubjectGroups.Select(y => y.Group)));

            CreateMap<AddOrUpdateSubjectVm, Subject>();
            CreateMap<Group, GroupVm>()
            .ForMember(dest => dest.Subjects, x => x.MapFrom(src => src.SubjectGroups.Select(s => s.Subject)));

            CreateMap<AddOrUpdateGroupVm, Group>();
            CreateMap<GroupVm, AddOrUpdateGroupVm>();

            CreateMap<SubjectVm, AddOrUpdateSubjectVm>();

            CreateMap<Student, StudentVm>()
                .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id));

            CreateMap<Teacher, TeacherVm>();

            CreateMap<AddGradeToStudentVm, Grade>();
            CreateMap<Grade, GradeVm>()
                .ForMember(dest => dest.Student, x => x.MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
                .ForMember(dest => dest.Subject, x => x.MapFrom(src => src.Subject.Name));

            CreateMap<AttachDetachSubjectGroupVm, SubjectGroup>();

            CreateMap<Parent, ParentVm>()
                .ForMember(dest => dest.ParentName, x => x.MapFrom(src => $"{src.FirstName} {src.LastName}"));



            CreateMap<RegisterNewUserVm, User>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));
            CreateMap<RegisterNewUserVm, Parent>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));
            CreateMap<RegisterNewUserVm, Student>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));
            CreateMap<RegisterNewUserVm, Teacher>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Title, y => y.MapFrom(src => src.TeacherTitles));

        }

    }
}