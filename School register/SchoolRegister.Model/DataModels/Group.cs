using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.BLL.DataModels
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IList<Student> Students { get; set; }
        public virtual IList<SubjectGroup> SubjectGroups { get; set; }
    }
}