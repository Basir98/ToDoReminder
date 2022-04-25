using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoReminder
{
    public class Task
    {
        private DateTime date;
        private string description;
        private PriorityType priority;

        public DateTime DateTime
        {
            get { return date; }
            set { this.date = value; }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    this.description = value;
            }
        }
         
        public PriorityType Priority
        {
            get { return priority; }
            set { this.priority = value; }
        }

        public Task()
        {
            priority = PriorityType.Normal;
        }

        public Task(DateTime taskDate, string description, PriorityType priority)
        {
            DateTime = taskDate;
            Description = description;
            Priority = priority;
        }

        public string GetTimeString()
        {
            return date.Hour.ToString() + ":" + date.Minute.ToString();
        }

        public string GetPriorityString()
        {
            return priority.ToString();
        }

        public override string ToString()
        {
            string textOut = $"{date.ToLongDateString(),-20} {GetTimeString(),10} " +
                $"\t\t{GetPriorityString(),-16} \t\t {description,-20}";
            return textOut;
        }
    }
}
