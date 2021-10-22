using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Elevator
    {
        private Queue<Command> commands;

        public Elevator()
        {
            commands = new Queue<Command>();
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