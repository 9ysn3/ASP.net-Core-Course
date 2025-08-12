using System.ComponentModel.DataAnnotations;

namespace ToDolistMVC.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters.")]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
