using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDolistMVC.Models;

namespace ToDolistMVC.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
          
        }

       public DbSet<TaskItem> Tasks { get; set; }
    }
}
