using Dapper;
using Kanban.Api.Queries;
using Kanban.Api.Repositories.Interfaces;

namespace Kanban.Api.Repositories
{
    public class TaskRepository : RepositoryBase, ITaskRepository
    {
        public TaskRepository(IConfiguration config) : base(config)
        {
            
        }

        public List<Models.Task> GetTasks()
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<Models.Task>(TaskQueries.GetTasks).ToList();
            }
        }

        public int GetOrder(string Status)
        {
            using (var connection = CreateConnection())
            {
                return connection.ExecuteScalar<int>(TaskQueries.GetOrder, new {Status = Status});
            }
        }

        public Models.Task CreateTask(Models.Task task)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<Models.Task>(TaskQueries.CreateTask, task);
            }
        }
    }
}