using Domain.Interfaces;

namespace Domain.Entities
{
    public class AutomaticElevator : Elevator
    {
        public AutomaticElevator(IElevatorLogger logger, IElevatorSimulator simulator) : base(logger, simulator)
        {
        }

        public new void AddCommand(Command command)
        {
            if (ShouldIgnore(command)) return;

            base.AddCommand(command);
        }

        private bool ShouldIgnore(Command command)
        {
            return command.Type != Enums.CommandTypeEnum.Internal;
        }
    }
}