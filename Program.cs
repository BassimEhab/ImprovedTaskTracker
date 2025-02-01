using System.Collections;
using System.Reflection.Emit;

namespace ImprovedTaskTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList TaskTitle = new ArrayList();
            ArrayList TaskDescription = new ArrayList();
            ArrayList TaskDueDate = new ArrayList();
            ArrayList TaskPriority = new ArrayList();
            ArrayList TaskStatus = new ArrayList();
            int Counter = 0;
            while (true)
            {
                Console.WriteLine("Choose\n[1] add task title\n[2] Update task status\n[3] view tasks in Different catagories\n[4] delete task\n[5] Exit Program:- ");
                int input = int.Parse(Console.ReadLine());

                #region ADD TASK
                if (input == 1)
                {
                    AddTask(TaskTitle, TaskDescription, TaskDueDate, TaskPriority, TaskStatus);
                    Counter++;
                }
                #endregion

                #region UPDATE STATUS
                else if (input == 2)
                {
                    UpdateTaskStatus(TaskTitle, TaskStatus);
                }
                #endregion

                #region VIEW TASK
                if (input == 3)
                {
                    ViewTask(TaskTitle, TaskDescription, TaskDueDate, TaskPriority, TaskStatus);
                }

                #endregion

                #region DELETE TASK
                else if (input == 4)
                {
                    DeleteTask(TaskTitle, TaskDescription, TaskDueDate, TaskPriority, TaskStatus);
                }
                #endregion

                #region Exit
                if (input == 5)
                {
                    Console.WriteLine("\n exit safely ! ");
                    break;
                }
                #endregion


            }
        }
        static void AddTask(ArrayList TaskTitle, ArrayList TaskDescription, ArrayList TaskDueDate, ArrayList TaskPriority, ArrayList TaskStatus)
        {
            // comparison Status
            ArrayList ComState = new ArrayList();
            ComState.Add("completed");
            ComState.Add("in progress");
            ComState.Add("pending");
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
            Console.Write("\nenter your task Status(pending, in progress, completed) : ");
            InputStatus = (Console.ReadLine().ToLower());
            //Console.WriteLine(TaskStatus[counter]);
            //Console.WriteLine(ComState[0]);
            #region Incorrect Status Input Handeling
            try
            {
                //if (!ComState.Contains(TestStatus))
                if (ComState.Contains(InputStatus))
                {
                    TaskStatus.Add(InputStatus);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter only one of these ( completed, in progress, pending) ");
                Console.Write("try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                goto Label;
            }
            #endregion

        }

        static void UpdateTaskStatus(ArrayList TaskTitle, ArrayList TaskStatus)
        {
            ArrayList ComState = new ArrayList();
            ComState.Add("completed");
            ComState.Add("in progress");
            ComState.Add("pending");
            string InputStatus;
            int TaskIndex;
            foreach (object item in TaskTitle)
            {
                Console.WriteLine($"[{TaskTitle.IndexOf(item)}] - {item}");
            }
            Console.Write("\n\nchoose which task to be updated: ");
            TaskIndex = int.Parse(Console.ReadLine());
            Console.Write($"The status of this task is {TaskStatus[TaskIndex]}\nchange to ?  (pending, in progress, completed) : ");
        Label:
            InputStatus = Console.ReadLine().ToLower();

            try
            {
                if (ComState.Contains(InputStatus))
                {
                    TaskStatus[TaskIndex] = InputStatus;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter only one of these ( completed, in progress, pending) ");
                Console.Write("tryagain : ");
                Console.ForegroundColor = ConsoleColor.White;
                goto Label;
            }
            Console.WriteLine("changes have been applied!");
        }

        static void ViewTask(ArrayList TaskTitle, ArrayList TaskDescription, ArrayList TaskDueDate, ArrayList TaskPriority, ArrayList TaskStatus)
        {
            Console.WriteLine("Choose which catagory\n[1] active,\n[2] overdue,\n[3] completed :- ");
            int TaskCatagory = int.Parse(Console.ReadLine());
            bool IsFound = false;
            for (int i = 0; i < TaskStatus.Count; i++)
            {
                if ((TaskCatagory == 1) && (TaskStatus[i].ToString() == "in progress"))
                {
                    IsFound = true;
                    Console.WriteLine($"\n\nTtile:- {TaskTitle[i]}");
                    Console.WriteLine($"Description: {TaskDescription[i]}");
                    Console.WriteLine($"DueDate: {TaskDueDate[i]}");
                    Console.WriteLine($"Priority: {TaskPriority[i]}");
                    Console.WriteLine($"STATUS: {TaskStatus[i]}");
                    Console.WriteLine("--------------------------------------");
                }
                else if ((TaskCatagory == 2) && (TaskStatus[i].ToString() == "pending"))
                {
                    IsFound = true;
                    Console.WriteLine($"\n\nTtile:- {TaskTitle[i]}");
                    Console.WriteLine($"Description: {TaskDescription[i]}");
                    Console.WriteLine($"DueDate: {TaskDueDate[i]}");
                    Console.WriteLine($"Priority: {TaskPriority[i]}");
                    Console.WriteLine($"STATUS: {TaskStatus[i]}");
                    Console.WriteLine("--------------------------------------");
                }
                else if ((TaskCatagory == 3) && (TaskStatus[i].ToString() == "completed"))
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

        static void DeleteTask(ArrayList TaskTitle, ArrayList TaskDescription, ArrayList TaskDueDate, ArrayList TaskPriority, ArrayList TaskStatus)
        {
            int TaskIndex;
            foreach (object item in TaskTitle)
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
