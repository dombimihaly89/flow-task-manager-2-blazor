using System;
using System.Collections.Generic;
using System.Text;

namespace FlowTaskManager.Web.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
    public enum Role
    {
        Student,
        Mentor
    }
}
