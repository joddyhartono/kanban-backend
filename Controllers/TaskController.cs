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
                _logger.LogInformation("GetTasks success");
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
                _logger.LogInformation("CreateTask success");
                return CreatedAtAction(nameof(CreateTask), createdTask);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while creating a task");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}/status")]
        public IActionResult MoveTask([FromBody] Models.Task task)
        {
            _logger.LogInformation("MoveTask started");
            try
            {
                var updatedTask = _repository.MoveTask(task);
                _logger.LogInformation("MoveTask success");
                return Ok(updatedTask);                
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while moving a task");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateTask([FromBody] Models.Task task)
        {
            _logger.LogInformation("UpdateTask started");
            try
            {
                var updatedTask = _repository.UpdateTask(task);
                _logger.LogInformation("UpdateTask success");
                return Ok(updatedTask);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while updating a task");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask([FromRoute] int id)
        {
            _logger.LogInformation("DeleteTask started");
            try
            {
                _repository.DeleteTask(id);
                _logger.LogInformation("DeleteTask success");
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while deleting a task");
                return StatusCode(500, "Internal server error");                
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTask([FromRoute] int id)
        {
            _logger.LogInformation("GetTask started");
            try
            {
                var task = _repository.GetTask(id);
                _logger.LogInformation("GetTask success");
                return Ok(task);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while getting a task");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}