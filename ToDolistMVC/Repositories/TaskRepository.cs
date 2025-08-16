using Microsoft.EntityFrameworkCore;
using ToDolistMVC.Data;
using ToDolistMVC.HelperClasses;
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
            try
            {
                return await _context.Tasks
            .AsNoTracking() // Prevent tracking to avoid unintended changes
            .Select(t => new TaskItem
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted,
                TaskNote = string.IsNullOrEmpty(t.TaskNote) ? t.TaskNote : CryptoHelper.Decrypt(t.TaskNote)
            })
            .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("TaskRepository : GetAll : " + ex.Message, ex.InnerException);
            }
        }
        public async Task Add(TaskItem task)
        {
            try
            {
                if (!string.IsNullOrEmpty(task.TaskNote))
                    task.TaskNote = CryptoHelper.Encrypt(task.TaskNote);
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("TaskRepository : Add : " + ex.Message, ex.InnerException);
            }
           
        }
        public async Task MarkComplete(int id)
        {
            try
            {
                TaskItem task = await _context.Tasks.FirstAsync(x => x.Id == id);
                if (task != null)
                {
                    task.IsCompleted = true;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("TaskRepository : MarkComplete : " + ex.Message, ex.InnerException);
            }
            
        }
    }
}
