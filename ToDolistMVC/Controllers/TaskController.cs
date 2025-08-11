using Microsoft.AspNetCore.Mvc;
using ToDolistMVC.Models;

namespace ToDolistMVC.Controllers
{
    public class TaskController : Controller
    {
        static List<TaskItem> tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Write documentation", DueDate = DateTime.Today.AddDays(2),IsCompleted=false },
                new TaskItem { Title = "Fix login bug", DueDate = DateTime.Today.AddDays(1),IsCompleted=true },
                new TaskItem { Title = "Deploy to production", DueDate = DateTime.Today.AddDays(5),IsCompleted = false }
            };

        public IActionResult Index()
        {
            return View(tasks);

           
            var theme = HttpContext.Session.GetString("Theme");
        }

        [Route("/AddTask")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/CreateTask")]
        public IActionResult Create(TaskItem task)
        {
            tasks.Add(task);
            return Redirect("/");
        }

        [Route("/CompleateTask/{index}")]
        public IActionResult done(int index)
        {
            tasks[index].IsCompleted = true;
            return Redirect("/");
        }

    }
}
