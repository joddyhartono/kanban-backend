using Kanban.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskRepository _repository;

        public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            _logger.LogInformation("GetTasks started");
            try
            {
                var tasks = _repository.GetTasks();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while getting tasks.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}