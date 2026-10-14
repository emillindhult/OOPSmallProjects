using TaskManager;

var taskService = new TaskService();
var menu = new Menu(taskService);

menu.MainMenu();