namespace ToDolistMVC.Models
{
    public class TaskItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
