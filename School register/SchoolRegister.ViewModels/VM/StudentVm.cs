using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        
    }
}