using System;
using System.Collections.Generic;
using DAF_Project.Pages.SignUp;
namespace DAF_Project.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
