using Microsoft.AspNetCore.Mvc;
using ToDolistMVC.IServices;
using ToDolistMVC.Models;

namespace ToDolistMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;
        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var tasks = _taskService.GetTasks();
            _logger.LogInformation("Get All Tasks");
            return View(tasks);
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
            _taskService.AddTask(task);
            return Redirect("/");
        }
        [Route("/CompleateTask/{index}")]
        public IActionResult done(int index)
        {
            _taskService.CompleteTask(index);
            return Redirect("/");
        }
    }
}
