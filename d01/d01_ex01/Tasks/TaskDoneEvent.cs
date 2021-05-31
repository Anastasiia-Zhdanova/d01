using d01_ex01.Events;

namespace d01_ex01.Tasks
{
    public record TaskDoneEvent:Event
    {
        public TaskDoneEvent()
        {
            this.State = TaskState.Done;
        }
    }
}