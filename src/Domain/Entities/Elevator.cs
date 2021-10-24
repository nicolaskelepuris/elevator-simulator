using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Events;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Elevator
    {
        private Queue<Command> commands;
        private FloorEnum currentFloor;
        public FloorEnum CurrentFloor
        {
            get { return currentFloor; }
            set
            {
                currentFloor = value;
                CurrentFloorChangedEvent?.Invoke(this, new CurrentFloorChangedEventArgs(currentFloor));
            }
        }
        public ElevatorStatusEnum Status { get; private set; }
        private delegate Task MoveElevatorEventHandler(object sender, MoveElevatorEventArgs e);
        private event MoveElevatorEventHandler MoveElevatorEvent;

        public delegate void CurrentFloorChangedEventHandler(object sender, CurrentFloorChangedEventArgs e);
        private event CurrentFloorChangedEventHandler CurrentFloorChangedEvent;
        private readonly IElevatorLogger _logger;
        private readonly IElevatorDelaySimulator _delaySimulator;

        public Elevator(IElevatorLogger logger, IElevatorDelaySimulator delaySimulator)
        {
            commands = new Queue<Command>();
            CurrentFloor = FloorEnum.Ground;
            Stop();
            _logger = logger;
            _delaySimulator = delaySimulator;
        }

        private void Stop()
        {
            Status = ElevatorStatusEnum.Stopped;
        }

        public void AddCommand(Command command)
        {
            if (command.Floor == CurrentFloor) return;
            
            if (command.Type == CommandTypeEnum.Internal)
            {
                _logger.LogInternalCommand(command);
            }

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
                    SubscribeMoveUpEventHandler();
                    break;
                case MoveTypeEnum.Down:
                    SubscribeMoveDownEventHandler();
                    break;
                default:
                    return;
            }

            MoveElevatorEvent.Invoke(this, e);
        }

        private void SubscribeMoveUpEventHandler()
        {
            MoveElevatorEvent -= MoveDownEventHandler;
            MoveElevatorEvent += MoveUpEventHandler;
        }

        private void SubscribeMoveDownEventHandler()
        {
            MoveElevatorEvent -= MoveUpEventHandler;
            MoveElevatorEvent += MoveDownEventHandler;
        }

        private async Task MoveUpEventHandler(object sender, MoveElevatorEventArgs e)
        {
            Status = ElevatorStatusEnum.GoingUp;

            while (ShouldContinueMovingUp())
            {
                await MoveToNextFloorAsync(MoveTypeEnum.Up);

                await VisitCurrentFloorAndRemoveFromCommands();
            }

            Stop();

            if (HasNextCommand() && ShouldMoveDown(commands.Peek()))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Down));
            }
        }

        private async Task VisitCurrentFloorAndRemoveFromCommands()
        {
            var commandsToGoToCurrentFloor = GetCommandsToGoToCurrentFloor();

            if (ShouldVisitCurrentFloor(commandsToGoToCurrentFloor))
            {
                await VisitCurrentFloorAsync();
            }

            RemoveCommands(commandsToGoToCurrentFloor);
        }

        private List<Command> GetCommandsToGoToCurrentFloor()
        {
            var commandsCurrentFloor = new List<Command>()
            {
                new Command(CurrentFloor, CommandTypeEnum.Internal)
            };

            if (IsGoingUp || !commands.Any(c => c.Floor < CurrentFloor))
            {
                commandsCurrentFloor.Add(new Command(CurrentFloor, CommandTypeEnum.Up));
            }

            if (IsGoingDown || !commands.Any(c => c.Floor > CurrentFloor))
            {
                commandsCurrentFloor.Add(new Command(CurrentFloor, CommandTypeEnum.Down));
            }

            return commandsCurrentFloor;
        }

        private bool IsGoingUp => Status == ElevatorStatusEnum.GoingUp;
        private bool IsGoingDown => Status == ElevatorStatusEnum.GoingDown;

        private bool ShouldContinueMovingUp()
        {
            return commands.Any(c => c.Floor > CurrentFloor);
        }

        private async Task MoveToNextFloorAsync(MoveTypeEnum moveType)
        {
            await _delaySimulator.SimulateMoveToNextFloor();

            if (moveType == MoveTypeEnum.Up)
            {
                CurrentFloor += 1;
            }
            else
            {
                CurrentFloor -= 1;
            }
        }

        private bool ShouldVisitCurrentFloor(IEnumerable<Command> commandsToGoToCurrentFloor)
        {
            return commandsToGoToCurrentFloor.Any(c => CommandQueueContains(c));
        }

        private async Task VisitCurrentFloorAsync()
        {
            _logger.LogVisitedFloor(CurrentFloor);
            await _delaySimulator.SimulateFloorVisit();
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

        private async Task MoveDownEventHandler(object sender, MoveElevatorEventArgs e)
        {
            Status = ElevatorStatusEnum.GoingDown;

            while (ShouldContinueMovingDown())
            {
                await MoveToNextFloorAsync(MoveTypeEnum.Down);

                await VisitCurrentFloorAndRemoveFromCommands();
            }

            Stop();

            if (HasNextCommand() && ShouldMoveUp(commands.Peek()))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Up));
            }
        }

        private bool ShouldContinueMovingDown()
        {
            return commands.Any(c => c.Floor < CurrentFloor && (c.Type == CommandTypeEnum.Internal || c.Type == CommandTypeEnum.Down));
        }

        public void AddCurrentFloorChangedEventSubscriber(CurrentFloorChangedEventHandler handler)
        {
            CurrentFloorChangedEvent += handler;
        }
    }
}