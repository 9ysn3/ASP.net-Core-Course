using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDolistMVC.IServices;
using ToDolistMVC.Models;

namespace ToDolistMVC.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;
        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetTasks();
            _logger.LogInformation("Get All Tasks");
            return View(tasks);
        }
        [Route("/AddTask")]



        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/CreateTask")]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                // Return the same view with the invalid model to show validation errors
                return View("Create", task);
            }

            await _taskService.AddTask(task);
            return Redirect("/");
        }



        [Route("/CompleateTask/{id}")]
        public async Task<IActionResult> done(int id)
        {
            await _taskService.CompleteTask(id);
            return Redirect("/");
        }
    }
}
