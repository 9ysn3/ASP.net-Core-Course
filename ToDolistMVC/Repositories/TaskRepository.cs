using ToDolistMVC.IRepositories;
using ToDolistMVC.Models;

namespace ToDolistMVC.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static List<TaskItem> tasks = new List<TaskItem>    {
        new TaskItem { Title = "Write documentation", DueDate = DateTime.Today.AddDays(2), IsCompleted = false },
        new TaskItem { Title = "Fix login bug", DueDate = DateTime.Today.AddDays(1), IsCompleted = true },
        new TaskItem { Title = "Deploy to production", DueDate = DateTime.Today.AddDays(5), IsCompleted = false }    };
        public List<TaskItem> GetAll()
        {
            return tasks;
        }
        public void Add(TaskItem task)
        {
            tasks.Add(task);
        }
        public void MarkComplete(int index)
        {
            if (index >= 0 && index < tasks.Count)
                tasks[index].IsCompleted = true;
        }
    }
}
