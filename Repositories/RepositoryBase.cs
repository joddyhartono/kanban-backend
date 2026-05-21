using Npgsql;

namespace Kanban.Api.Repositories
{
    public class RepositoryBase
    {
        private readonly IConfiguration _config;

        public RepositoryBase(IConfiguration config)
        {
            _config = config;
        }

        protected NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
        }
    }
}