using System;
using System.Windows.Forms;
using Domain.Entities;
using Domain.Enums;
using Domain.Enums.Extensions;
using Domain.Events;
using Domain.Interfaces;
using Domain.Services;

namespace Presentation
{
    public partial class MainPage : Form
    {
        private IElevator elevator;
        private Timer timer;
        private IElevatorLogger logger;
        private IElevatorSimulator simulator;

        public MainPage()
        {
            logger = new ElevatorLogger();
            simulator = new ElevatorSimulator();
            InitializeManualElevator();
            InitializeComponent();
        }

        private void InitializeManualElevator()
        {
            DisposeTimer();
            elevator = new Elevator(logger, simulator);
            SubscribeToElevatorDataChangedEvent();
        }

        private void InitializeAutomaticElevator()
        {
            DisposeTimer();
            timer = new Timer();
            elevator = new AutomaticElevator(logger, simulator, timer);
            SubscribeToElevatorDataChangedEvent();
        }

        private void DisposeTimer()
        {
            if (timer != null)
            {
                timer.Dispose();
            }
        }

        private void SubscribeToElevatorDataChangedEvent()
        {
            elevator.AddDataChangedEventSubscriber(UpdateElevatorData);
        }

        private void UpdateElevatorData(object sender, ElevatorDataChangedEventArgs e)
        {
            UpdateCurrentFloorTextBox(e);
            UpdateStatusTextBox(e);
        }

        private void UpdateCurrentFloorTextBox(ElevatorDataChangedEventArgs elevatorData)
        {
            var floor = (int)elevatorData.Floor;
            this.currentFloorBox.Text = floor.ToString();
        }

        private void UpdateStatusTextBox(ElevatorDataChangedEventArgs elevatorData)
        {
            var status = elevatorData.Status.GetDescription();
            this.statusTextBox.Text = status;
        }

        private void AddInternalCommand(FloorEnum floor)
        {
            var command = new Command(floor, CommandTypeEnum.Internal);
            elevator.AddCommand(command);
        }

        private void innerGround_Click(object sender, EventArgs e)
        {
            AddInternalCommand(FloorEnum.Ground);
        }

        private void inner1_Click(object sender, EventArgs e)
        {
            AddInternalCommand(FloorEnum.One);
        }

        private void inner2_Click(object sender, EventArgs e)
        {
            AddInternalCommand(FloorEnum.Two);
        }

        private void inner3_Click(object sender, EventArgs e)
        {
            AddInternalCommand(FloorEnum.Three);
        }

        private void inner4_Click(object sender, EventArgs e)
        {
            AddInternalCommand(FloorEnum.Four);
        }

        private void AddExternalUpCommand(FloorEnum floor)
        {
            var command = new Command(floor, CommandTypeEnum.Up);
            elevator.AddCommand(command);
        }

        private void AddExternalDownCommand(FloorEnum floor)
        {
            var command = new Command(floor, CommandTypeEnum.Down);
            elevator.AddCommand(command);
        }

        private void externalUpGround_Click(object sender, EventArgs e)
        {
            AddExternalUpCommand(FloorEnum.Ground);
        }

        private void externalUp1_Click(object sender, EventArgs e)
        {
            AddExternalUpCommand(FloorEnum.One);
        }

        private void externalDown1_Click(object sender, EventArgs e)
        {
            AddExternalDownCommand(FloorEnum.One);
        }

        private void externalUp2_Click(object sender, EventArgs e)
        {
            AddExternalUpCommand(FloorEnum.Two);
        }

        private void externalDown2_Click(object sender, EventArgs e)
        {
            AddExternalDownCommand(FloorEnum.Two);
        }

        private void externalUp3_Click(object sender, EventArgs e)
        {
            AddExternalUpCommand(FloorEnum.Three);
        }

        private void externalDown3_Click(object sender, EventArgs e)
        {
            AddExternalDownCommand(FloorEnum.Three);
        }

        private void externalDown4_Click(object sender, EventArgs e)
        {
            AddExternalDownCommand(FloorEnum.Four);
        }

        private void manualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            InitializeManualElevator();
        }

        private void automaticRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            InitializeAutomaticElevator();
        }
    }
}
