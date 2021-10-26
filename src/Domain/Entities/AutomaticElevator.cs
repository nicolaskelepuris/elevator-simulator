using System;
using System.Linq;
using System.Timers;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class AutomaticElevator : Elevator, IDisposable
    {
        private IElevatorSimulator simulator => base._simulator;
        private Timer timer;
        public AutomaticElevator(IElevatorLogger logger, IElevatorSimulator simulator) : base(logger, simulator)
        {
            InitializeTimer();
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

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(TimerEventHandler);
            timer.Interval = simulator.MillisecondsIntervalToGenerateRandomCommand;
            timer.Start();
        }

        private void TimerEventHandler(object sender, ElapsedEventArgs e)
        {
            AddRandomValidCommand();
        }

        private void AddRandomValidCommand()
        {
            var type = GetRandomCommandType();
            var floor = GetRandomValidFloor();

            base.AddCommand(new Command(floor, type));
        }

        private CommandTypeEnum GetRandomCommandType()
        {
            var typesCount = Enum.GetValues<CommandTypeEnum>().Length;
            var randomValue = new Random().Next(0, typesCount);

            var type = (CommandTypeEnum)randomValue;

            return type;
        }

        private FloorEnum GetRandomValidFloor()
        {
            var floors = Enum.GetValues<FloorEnum>();
            var random = new Random();

            var validFloors = floors.Where(p => p != CurrentFloor);

            var floor = validFloors.OrderBy(p => random.Next()).First();

            return floor;
        }

        public void Dispose()
        {
            timer.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}