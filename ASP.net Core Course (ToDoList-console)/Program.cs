using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        // Define the Task class
        class TaskItem
        {
            public string Title { get; set; }
            public bool IsCompleted { get; set; }
            public DateTime DueDate { get; set; }
        }

        static void Main(string[] args)
        {
            List<TaskItem> tasks = new List<TaskItem>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Task Manager ---");
                Console.WriteLine("1. View all tasks");
                Console.WriteLine("2. View completed tasks");
                Console.WriteLine("3. Add a new task");
                Console.WriteLine("4. Mark task as completed");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllTasks(tasks);
                        break;
                    case "2":
                        ViewCompletedTasks(tasks);
                        break;
                    case "3":
                        AddNewTask(tasks);
                        break;
                    case "4":
                        MarkTaskCompleted(tasks);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ViewAllTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\n--- All Tasks ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                Console.WriteLine($"{i + 1}. {task.Title} - Due: {task.DueDate.ToShortDateString()} - Completed: {task.IsCompleted}");
            }
        }

        static void ViewCompletedTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\n--- Completed Tasks ---");
            var completed = tasks.FindAll(t => t.IsCompleted);

            if (completed.Count == 0)
            {
                Console.WriteLine("No completed tasks.");
                return;
            }

            foreach (var task in completed)
            {
                Console.WriteLine($"{task.Title} - Due: {task.DueDate.ToShortDateString()}");
            }
        }

        static void AddNewTask(List<TaskItem> tasks)
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime dueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.Write("Invalid date format. Try again (yyyy-mm-dd): ");
            }

            tasks.Add(new TaskItem { Title = title, DueDate = dueDate, IsCompleted = false });
            Console.WriteLine("Task added successfully!");
        }

        static void MarkTaskCompleted(List<TaskItem> tasks)
        {
            Console.Write("Enter task number to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks[index - 1].IsCompleted = true;
                Console.WriteLine("Task marked as completed!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
    }
}
