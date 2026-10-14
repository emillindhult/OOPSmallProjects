namespace TaskManager;

public class TaskService
{
    private readonly List<Task> _tasks;

    public TaskService()
    {
        _tasks = [];
    }

    public void AddTask(string title, string? description)
    {
        var newTask = new Task
        {
            Title = title,
            Description = description,
            Status = Status.New
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

    public void PrintTask(int index)
    {
        int correctIndex = index - 1;

        Console.WriteLine($"Title: {_tasks[correctIndex].Title}");
        Console.WriteLine($"Description: {_tasks[correctIndex].Description}");
        Console.WriteLine($"Status: {_tasks[correctIndex].Status}");

    }

    public bool ChangeStatus(int index, int status)
    {
        _tasks[index - 1].Status = (Status)status;

        if (_tasks[index - 1].Status == (Status)status)
        {
            return true;
        }
        return false;
    }

    public void RemoveTask(int index)
    {
        _tasks.RemoveAt(index - 1);
    }
}
