using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Domain.Enums;
using Domain.Enums.Extensions;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class AutomaticElevator : Elevator
    {
        private IElevatorSimulator simulator => base._simulator;
        private Timer timer;
        public AutomaticElevator(IElevatorLogger logger, IElevatorSimulator simulator, Timer timer, FloorEnum currentFloor = FloorEnum.Ground) : base(logger, simulator, currentFloor)
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
            var floor = GetRandomValidFloor();
            var type = GetRandomCommandTypeFor(floor);

            base.AddCommand(new Command(floor, type));
        }

        private FloorEnum GetRandomValidFloor()
        {
            var floors = Enum.GetValues<FloorEnum>();

            var validFloors = floors.Where(p => p != CurrentFloor);

            var floor = (FloorEnum)PickRandomFrom(validFloors.Select(p => (object)p));

            return floor;
        }

        private CommandTypeEnum GetRandomCommandTypeFor(FloorEnum floor)
        {
            var types = Enum.GetValues<CommandTypeEnum>();

            var validTypes = types.Where(p => p.IsValidFor(floor));

            var type = (CommandTypeEnum)PickRandomFrom(validTypes.Select(p => (object)p));

            return type;
        }

        private object PickRandomFrom(IEnumerable<object> items)
        {
            var random = new Random();
            return items.OrderBy(p => random.Next()).First();
        }
    }
}