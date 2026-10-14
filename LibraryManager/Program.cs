using ConsoleTools;

var booksMenu = new ConsoleMenu(args, level: 1)
    .Configure(config =>
    {
        config.Title = "Books";
        config.EnableWriteTitle = true;
        config.DisableKeyboardNavigation = true;
        config.WriteItemAction = (item) => Console.Write(item.Name);
        config.Selector = "-> ";
    });
for (int i = 0; i < 5; i++)
{
    booksMenu.Add(i.ToString(), () => Console.WriteLine());
}

var menu = new ConsoleMenu(args, level: 0)
    .Add("Show Books", booksMenu.Show)
    .Add("Two", () => Console.WriteLine("222"))
    .Add("Exit", () => Environment.Exit(0))
    .Configure(config =>
    {
        config.Title = "Library Manager";
        config.EnableWriteTitle = true;
        config.DisableKeyboardNavigation = true;
        config.WriteItemAction = (item) => Console.Write(item.Name);
        config.Selector = "-> ";
    });

menu.Show();