using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Events;
using Domain.Interfaces;
using static Domain.Events.EventHandlers;

namespace Domain.Entities
{
    public class Elevator : IElevator
    {
        private Queue<Command> commands;
        private FloorEnum currentFloor;
        public FloorEnum CurrentFloor
        {
            get { return currentFloor; }
            set
            {
                currentFloor = value;
                ElevatorDataChangedEvent?.Invoke(this, new ElevatorDataChangedEventArgs(this));
            }
        }

        private ElevatorStatusEnum status;
        public ElevatorStatusEnum Status
        {
            get { return status; }
            private set
            {
                status = value;
                ElevatorDataChangedEvent?.Invoke(this, new ElevatorDataChangedEventArgs(this));
            }
        }

        private event MoveElevatorEventHandler MoveElevatorEvent;
        private event ElevatorDataChangedEventHandler ElevatorDataChangedEvent;

        private readonly IElevatorLogger _logger;
        protected readonly IElevatorSimulator _simulator;

        public Elevator(IElevatorLogger logger, IElevatorSimulator simulator, FloorEnum currentFloor = FloorEnum.Ground)
        {
            commands = new Queue<Command>();
            CurrentFloor = currentFloor;
            Stop();
            _logger = logger;
            _simulator = simulator;
        }

        private void Stop()
        {
            Status = ElevatorStatusEnum.Stopped;
        }

        public void AddCommand(Command command)
        {
            if (ShouldIgnore(command)) return;
            
            LogCommand(command);

            commands.Enqueue(command);

            if (IsStopped)
            {
                ExecuteCommand(commands.Peek());
            }
        }

        private void LogCommand(Command command)
        {
            if (command.Type == CommandTypeEnum.Internal)
            {
                _logger.LogInternalCommand(command);
            }
        }

        private bool ShouldIgnore(Command command)
        {
            return command.Floor == CurrentFloor && IsStopped;
        }

        private void ExecuteCommand(Command command)
        {
            if (ShouldMoveUp(command))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Up));
            }
            else if (ShouldMoveDown(command))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Down));
            }
        }

        private bool IsStopped => Status == ElevatorStatusEnum.Stopped;

        private bool ShouldMoveUp(Command nextCommand)
        {
            return nextCommand.Floor > CurrentFloor && IsStopped;
        }

        public bool ContainsCommand(Command command)
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
            MoveElevatorEvent = null;
            MoveElevatorEvent += MoveUpEventHandler;
        }

        private void SubscribeMoveDownEventHandler()
        {
            MoveElevatorEvent = null;
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

            if (HasNextCommand() && ShouldMoveDown(commands.Peek()))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Down));
                return;
            }

            Stop();
        }

        private async Task VisitCurrentFloorAndRemoveFromCommands()
        {
            var possibleCommandsToGoToCurrentFloor = GetPossibleCommandsToGoToCurrentFloor();

            if (ShouldVisitCurrentFloor(possibleCommandsToGoToCurrentFloor))
            {
                await VisitCurrentFloorAsync();
            }

            RemoveCommands(possibleCommandsToGoToCurrentFloor);
        }

        private List<Command> GetPossibleCommandsToGoToCurrentFloor()
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
            await _simulator.SimulateMoveToNextFloor();

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
            return commandsToGoToCurrentFloor.Any(c => ContainsCommand(c));
        }

        private async Task VisitCurrentFloorAsync()
        {
            var currentStatus = Status;
            Status = ElevatorStatusEnum.VisitingFloor;
            _logger.LogVisitedFloor(CurrentFloor);
            await _simulator.SimulateFloorVisit();
            Status = currentStatus;
        }

        private void RemoveCommands(IEnumerable<Command> commandsToRemove)
        {
            var commandsAfterRemove = commands.Where(c => !commandsToRemove.Any(command => command.Equals(c)));

            commands = new Queue<Command>(commandsAfterRemove);
        }

        private bool ShouldMoveDown(Command nextCommand)
        {
            return nextCommand.Floor < CurrentFloor && IsStopped;
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

            if (HasNextCommand() && ShouldMoveUp(commands.Peek()))
            {
                OnMoveElevatorEvent(new MoveElevatorEventArgs(MoveTypeEnum.Up));
                return;
            }
            
            Stop();
        }

        private bool ShouldContinueMovingDown()
        {
            return commands.Any(c => c.Floor < CurrentFloor);
        }

        public void AddDataChangedEventSubscriber(ElevatorDataChangedEventHandler handler)
        {
            ElevatorDataChangedEvent += handler;
        }
    }
}