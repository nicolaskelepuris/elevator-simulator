using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Services
{
    public class ElevatorLogger : IElevatorLogger
    {
        private List<int> visitedFloors;
        public List<int> VisitedFloors { get => new List<int>(visitedFloors ?? Enumerable.Empty<int>()); }


        private List<int> internalCommands;
        public List<int> InternalCommands { get => new List<int>(internalCommands ?? Enumerable.Empty<int>()); }

        public ElevatorLogger()
        {
            visitedFloors = new List<int>();
            internalCommands = new List<int>();
        }

        public void LogInternalCommand(Command command)
        {
            var floor = (int)command.Floor;
            internalCommands.Add(floor);
        }

        public void LogVisitedFloor(FloorEnum floor)
        {
            visitedFloors.Add((int)floor);
        }
    }
}