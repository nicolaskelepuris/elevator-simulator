using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Entities;
using Domain.Enums;

namespace Presentation
{
    public partial class MainPage : Form
    {
        private Elevator elevator;
        
        public MainPage()
        {
            elevator = new Elevator();
            InitializeComponent();
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
    }
}
