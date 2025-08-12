using ToDolistMVC.Models;

namespace ToDolistMVC.IServices
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetTasks();
        Task AddTask(TaskItem task);
        Task CompleteTask(int index);
    }
}
