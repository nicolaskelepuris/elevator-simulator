using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IElevatorLogger
    {
        List<int> CommandFloors { get; }
        List<int> VisitedFloors { get; }
        void LogInternalCommand(Command command);
        void LogVisitedFloor(FloorEnum floor);
    }
}