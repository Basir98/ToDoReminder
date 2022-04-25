using NUnit.Framework;
using ToDoReminder;
using System;
using System.Collections.Generic;



namespace ToDoReminderNUnitTests
{
    class TaskManagerTests
    {
        [Test]
        public void task_manager_Add_New_Task_Test()
        {
            var task = new Task();
            var taskManager = new TaskManager();

            Assert.AreEqual(true, taskManager.AddNewTask(task));
        }

        [Test]
        public void task_manager_Get_Task_Info_Test()
        {
            DateTime date = new DateTime();
            var task1 = new Task(date, "New Task1", PriorityType.Important);

            var taskManager = new TaskManager();
            taskManager.AddNewTask(task1);

            string[] expectedStrings = new string[1];
            for (int i = 0; i < taskManager.getList().Count; i++)
            {
                expectedStrings[i] = taskManager.getList()[i].ToString();
            }
            Assert.AreEqual(expectedStrings, taskManager.GetInfoStringsList());
        }
    }
}
