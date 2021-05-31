using System.Threading.Tasks;
using d01_ex01.Events;

namespace d01_ex01.Tasks
{
    public record Event
    {
        public TaskState State { get; init; }
    }
}