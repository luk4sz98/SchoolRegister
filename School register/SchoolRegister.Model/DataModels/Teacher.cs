using System.Collections.Generic;

namespace SchoolRegister.BLL.DataModels
{
    public class Teacher : User
    {
        public virtual IList<Subject> Subjects { get; set; }
        public string Title { get; set; }
    }
}