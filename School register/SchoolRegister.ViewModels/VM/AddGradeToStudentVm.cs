using System.ComponentModel.DataAnnotations;
using System;
using SchoolRegister.BLL.DataModels;

namespace SchoolRegister.ViewModels.VM
{
    public class AddGradeToStudentVm
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public GradeScale GradeValue { get; set; }
    }
}