using ToDolistMVC.Models;

namespace ToDolistMVC.IRepositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAll();
        void Add(TaskItem task);
        void MarkComplete(int index);
    }
}
