using System.Threading.Tasks;
using d01_ex01.Events;

namespace d01_ex01.Tasks
{
    public record TaskWontDoEvent:Event
    {
        public TaskWontDoEvent()
        {
            this.State = TaskState.WontDo;
        }
    }
}