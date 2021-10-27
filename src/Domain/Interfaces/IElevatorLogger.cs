using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IElevatorLogger
    {
        List<int> InternalCommands { get; }
        List<int> VisitedFloors { get; }
        void LogInternalCommand(Command command);
        void LogVisitedFloor(FloorEnum floor);
    }
}