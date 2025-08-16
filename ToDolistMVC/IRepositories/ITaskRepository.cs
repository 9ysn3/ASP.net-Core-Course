using ToDolistMVC.Models;

namespace ToDolistMVC.IRepositories
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAll();
        Task Add(TaskItem task);
        Task MarkComplete(int index);
    }
}
