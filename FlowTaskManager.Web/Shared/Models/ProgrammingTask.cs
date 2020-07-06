using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlowTaskManager.Web.Shared.Models
{
    public class ProgrammingTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Type must be provided.")]
        public Type Type { get; set; }

        [Required(ErrorMessage = "Title must be provided.")]
        [MinLength(3, ErrorMessage = "Title must be between 3 and 50 characters")]
        [MaxLength(50, ErrorMessage = "Title must be between 3 and 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content must be provided.")]
        [MinLength(10, ErrorMessage = "Content must be between 10 and 1000 characters")]
        [MaxLength(1000, ErrorMessage = "Content must be between 10 and 1000 characters")] 
        public string Content { get; set; }

        [Required(ErrorMessage = "Difficulty must be provided.")]
        public Difficulty Difficulty { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Required]
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
