namespace ToDolistMVC.Middleware
{
    public class TaskActionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TaskActionLoggingMiddleware> _logger;

        public TaskActionLoggingMiddleware(RequestDelegate next, 
            ILogger<TaskActionLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            // Log only for adding or editing tasks
            if (path.Contains("/CompleateTask".ToLower()))
            {
                _logger.LogInformation("Task Copleate request at: {Time}", DateTime.UtcNow);
            }

            await _next(context);
        }
    }
}
