namespace Kanban.Api.Queries
{
    public static class TaskQueries
    {
        public const string GetTasks = "SELECT * FROM tasks ORDER BY \"order\""; 
    }
}