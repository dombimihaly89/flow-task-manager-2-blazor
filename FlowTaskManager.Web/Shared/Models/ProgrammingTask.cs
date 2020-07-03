using System;
using System.Collections.Generic;
using System.Text;

namespace FlowTaskManager.Web.Shared.Models
{
    public class ProgrammingTask
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }

    public enum Type
    {
        Java,
        Javascript,
        Spring,
        Angular,
        Linux,
        Database
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}
