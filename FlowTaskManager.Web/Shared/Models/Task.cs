using System;
using System.Collections.Generic;
using System.Text;

namespace FlowTaskManager.Web.Shared.Models
{
    public class Task
    {
        private int Id { get; set; }
        private Type Type { get; set; }
        private string Title { get; set; }
        private string Content { get; set; }
        private Difficulty Difficulty { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        private int UserId { get; set; }
        private User User { get; set; }
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
