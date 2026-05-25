namespace Kanban.Api.Queries
{
    public static class TaskQueries
    {
        public const string GetTasks = "SELECT id, title, description, status, sort_order AS SortOrder, due_date AS DueDate FROM tasks ORDER BY sort_order"; 
        public const string GetOrder = "SELECT COUNT(*) FROM tasks WHERE status = @Status";
        public const string CreateTask = "INSERT INTO tasks (title, description, sort_order, due_date) VALUES (@Title, @Description, @SortOrder, @DueDate) RETURNING id, title, description, status, sort_order AS SortOrder, due_date AS DueDate, created_at AS CreatedAt";
        public const string MoveTask = "UPDATE tasks SET status = @Status, updated_at = @UpdatedAt WHERE id = @Id RETURNING id, title, description, status, sort_order AS SortOrder, due_date AS DueDate, updated_at AS UpdatedAt";
    }
}