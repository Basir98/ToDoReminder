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

        [Test]
        public void task_manager_Edit_This_Task_Test()
        {
            DateTime date = new DateTime();

            var thisTask = new Task(date, "New Task1", PriorityType.Important);
            var newTask = new Task(date, "New Task2", PriorityType.Normal);
            var taskManager = new TaskManager();

            var editedTask = taskManager.editThisTask(thisTask, newTask);

            Assert.AreEqual(newTask.Description, editedTask.Description);
            Assert.AreEqual(newTask.DateTime, editedTask.DateTime);
            Assert.AreEqual(newTask.Priority, editedTask.Priority);
        }

        [Test]
        public void task_manager_Remove_This_Task_Test()
        {
            DateTime date = new DateTime();

            var task1 = new Task(date, "New Task1", PriorityType.Important);
            var task2 = new Task(date, "New Task2", PriorityType.Normal);
            var task3 = new Task(date, "New Task3", PriorityType.Not_important);

            var taskManager = new TaskManager();
            taskManager.AddNewTask(task1);
            taskManager.AddNewTask(task2);
            taskManager.AddNewTask(task3);

            taskManager.removeThisTask(1);

            Assert.AreEqual(2, taskManager.getList().Count);
        }

    }
}
