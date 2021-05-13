using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM
{
    public class AttachStudentToGroupVm
    {
        [Required]
        public int Id { get; set; }


        public int? GroupId { get; set; }
    }
}