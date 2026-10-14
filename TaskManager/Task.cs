namespace TaskManager;

public class Task
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public Status Status { get; set; }
}

public enum Status
{
    New = 1,
    Active = 2,
    Completed = 3,
    Cancelled = 4
}