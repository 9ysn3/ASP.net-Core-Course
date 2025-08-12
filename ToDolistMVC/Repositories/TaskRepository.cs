using Microsoft.EntityFrameworkCore;
using ToDolistMVC.Data;
using ToDolistMVC.IRepositories;
using ToDolistMVC.Models;

namespace ToDolistMVC.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context=context;
        }
        public async Task<List<TaskItem>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }
        public async Task Add(TaskItem task)
        {
             await _context.Tasks.AddAsync(task);
             await  _context.SaveChangesAsync();
        }
        public async Task MarkComplete(int id)
        {
            TaskItem task =await _context.Tasks.FirstAsync(x => x.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
