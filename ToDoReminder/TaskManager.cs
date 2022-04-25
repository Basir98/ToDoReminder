using System;
using System.Collections.Generic;
using System.Text;

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
