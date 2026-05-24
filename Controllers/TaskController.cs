using Kanban.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [Route("/tasks")]
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
                _logger.LogError(e, "An error occurred while getting tasks");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] Models.Task task)
        {
            _logger.LogInformation("CreateTask started");
            try
            {
                task.SortOrder = _repository.GetOrder("To do");
                var createdTask = _repository.CreateTask(task);
                return CreatedAtAction(nameof(CreateTask), createdTask);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while creating task");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}