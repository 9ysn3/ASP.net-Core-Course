using Microsoft.AspNetCore.Mvc;
using ToDolistMVC.Models;

namespace ToDolistMVC.Controllers
{
    public class TaskController : Controller
    {
         List<TaskItem> tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Write documentation", DueDate = DateTime.Today.AddDays(2),IsCompleted=false },
                new TaskItem { Title = "Fix login bug", DueDate = DateTime.Today.AddDays(1),IsCompleted=true },
                new TaskItem { Title = "Deploy to production", DueDate = DateTime.Today.AddDays(5),IsCompleted = false }
            };

        [Route("/MyTasks")]
        public IActionResult Index()
        {
            return View(tasks);
        }

        [Route("/AddTask")]
        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        [Route("/AddTask")]
        public IActionResult Create(TaskItem task)
        {
            tasks.Add(task);
            return View("Index", tasks);
        }

        
        [Route("/CompleateTask/{index}")]
        public IActionResult done(int index)
        {
            tasks[index].IsCompleted=true;
            return View("Index", tasks);
        }


    }
}
