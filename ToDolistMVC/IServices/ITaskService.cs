using ToDolistMVC.Models;

namespace ToDolistMVC.IServices
{
    public interface ITaskService
    {
        List<TaskItem> GetTasks();
        void AddTask(TaskItem task);
        void CompleteTask(int index);
    }
}
