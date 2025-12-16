namespace TodoList
{
    internal class Program
    {
        static List<Task> tasksList = new List<Task>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("== ToDo List App ==");

                Console.WriteLine("\nWhat do you want to do...? (enter the number of your choice)");
                Console.WriteLine("[1] Add a task");
                Console.WriteLine("[2] Update task status (done)");
                Console.WriteLine("[3] View all tasks");
                Console.WriteLine("[4] Exit");

                Console.Write("> ");

                string Userchoice = Console.ReadLine().Trim();

                switch (Userchoice)
                {
                    case "1":
                        AddTask();
                        ReturnToMain();
                        Console.Clear();
                        break;

                    case "2":
                        UpdateTaskStatus();
                        Console.Clear();
                        break;

                    case "3":
                        ViewTasks();
                        ReturnToMain();
                        Console.Clear();
                        break;

                    case "4":
                        Console.WriteLine("\nApplication Ended. Thanks for using our App");
                        return;

                    default:
                        Console.WriteLine("\nInvalid option.");
                        ReturnToMain();
                        Console.Clear();
                        break;
                }
            }

            static void AddTask()
            {
                Console.Clear();

                Console.WriteLine("\nEnter a task title to add:");
                Console.Write("> ");
                string title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("task title cannot be empty!");
                    return;
                }

                Console.WriteLine("Enter task description (optional):");
                Console.Write("> ");
                string description = Console.ReadLine();

                Task newTask = new Task(title, description);
                tasksList.Add(newTask);

                Console.WriteLine("Task has been added successfully!");

            }

            static void ViewTasks()
            {
                Console.Clear();


                if (tasksList.Count == 0)
                {
                    Console.WriteLine("\nThere are no tasks to show");

                }
                else
                {
                    Console.WriteLine("\n== Tasks List ==");


                    for (int i = 0; i < tasksList.Count; i++)
                    {
                        char status;

                        if (tasksList[i].status)
                        {
                            status = '✓';
                        }
                        else
                        {
                            status = 'x';
                        }

                        Console.WriteLine($"\n  {i + 1}. {tasksList[i].title} [ {status} ]");

                        if (!string.IsNullOrWhiteSpace(tasksList[i].description))
                        {
                            Console.WriteLine($"      Description: {tasksList[i].description}");

                        }
                    }
                }

            }

            static void UpdateTaskStatus()
            {

                if (tasksList.Count == 0)
                {
                    Console.WriteLine("\nThere are no tasks to update");
                    ReturnToMain();
                    return;
                }

                ViewTasks();

                Console.Write("\nEnter the number of the task to mark as completed: ");

                if (int.TryParse(Console.ReadLine(), out int taskNum))
                {
                    if (taskNum >= 1 && taskNum <= tasksList.Count)
                    {
                        tasksList[taskNum - 1].status = true;

                        Console.WriteLine();

                        ViewTasks();

                        Console.WriteLine("\nTask has marked as done!");

                        ReturnToMain();
                    }
                    else
                    {
                        Console.WriteLine("This task is not available");
                        ReturnToMain();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                    ReturnToMain();
                }
            }

            static void ReturnToMain()
            {
                Console.Write("\npress any key to return to main menu");
                Console.ReadKey();
            }


        }
    }
}
