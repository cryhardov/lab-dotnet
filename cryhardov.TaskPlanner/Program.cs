﻿using System;
using cryhardov.TaskPlanner.Domain.Logic;
using cryhardov.TaskPlanner.Domain.Models.Enums;
using cryhardov.TaskPlanner.Domain.Models;


internal static class Program
{
    public static void Main(string[] args)
    {

        var workItems = new List<WorkItem>();
        string input;

        Console.WriteLine("Enter WorkItems. Type 'end' to finish:");

        while (true)
        {
            Console.Write("Enter WorkItem title (or 'end' to finish): ");
            input = Console.ReadLine();
            if (input.ToLower() == "end")
                break;

            var title = input;

            Console.Write("Enter due date (yyyy-MM-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter priority (None, Low, Medium, High, Urgent): ");
            Priority priority = Enum.Parse<Priority>(Console.ReadLine(), true);

            Console.Write("Enter complexity (None, Minutes, Hours, Days, Weeks): ");
            Complexity complexity = Enum.Parse<Complexity>(Console.ReadLine(), true);

            Console.Write("Enter description: ");
            var description = Console.ReadLine();

            Console.Write("Is the task completed? (true/false): ");
            bool isCompleted = bool.Parse(Console.ReadLine());

            workItems.Add(new WorkItem
            {
                Title = title,
                DueDate = dueDate,
                Priority = priority,
                Complexity = complexity,
                Description = description,
                CreationDate = DateTime.Now,
                IsCompleted = isCompleted
            });
        }

        SimpleTaskPlanner planner = new SimpleTaskPlanner();

        WorkItem[] sortedWorkItems = planner.CreatePlan(workItems.ToArray());

        Console.WriteLine("\nSorted WorkItems:");
        foreach (var item in sortedWorkItems)
        {
            Console.WriteLine(item.ToString());
        }
    }
}