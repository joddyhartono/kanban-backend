namespace Kanban.Api.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        List<Models.Task> GetTasks();
    }
}