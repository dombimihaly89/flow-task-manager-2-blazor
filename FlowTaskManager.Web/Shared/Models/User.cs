using System;
using System.Collections.Generic;
using System.Text;

namespace FlowTaskManager.Web.Shared.Models
{
    public class User
    {
        private long Id { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime DateOfBirth { get; set; }
        private Role Role { get; set; }
    }
    public enum Role
    {
        Student,
        Mentor
    }
}
