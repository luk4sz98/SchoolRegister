using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM {
    public class SubjectVm {
        public int Id {get; set; }
        public string Name {get; set; }
        public string Description {get; set; }
        
        public IList<string> Groups { get; set; }

        [Display(Name = "Teacher")]
        public string TeacherName { get; set; }
        public int? TeacherId { get; set; }
    }
}