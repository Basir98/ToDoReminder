using NUnit.Framework;
using ToDoReminder;
using System;

namespace ToDoReminderNUnitTests
{
    public class TaskTests
    {

        [Test]
        public void task_description_Test()
        {
            var task = new Task();
            task.Description = "test";

            Assert.AreEqual("test", task.Description);
        }

        [Test]
        public void task_with_empty_description_Test()
        {
            var task = new Task();

            Assert.AreEqual(null, task.Description);
        }

        [Test]
        public void task_time_Test()
        {
            var task = new Task();
            DateTime date = task.DateTime;

            string expected = date.Hour.ToString() + ":" + date.Minute.ToString();
            Assert.AreEqual(expected, task.GetTimeString());
        }

        [Test]
        public void task_Priority_Test()
        {
            var task = new Task();

            Assert.AreEqual(PriorityType.Normal, task.Priority);
            Assert.AreEqual(PriorityType.Normal.ToString(), task.GetPriorityString());
        }

        [Test]
        public void task_with_valid_params_Test()
        {
            DateTime date = new DateTime();

            var task = new Task(date, "New Task", PriorityType.Important);
            string expected = date.Hour.ToString() + ":" + date.Minute.ToString();

            Assert.AreEqual(PriorityType.Important, task.Priority);
            Assert.AreEqual(PriorityType.Important.ToString(), task.GetPriorityString());
            Assert.AreEqual(expected, task.GetTimeString());
            Assert.AreEqual("New Task", task.Description);
        }


    }
}