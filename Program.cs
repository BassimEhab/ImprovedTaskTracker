using System.Collections;
using System.Reflection.Emit;

namespace ImprovedTaskTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskClass TaskOp = new TaskClass();
            TaskOp.TaskTitle = new List<string>();
            TaskOp.TaskDescription= new List<string>();
            TaskOp.TaskDueDate = new List<string>();
            TaskOp.TaskPriority = new List<string>();
            TaskOp.TaskStatus = new List<StatusEnum>();
            while (true)
            {
                Console.WriteLine("Choose\n[1] add task title\n[2] Update task status\n[3] view tasks in Different catagories\n[4] delete task\n[5] Exit Program:- ");
                int input = int.Parse(Console.ReadLine());

                #region ADD TASK
                if (input == 1)
                {
                    TaskOp.AddTask(TaskOp.TaskTitle, TaskOp.TaskDescription, TaskOp.TaskDueDate, TaskOp.TaskPriority, TaskOp.TaskStatus);
                }
                #endregion

                #region UPDATE STATUS
                else if (input == 2)
                {
                    TaskOp.UpdateTaskStatus(TaskOp.TaskTitle, TaskOp.TaskStatus);
                }
                #endregion

                #region VIEW TASK
                else if (input == 3)
                {
                    TaskOp.ViewTask(TaskOp.TaskTitle, TaskOp.TaskDescription, TaskOp.TaskDueDate, TaskOp.TaskPriority, TaskOp.TaskStatus);
                }

                #endregion

                #region DELETE TASK
                else if (input == 4)
                {
                    TaskOp.DeleteTask(TaskOp.TaskTitle, TaskOp.TaskDescription, TaskOp.TaskDueDate, TaskOp.TaskPriority, TaskOp.TaskStatus);
                }
                #endregion

                #region Exit
                else if (input == 5)
                {
                    Console.WriteLine("\n exit safely ! ");
                    break;
                }
                #endregion
            }
        }
    }
}
