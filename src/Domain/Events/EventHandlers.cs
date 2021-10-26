using System.Threading.Tasks;

namespace Domain.Events
{
    public static class EventHandlers
    {
        public delegate void ElevatorDataChangedEventHandler(object sender, ElevatorDataChangedEventArgs e);
        public delegate Task MoveElevatorEventHandler(object sender, MoveElevatorEventArgs e);
    }
}