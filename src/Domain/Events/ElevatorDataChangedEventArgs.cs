using Domain.Entities;
using Domain.Enums;

namespace Domain.Events
{
    public class ElevatorDataChangedEventArgs
    {
        public ElevatorDataChangedEventArgs(Elevator elevator)
        {
            Floor = elevator.CurrentFloor;
            Status = elevator.Status;
        }

        public FloorEnum Floor { get; private set; }
        public ElevatorStatusEnum Status { get; private set; }
    }
}