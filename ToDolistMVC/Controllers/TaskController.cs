using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Index()
        {
            try
            {
                var tasks = await _taskService.GetTasks();
                _logger.LogInformation("Get All Tasks");
                return View(tasks);
            }
            catch(Exception ex)
            {
                _logger.LogError("Message:"+ex.Message+ "\nInnerException" + ex.InnerException);
                return View(new List<TaskItem>());
            }
        }

        [Route("/AddTask")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }




        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [Route("/CreateTask")]
        public async Task<IActionResult> Create(TaskItem task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Return the same view with the invalid model to show validation errors
                    return View("Create", task);
                }

                await _taskService.AddTask(task);
                return Redirect("/");
            }
            catch (Exception ex )
            {
                _logger.LogError("Message:" + ex.Message + "\nInnerException" + ex.InnerException);
                ViewBag.error = "Something get wrong, Please try again later!";
                return View("Create");
            }
           
        }



        [Route("/CompleateTask/{id}")]
        [Authorize]
        public async Task<IActionResult> done(int id)
        {
            try
            {
                await _taskService.CompleteTask(id);
                
            }
            catch (Exception ex)
            {

                _logger.LogError("Message:" + ex.Message + "\nInnerException" + ex.InnerException);
                ViewBag.error = "Something get wrong, Please try again later!";
            }
            return Redirect("/");


        }
    }
}
