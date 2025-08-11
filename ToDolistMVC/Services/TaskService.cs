using ToDolistMVC.IRepositories;
using ToDolistMVC.IServices;
using ToDolistMVC.Models;

namespace ToDolistMVC.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;
        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }
        public List<TaskItem> GetTasks()
        {
            return _repo.GetAll();
        }
        public void AddTask(TaskItem task)
        {
            _repo.Add(task);
        }
        public void CompleteTask(int index)
        {
            _repo.MarkComplete(index);
        }
    }
}
