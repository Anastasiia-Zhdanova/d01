using d01_ex01.Events;

namespace d01_ex01.Tasks
{
    public record CreatedEvent:Event
    {
        public CreatedEvent()
        {
            this.State = TaskState.New;
        }
    }
}