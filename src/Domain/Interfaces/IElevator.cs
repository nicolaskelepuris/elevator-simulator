using Domain.Entities;
using Domain.Enums;
using static Domain.Events.EventHandlers;

namespace Domain.Interfaces
{
    public interface IElevator
    {
        FloorEnum CurrentFloor { get; }
        ElevatorStatusEnum Status { get; }
        void AddCommand(Command command);
        bool ContainsCommand(Command command);
        void AddDataChangedEventSubscriber(ElevatorDataChangedEventHandler handler);
    }
}