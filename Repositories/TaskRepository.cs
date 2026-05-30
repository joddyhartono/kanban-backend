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

        public Models.Task MoveTask(Models.Task task)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<Models.Task>(TaskQueries.MoveTask, task);
            }
        }

        public void DeleteTask(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute(TaskQueries.DeleteTask, new {Id = id});
            }
        }

        public Models.Task UpdateTask(Models.Task task)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<Models.Task>(TaskQueries.UpdateTask, task);
            }
        }

        public Models.Task GetTask(int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<Models.Task>(TaskQueries.GetTask, new {Id = id});
            }
        }
    }
}