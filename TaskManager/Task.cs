namespace TaskManager;

public class Task
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public Status Status { get; set; }
}

public enum Status
{
    Todo,
    InProgress,
    Done
}