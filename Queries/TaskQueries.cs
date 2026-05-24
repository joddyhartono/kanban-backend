namespace Kanban.Api.Queries
{
    public static class TaskQueries
    {
        public const string GetTasks = "SELECT * FROM tasks ORDER BY \"order\""; 
        public const string GetOrder = "SELECT COUNT(*) FROM tasks WHERE status = @Status";
        public const string CreateTask = "INSERT INTO tasks (title, description, sort_order, due_date) VALUES (@Title, @Description, @SortOrder, @DueDate) RETURNING id, title, description, status, sort_order AS SortOrder, due_date AS DueDate, created_at AS CreatedAt";
    }
}