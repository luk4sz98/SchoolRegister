using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.BLL.DataModels;

namespace SchoolRegister.ViewModels.VM
{
    public class StudentVm
    {
        public int Id { get; set; }

        [Display(Name="First name")]
        public string FirstName { get; set; }

        [Display(Name="Last name")]
        public string LastName { get; set; }
        public int? GroupId { get; set; }

        public int? ParentId { get; set; }

        [Display(Name="Group")]
        public string GroupName {get; set; }
       
        [Display(Name="Parent")]
        public string ParentName { get; set; }
        public IList<Grade> Grades { get; set; }
        public double AverageGrade { get; set; }
        public IDictionary<string, double> AverageGradePerSubject { get; set; }
        public IDictionary<string, List<int>> GradesPerSubject { get; set;}
        public string Email { get; set; }
    }
}