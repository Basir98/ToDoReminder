using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ToDoReminder
{
    public class TaskManager
    {
        List<Task> taskList;

        public TaskManager()
        {
            taskList = new List<Task>();
        }

        /*
         * Thid method recieves a new Task as parameter and adds this task to the task list
         */
        public bool AddNewTask(Task newTask)
        {
            bool ok = true;
            if (newTask != null)
                taskList.Add(newTask);
            else
                ok = false;

            return ok;
        }

        public bool removeThisTask(int position)
        {
            if(position != -1)
            {
                taskList.RemoveAt(position);
                return true;
            }
            return false;
        }

        public Task editThisTask(Task thisTask, Task newTask)
        {
            //taskList.Find(Task => Task.Description == thisTask.Description).Description= newString;
            thisTask.Description = newTask.Description;
            thisTask.DateTime = newTask.DateTime;
            thisTask.Priority = newTask.Priority;

            return new Task(newTask.DateTime, newTask.Description, newTask.Priority);
        }

        public List<Task> getList()
        {
            return taskList;
        }

        /*
         * This method gets all the info about all tasks stored in the task list. 
         */
        public string[] GetInfoStringsList()
        {
            string[] infoStrings = new string[taskList.Count];
            for (int i = 0; i < infoStrings.Length; i++)
            {
                infoStrings[i] = taskList[i].ToString();
            }
            return infoStrings;
        }
    }
}
