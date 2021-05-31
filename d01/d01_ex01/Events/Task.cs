using System;
using System.Collections.Generic;
using d01_ex01.Tasks;

namespace d01_ex01.Events
{
    public class Task
    {
        private string title;
        private string summary;
        private TaskType type;
        private TaskPriority priority;
        private DateTime? dueDate;
        private List<Event> eventHistory = new List<Event>();

        public string Title => title;

        public string Summary => summary;

        public TaskType Type => type;

        public TaskPriority Priority => priority;

        public DateTime? DueDate => dueDate;

        public TaskState State()
        {
            return (eventHistory[0].State);
        }

        public Task(string title, string summary, TaskType type, DateTime? dueDate, TaskPriority? priority)
        {
            this.title = title;
            this.summary = summary;
            this.type = type;
            this.dueDate = dueDate;

            if (priority == null)
                this.priority = TaskPriority.Normal;
            else
                this.priority = (TaskPriority) priority;
            
            eventHistory.Add(new CreatedEvent());
        }

        public void WontDo()
        {
            if (State() != TaskState.Done)
            {
                eventHistory.Insert(0, new TaskWontDoEvent());
                Console.WriteLine($"Задача {title} более не актуальна!", title);
            }
            else if (State() == TaskState.Done)
                Console.WriteLine($"Задача {title} выполнена!", title);
        }
        
        public void Done()
        {
            if (State() != TaskState.WontDo)
            {
                eventHistory.Insert(0, new TaskDoneEvent());
                Console.WriteLine($"Задача {title} выполнена!", title);
            }
            else if (State() == TaskState.WontDo)
                Console.WriteLine($"Задача {title} более не актуальна!", title);
        }

        public override string ToString()
        {
            var checkDate = dueDate.HasValue ? String.Format("{0:d}", dueDate) : "";
            var checkSummary = summary ?? "";
            if (checkDate != "")
                return ($"{title}\n[{type}] [{State()}]\nPriority: {priority}, Due till {checkDate}\n{checkSummary}");
            return ($"{title}\n[{type}] [{State()}]\nPriority: {priority}\n{checkSummary}");
        }
    }
}