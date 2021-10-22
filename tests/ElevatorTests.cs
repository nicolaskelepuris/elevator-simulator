using System.Collections.Generic;
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
            var visitedFloors = elevator.VisitedFloors;
            visitedFloors.Should().HaveCount(1);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2 });
        }

        [Fact]
        public async Task ShouldMoveDownAfterMovedUp()
        {
            var elevator = new Elevator();
            await MoveToFloorAsync(elevator, FloorEnum.Two);

            var floor = FloorEnum.One;
            await MoveToFloorAsync(elevator, floor);

            elevator.CurrentFloor.Should().Be(floor);
            var visitedFloors = elevator.VisitedFloors;
            visitedFloors.Should().HaveCount(2);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2, 1 });
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
            var visitedFloors = elevator.VisitedFloors;
            visitedFloors.Should().HaveCount(2);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2, 1 });
        }

        [Fact]
        public async Task ShouldMoveUpWaitAndDownAndUp()
        {
            var elevator = new Elevator();
            var floor = FloorEnum.Two;
            await MoveToFloorAsync(elevator, floor);
            var downCommand = new Command(FloorEnum.One, CommandTypeEnum.Down);
            var finalFloor = FloorEnum.Four;
            var upCommand = new Command(finalFloor, CommandTypeEnum.Up);

            elevator.AddCommand(downCommand);
            elevator.AddCommand(upCommand);

            await Task.Delay(MILLISECONDS_TO_AWAIT_FOR_EACH_FLOOR * 5);

            elevator.CurrentFloor.Should().Be(finalFloor);
            var visitedFloors = elevator.VisitedFloors;
            visitedFloors.Should().HaveCount(3);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2, 1, 4 });
        }

        [Fact]
        public async Task ShouldMoveUpStoppingAtFloorsInAscendingFloorOrder()
        {
            var commandType = CommandTypeEnum.Up;
            var firstCommand = new Command(FloorEnum.Four, commandType);
            var secondCommand = new Command(FloorEnum.Three, commandType);
            var thirdCommand = new Command(FloorEnum.One, commandType);
            var fourthCommand = new Command(FloorEnum.Two, commandType);
            var elevator = new Elevator();

            elevator.AddCommand(firstCommand);
            elevator.AddCommand(secondCommand);
            elevator.AddCommand(thirdCommand);
            elevator.AddCommand(fourthCommand);

            await Task.Delay(MILLISECONDS_TO_AWAIT_FOR_EACH_FLOOR * 5);

            var visitedFloors = elevator.VisitedFloors;
            visitedFloors.Should().HaveCount(4);
            visitedFloors.Should().ContainInOrder(new List<int>() { 1, 2, 3, 4 });
        }

        [Fact]
        public async Task ShouldMoveUpWhenReceiveExternalDownCommandFromUpperFloor()
        {
            var commandType = CommandTypeEnum.Down;
            var floor = FloorEnum.Four;
            var command = new Command(FloorEnum.Four, commandType);
            var elevator = new Elevator();

            elevator.AddCommand(command);

            await Task.Delay(MILLISECONDS_TO_AWAIT_FOR_EACH_FLOOR * 4);

            var visitedFloors = elevator.VisitedFloors;
            visitedFloors.Should().HaveCount(1);
            visitedFloors.Should().ContainInOrder(new List<int>() { 4 });
            elevator.CurrentFloor.Should().Be(floor);
        }
    }
}
