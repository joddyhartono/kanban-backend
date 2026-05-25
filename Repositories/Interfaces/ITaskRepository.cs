namespace Kanban.Api.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        List<Models.Task> GetTasks();
        int GetOrder(string Status);
        Models.Task CreateTask(Models.Task task);
        Models.Task MoveTask(Models.Task task);
        void DeleteTask(int id);
    }
}