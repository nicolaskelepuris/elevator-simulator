using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Events;

namespace Domain.Entities
{
    public class Elevator
    {
        public const int MILLISECONDS_TO_MOVE_BEETWEEN_FLOORS = 1000;
        private const int MILLISECONDS_TO_PERFORM_SHORT_STOP_AT_FLOOR = 500;
        private Queue<Command> commands;
        public FloorEnum CurrentFloor { get; private set; }
        public ElevatorStatusEnum Status { get; private set; }
        private delegate Task MoveElevatorEventHandler(object sender, MoveElevatorEventArgs e);
        private event MoveElevatorEventHandler MoveElevatorEvent;

        public Elevator()
        {
            commands = new Queue<Command>();
            CurrentFloor = FloorEnum.Ground;
            Status = ElevatorStatusEnum.Stopped;
        }

        public void AddCommand(Command command)
        {
            commands.Enqueue(command);

            switch (Status)
            {
                case ElevatorStatusEnum.Stopped:
                    MoveElevatorEvent += MoveUp;
                    OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Up));
                    break;
                case ElevatorStatusEnum.GoingUp:
                    return;
                case ElevatorStatusEnum.GoingDown:
                    return;
                default:
                    return;
            }
        }

        public bool CommandQueueContains(Command command)
        {
            return commands.Any(c => c.Equals(command));
        }

        private void OnMoveElevatorEvent(MoveElevatorEventArgs e)
        {
            var raiseEvent = MoveElevatorEvent;

            raiseEvent?.Invoke(this, e);
        }

        private async Task MoveUp(object sender, MoveElevatorEventArgs e)
        {
            while (ShouldContinueMovingUp())
            {
                await MoveToNextFloorAsync(MoveTypeEnum.Up);
                var commandsToGoToCurrentFloor = new List<Command>()
                {
                    new Command(CurrentFloor, CommandTypeEnum.Internal),
                    new Command(CurrentFloor, CommandTypeEnum.Up)
                };

                if (ShouldMakeShortStop(commandsToGoToCurrentFloor))
                {
                    await Task.Delay(MILLISECONDS_TO_PERFORM_SHORT_STOP_AT_FLOOR);
                }

                RemoveCommands(commandsToGoToCurrentFloor);
            }
        }

        private bool ShouldContinueMovingUp()
        {
            return commands.Any(c => c.Floor > CurrentFloor && c.Type == CommandTypeEnum.Internal || c.Type == CommandTypeEnum.Up);
        }

        private void RemoveCommands(IEnumerable<Command> commandsToRemove)
        {
            var commandsAfterRemove = commands.Where(c => !commandsToRemove.Any(command => command.Equals(c)));

            this.commands = new Queue<Command>(commandsAfterRemove);
        }

        private bool ShouldMakeShortStop(IEnumerable<Command> commandsToGoToCurrentFloor)
        {
            return commandsToGoToCurrentFloor.Any(c => CommandQueueContains(c));
        }

        private async Task MoveToNextFloorAsync(MoveTypeEnum moveType)
        {
            await Task.Delay(MILLISECONDS_TO_MOVE_BEETWEEN_FLOORS);

            if (moveType == MoveTypeEnum.Up)
            {
                CurrentFloor += 1;
            }
            else
            {
                CurrentFloor -= 1;
            }
        }
    }
}