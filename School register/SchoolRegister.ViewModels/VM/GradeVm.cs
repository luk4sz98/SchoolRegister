using System;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.BLL.DataModels;

namespace SchoolRegister.ViewModels.VM
{
    public class GradeVm
    {
        public string Student { get; set; }
        public string Subject { get; set; }

        [Display(Name="Date")]
        public DateTime DateOfIssue { get; set; }
        
        [Display(Name="Grade")]
        public int GradeValue { get; set; }
    }
}