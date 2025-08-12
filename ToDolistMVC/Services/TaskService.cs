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
        public async Task<List<TaskItem>> GetTasks()
        {
            return await _repo.GetAll();
        }
        public async Task AddTask(TaskItem task)
        {
           await _repo.Add(task);
        }
        public async Task CompleteTask(int id)
        {
            await _repo.MarkComplete(id);
        }
    }
}
