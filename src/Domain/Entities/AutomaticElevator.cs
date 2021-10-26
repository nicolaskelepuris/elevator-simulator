using System;
using System.Linq;
using System.Windows.Forms;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class AutomaticElevator : Elevator
    {
        private IElevatorSimulator simulator => base._simulator;
        private Timer timer;
        public AutomaticElevator(IElevatorLogger logger, IElevatorSimulator simulator, Timer timer) : base(logger, simulator)
        {
            InitializeTimer(timer);
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

        private void InitializeTimer(Timer timer)
        {
            this.timer = new Timer();
            this.timer.Tick += new EventHandler(TimerEventHandler);
            this.timer.Interval = simulator.MillisecondsIntervalToGenerateRandomCommand;
            this.timer.Start();
        }

        private void TimerEventHandler(object sender, EventArgs e)
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
    }
}