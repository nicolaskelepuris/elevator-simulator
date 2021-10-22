using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace tests
{
    public class ElevatorTests
    {
        private const int MILLISECONDS_FOR_SAFETY_TEST = 100;

        [Fact]
        public void ShouldAddCommand()
        {
            var floor = FloorEnum.Two;
            var type = CommandTypeEnum.Internal;
            var command = new Command(floor, type);
            var elevator = new Elevator();
        
            elevator.AddCommand(command);

            elevator.CommandQueueContains(new Command(floor, type)).Should().BeTrue();
        }

        [Fact]
        public void ShouldStartStoppedAtGroundFloor()
        {
            var elevator = new Elevator();

            elevator.CurrentFloor.Should().Be(FloorEnum.Ground);
            elevator.Status.Should().Be(ElevatorStatusEnum.Stopped);
        }

        [Fact]
        public async Task ShouldMoveUpToFloorFromStoppedState()
        {
            var floor = FloorEnum.Two;
            var type = CommandTypeEnum.Internal;
            var command = new Command(floor, type);
            var elevator = new Elevator();
        
            elevator.AddCommand(command);
            var timeToMove = Elevator.MILLISECONDS_TO_MOVE_BEETWEEN_FLOORS * (int) floor;
            await Task.Delay(timeToMove + MILLISECONDS_FOR_SAFETY_TEST);

            elevator.CurrentFloor.Should().Be(floor);
        }
    }
}
