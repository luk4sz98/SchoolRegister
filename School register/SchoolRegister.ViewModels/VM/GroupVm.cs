using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolRegister.BLL.DataModels;

namespace SchoolRegister.ViewModels.VM
{
    public class GroupVm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<string> Students { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}