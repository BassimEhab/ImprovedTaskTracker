using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedTaskTracker
{
    public class TaskClass
    {
        public List<string> TaskTitle { get; set; } 
        public List<string> TaskDescription { get; set; }
        public List<string> TaskDueDate { get; set; }
        public List<string> TaskPriority { get; set; }
        public List<StatusEnum> TaskStatus { get; set; }

        public void AddTask(List<string> TaskTitle ,List<string> TaskDescription, List<string> TaskDueDate, List<string>TaskPriority, List<StatusEnum> TaskStatus)
        {
            string InputStatus;

            Console.Write("enter your task title : ");
            TaskTitle.Add(Console.ReadLine().ToLower());
            Console.Write("enter your task Description : ");
            TaskDescription.Add(Console.ReadLine().ToLower());
            Console.Write("enter your task DueDate : ");
            TaskDueDate.Add(Console.ReadLine().ToLower());
            Console.Write("enter your task Priority : ");
            TaskPriority.Add(Console.ReadLine().ToLower());
        Label:
            Console.Write("\nenter your task Status(pending, inprogress, completed) : ");
            InputStatus = (Console.ReadLine().ToLower());
            if (Enum.TryParse(InputStatus, true, out StatusEnum result))
            {
                TaskStatus.Add(result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter only one of these ( completed, inprogress, pending) ");
                Console.Write("try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                goto Label;
            }
        }

        public void ViewTask(List<string> TaskTitle, List<string> TaskDescription, List<string> TaskDueDate, List<string> TaskPriority, List<StatusEnum> TaskStatus)
        {
            Console.WriteLine("Choose which catagory\n[1] active,\n[2] overdue,\n[3] completed :- ");
            int TaskCatagory = int.Parse(Console.ReadLine());
            bool IsFound = false;
            for (int i = 0; i < TaskStatus.Count; i++)
            {
                if ((TaskCatagory == 1) && (TaskStatus[i] == StatusEnum.inprogress))
                {
                    IsFound = true;
                    Console.WriteLine($"\n\nTtile:- {TaskTitle[i]}");
                    Console.WriteLine($"Description: {TaskDescription[i]}");
                    Console.WriteLine($"DueDate: {TaskDueDate[i]}");
                    Console.WriteLine($"Priority: {TaskPriority[i]}");
                    Console.WriteLine($"STATUS: {TaskStatus[i]}");
                    Console.WriteLine("--------------------------------------");
                }
                else if ((TaskCatagory == 2) && (TaskStatus[i] == StatusEnum.pending))
                {
                    IsFound = true;
                    Console.WriteLine($"\n\nTtile:- {TaskTitle[i]}");
                    Console.WriteLine($"Description: {TaskDescription[i]}");
                    Console.WriteLine($"DueDate: {TaskDueDate[i]}");
                    Console.WriteLine($"Priority: {TaskPriority[i]}");
                    Console.WriteLine($"STATUS: {TaskStatus[i]}");
                    Console.WriteLine("--------------------------------------");
                }
                else if ((TaskCatagory == 3) && (TaskStatus[i] == StatusEnum.completed))
                {
                    IsFound = true;
                    Console.WriteLine($"\n\nTtile:- {TaskTitle[i]}");
                    Console.WriteLine($"Description: {TaskDescription[i]}");
                    Console.WriteLine($"DueDate: {TaskDueDate[i]}");
                    Console.WriteLine($"Priority: {TaskPriority[i]}");
                    Console.WriteLine($"STATUS: {TaskStatus[i]}");
                    Console.WriteLine("--------------------------------------");
                }
            }
            if (!IsFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere is No Tasks in This Catagory\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void UpdateTaskStatus(List<string> TaskTitle, List<StatusEnum> TaskStatus)
        {
            string InputStatus;
            int TaskIndex;
            foreach (string item in TaskTitle)
            {
                Console.WriteLine($"[{TaskTitle.IndexOf(item)}] - {item}");
            }
            Console.Write("\n\nchoose which task to be updated: ");
            TaskIndex = int.Parse(Console.ReadLine());
            Console.Write($"The status of this task is {TaskStatus[TaskIndex]}\nchange to ?  (pending, inprogress, completed) : ");
        Label:
            InputStatus = Console.ReadLine().ToLower();

            if (Enum.TryParse(InputStatus, true, out StatusEnum result))
            {
                TaskStatus[TaskIndex] = result;
                Console.WriteLine("changes have been applied!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter only one of these ( completed, inprogress, pending) ");
                Console.Write("tryagain : ");
                Console.ForegroundColor = ConsoleColor.White;
                goto Label;
            }
        }

        public void DeleteTask(List<string> TaskTitle, List<string> TaskDescription, List<string> TaskDueDate, List<string> TaskPriority, List<StatusEnum> TaskStatus)
        {
            int TaskIndex;
            foreach (string item in TaskTitle)
            {
                Console.WriteLine($"[{TaskTitle.IndexOf(item)}] {item}");
            }
            Console.WriteLine("\n\nchoose which task to be DELETED: ");
            TaskIndex = int.Parse(Console.ReadLine());
            TaskTitle.RemoveAt(TaskIndex);
            TaskDescription.RemoveAt(TaskIndex);
            TaskDueDate.RemoveAt(TaskIndex);
            TaskPriority.RemoveAt(TaskIndex);
            TaskStatus.RemoveAt(TaskIndex);
            Console.WriteLine("\n\nThe task have been succsefully DELETED! ");
        }
    }
}
