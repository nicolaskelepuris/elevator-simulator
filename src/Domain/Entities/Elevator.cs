using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Entities
{
    public class Elevator
    {
        private Queue<Command> commands;
        public FloorEnum CurrentFloor { get; private set; }
        public ElevatorStatusEnum Status { get; private set; }

        public Elevator()
        {
            commands = new Queue<Command>();
            CurrentFloor = FloorEnum.Ground;
            Status = ElevatorStatusEnum.Stopped;
        }

        public void AddCommand(Command command)
        {
            commands.Enqueue(command);
        }

        public bool CommandQueueContains(Command command)
        {
            return commands.Any(c => c.Equals(command));
        }
    }
}