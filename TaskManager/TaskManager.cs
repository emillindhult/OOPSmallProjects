namespace TaskManager;

public class TaskManager
{
    private readonly List<Task> _tasks;

    public TaskManager()
    {
        _tasks = [];
    }

    public void AddTask(string title, string? description)
    {
        var newTask = new Task
        {
            Title = title,
            Description = description,
            Status = Status.Todo
        };

        _tasks.Add(newTask);
    }

    public void RemoveTask(Task task)
    {
        _tasks.Remove(task);
    }

    public void PrintTasks()
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_tasks[i].Title} | {_tasks[i].Status}");
        }
    }
}
