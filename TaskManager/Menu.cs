using System.Xml.Serialization;

namespace TaskManager;

public class Menu(TaskManager taskManager)
{
    public void MainMenu()
    {
        bool programLoop = true;

        while (programLoop)
        {
            Console.Clear();
            Console.WriteLine("==== Task Manager ====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Remove Task");
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
        string title;

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

        taskManager.AddTask(title, description);
    }

    private void ListTasks()
    {
        Console.Clear();
        Console.WriteLine("===== Tasks =====");
        Console.WriteLine();
        taskManager.PrintTasks();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}
