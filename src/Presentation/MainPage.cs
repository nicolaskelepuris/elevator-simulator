using System;
using System.Windows.Forms;
using Domain.Entities;
using Domain.Enums;
using Domain.Events;
using Domain.Services;

namespace Presentation
{
    public partial class MainPage : Form
    {
        private Elevator elevator;

        public MainPage()
        {
            elevator = new Elevator(new ElevatorLogger(), new ElevatorSimulator());
            InitializeComponent();
            BindControls();
        }

        private void BindControls()
        {
            elevator.AddCurrentFloorChangedEventSubscriber(UpdateCurrentFloorTextBox);
        }

        private void UpdateCurrentFloorTextBox(object sender, CurrentFloorChangedEventArgs e)
        {
            var floor = (int)e.Floor;
            this.currentFloorBox.Text = floor.ToString();
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
    }
}
