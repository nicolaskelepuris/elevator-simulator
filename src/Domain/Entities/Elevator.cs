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
        public const int MILLISECONDS_TO_PERFORM_SHORT_STOP_AT_FLOOR = 500;
        private Queue<Command> commands;
        public FloorEnum CurrentFloor { get; private set; }
        public ElevatorStatusEnum Status { get; private set; }
        private delegate Task MoveElevatorEventHandler(object sender, MoveElevatorEventArgs e);
        private event MoveElevatorEventHandler MoveElevatorEvent;

        public Elevator()
        {
            commands = new Queue<Command>();
            CurrentFloor = FloorEnum.Ground;
            Stop();
        }

        private void Stop()
        {
            Status = ElevatorStatusEnum.Stopped;
        }

        public void AddCommand(Command command)
        {
            commands.Enqueue(command);

            var nextCommand = commands.Peek();

            if (ShouldMoveUp(nextCommand))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Up));
            }
            else if (ShouldMoveDown(nextCommand))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Down));
            }
        }

        private bool ShouldMoveUp(Command nextCommand)
        {
            return nextCommand.Floor > CurrentFloor && Status == ElevatorStatusEnum.Stopped;
        }

        public bool CommandQueueContains(Command command)
        {
            return commands.Any(c => c.Equals(command));
        }

        private void OnMoveElevatorEvent(MoveElevatorEventArgs e)
        {
            switch (e.MoveType)
            {
                case MoveTypeEnum.Up:
                    MoveElevatorEvent -= MoveDown;
                    MoveElevatorEvent += MoveUp;
                    break;
                case MoveTypeEnum.Down:
                    MoveElevatorEvent -= MoveUp;
                    MoveElevatorEvent += MoveDown;
                    break;
                default:
                    return;
            }
            var raiseEvent = MoveElevatorEvent;

            raiseEvent?.Invoke(this, e);
        }

        private async Task MoveUp(object sender, MoveElevatorEventArgs e)
        {
            Status = ElevatorStatusEnum.GoingUp;

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

            Stop();

            if (HasNextCommand() && ShouldMoveDown(commands.Peek()))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Down));
            }
        }

        private bool ShouldContinueMovingUp()
        {
            return commands.Any(c => c.Floor > CurrentFloor && c.Type == CommandTypeEnum.Internal || c.Type == CommandTypeEnum.Up);
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

        private bool ShouldMakeShortStop(IEnumerable<Command> commandsToGoToCurrentFloor)
        {
            return commandsToGoToCurrentFloor.Any(c => CommandQueueContains(c));
        }

        private void RemoveCommands(IEnumerable<Command> commandsToRemove)
        {
            var commandsAfterRemove = commands.Where(c => !commandsToRemove.Any(command => command.Equals(c)));

            this.commands = new Queue<Command>(commandsAfterRemove);
        }

        private bool ShouldMoveDown(Command nextCommand)
        {
            return nextCommand.Floor < CurrentFloor && Status == ElevatorStatusEnum.Stopped;
        }

        private bool HasNextCommand()
        {
            return commands.Count != 0;
        }

        private async Task MoveDown(object sender, MoveElevatorEventArgs e)
        {
            Status = ElevatorStatusEnum.GoingDown;

            while (ShouldContinueMovingDown())
            {
                await MoveToNextFloorAsync(MoveTypeEnum.Down);
                var commandsToGoToCurrentFloor = new List<Command>()
                {
                    new Command(CurrentFloor, CommandTypeEnum.Internal),
                    new Command(CurrentFloor, CommandTypeEnum.Down)
                };

                if (ShouldMakeShortStop(commandsToGoToCurrentFloor))
                {
                    await Task.Delay(MILLISECONDS_TO_PERFORM_SHORT_STOP_AT_FLOOR);
                }

                RemoveCommands(commandsToGoToCurrentFloor);
            }

            Stop();

            if (HasNextCommand() && ShouldMoveUp(commands.Peek()))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Up));
            }
        }

        private bool ShouldContinueMovingDown()
        {
            return commands.Any(c => c.Floor < CurrentFloor && c.Type == CommandTypeEnum.Internal || c.Type == CommandTypeEnum.Down);
        }
    }
}