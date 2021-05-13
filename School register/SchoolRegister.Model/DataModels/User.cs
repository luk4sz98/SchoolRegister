using System;
using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.BLL.DataModels
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
