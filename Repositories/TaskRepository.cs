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
    }
}