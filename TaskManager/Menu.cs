namespace TaskManager;

public class Menu(TaskService taskService)
{
    public void MainMenu()
    {
        bool programLoop = true;

        while (programLoop)
        {
            Console.Clear();
            Console.WriteLine("==== Task Manager ====");
            Console.WriteLine();
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("-> ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ListTasks();
                    break;
                case "3":
                    break;
                case "0":
                    programLoop = false;
                    break;
                default:
                    break;
            }
        }
    }

    private void AddTask()
    {
        bool addTitleLoop = true;
        string title = string.Empty;

        while (addTitleLoop)
        {
            Console.Clear();
            Console.WriteLine("==== Add Task ====");
            Console.WriteLine();
            Console.Write("Title: ");

            title = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine();
                Console.WriteLine("Title can't be empty.");
                Thread.Sleep(1000);
                continue;
            }

            addTitleLoop = false;
        }

        Console.Clear();
        Console.WriteLine("==== Add Task ====");
        Console.WriteLine();
        Console.Write("Description: ");

        string? description = Console.ReadLine();

        taskService.AddTask(title, description);
    }

    private void ListTasks()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Tasks =====");
            Console.WriteLine();
            taskService.PrintTasks();
            Console.WriteLine();
            Console.WriteLine("0. Back");
            Console.WriteLine();
            Console.WriteLine("Choose a task");
            Console.WriteLine();
            Console.Write("-> ");

            string? input = Console.ReadLine();
            
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
                Thread.Sleep(1000);
                continue;
            }

            if (input == "0")
            {
                return;
            }

            ShowTask(result);
        }
    }

    private void ShowTask(int index)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Task =====");
            Console.WriteLine();
            taskService.PrintTask(index);
            Console.WriteLine();
            Console.WriteLine("1. Change status");
            Console.WriteLine("2. Remove task");
            Console.WriteLine();
            Console.WriteLine("0. Back");
            Console.WriteLine();
            Console.Write("-> ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ChangeStatus(index);
                    break;
                case "2":
                    RemoveTask(index);
                    return;
                case "0":
                    return;
                default:
                    break;
            }
        }
    }

    private void ChangeStatus(int index)
    {
        while (true)
        {
            var values = Enum.GetNames<Status>();

            Console.Clear();
            Console.WriteLine("=== Change Status ===");
            Console.WriteLine();
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {values[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("0. Back");
            Console.WriteLine();
            Console.Write("-> ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
                Thread.Sleep(1000);
                continue;
            }

            if (result < 1 && result > 4)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
                Thread.Sleep(1000);
                continue;
            }

            if (input == "0")
            {
                return;
            }

            if (taskService.ChangeStatus(index, result))
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Something went wrong, try again...");
            Thread.Sleep(1000);
        }
    }

    private void RemoveTask(int index)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Remove Task ===");
            Console.WriteLine();
            Console.WriteLine("Are you sure you want to remove the task?");
            Console.WriteLine("Yes/No (y/n)");
            Console.WriteLine();
            Console.Write("-> ");

            string? input = Console.ReadLine();

            if (input is null)
            {
                continue;
            }

            switch (input.ToLower().Trim())
            {
                case "y":
                    taskService.RemoveTask(index);
                    return;
                case "n":
                    return;
                default:
                    break;
            }
        }
    }
}
