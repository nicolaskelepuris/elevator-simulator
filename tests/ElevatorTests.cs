using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace tests
{
    public class ElevatorTests
    {
        private const int MILLISECONDS_TO_AWAIT_FOR_EACH_FLOOR = 2000;

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
            var elevator = new Elevator();
            var floor = FloorEnum.Two;
            await MoveToFloorAsync(elevator, floor);

            elevator.CurrentFloor.Should().Be(FloorEnum.Two);
        }

        [Fact]
        public async Task ShouldMoveDownAfterWaitMoveUp()
        {
            var elevator = new Elevator();
            await MoveToFloorAsync(elevator, FloorEnum.Two);

            var floor = FloorEnum.One;
            await MoveToFloorAsync(elevator, floor);

            elevator.CurrentFloor.Should().Be(floor);
        }

        private async Task MoveToFloorAsync(Elevator elevator, FloorEnum floor){
            var type = CommandTypeEnum.Internal;
            var command = new Command(floor, type);

            elevator.AddCommand(command);
            var timeToWait = MILLISECONDS_TO_AWAIT_FOR_EACH_FLOOR * (int) floor;
            await Task.Delay(timeToWait);
        }

        [Fact]
        public async Task ShouldMoveUpAndDown()
        {
            var internalCommandType = CommandTypeEnum.Internal;
            var internalCommand = new Command(FloorEnum.Two, internalCommandType);
            var finalFloor = FloorEnum.One;
            var downCommand = new Command(finalFloor, CommandTypeEnum.Down);
            var elevator = new Elevator();

            elevator.AddCommand(internalCommand);
            elevator.AddCommand(downCommand);

            await Task.Delay(MILLISECONDS_TO_AWAIT_FOR_EACH_FLOOR * 3);

            elevator.CurrentFloor.Should().Be(finalFloor);
        }
    }
}
