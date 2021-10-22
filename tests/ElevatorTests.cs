using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace tests
{
    public class ElevatorTests
    {
        private const int MILLISECONDS_TO_WAIT_FOR_EACH_FLOOR = 100;

        private readonly IElevatorDelaySimulator _delaySimulator;
        public ElevatorTests()
        {
            var mock = new Mock<IElevatorDelaySimulator>();
            mock.Setup(p => p.SimulateMoveToNextFloor()).Returns(Task.Delay(50));
            mock.Setup(p => p.SimulateFloorVisit()).Returns(Task.Delay(50));
            _delaySimulator = mock.Object;
        }

        [Fact]
        public void ShouldAddCommand()
        {
            var floor = FloorEnum.Two;
            var type = CommandTypeEnum.Internal;
            var command = new Command(floor, type);
            var elevator = new Elevator(new ElevatorLogger(), _delaySimulator);
        
            elevator.AddCommand(command);

            elevator.CommandQueueContains(new Command(floor, type)).Should().BeTrue();
        }

        [Fact]
        public void ShouldStartStoppedAtGroundFloor()
        {
            var elevator = new Elevator(new ElevatorLogger(), _delaySimulator);

            elevator.CurrentFloor.Should().Be(FloorEnum.Ground);
            elevator.Status.Should().Be(ElevatorStatusEnum.Stopped);
        }

        [Fact]
        public async Task ShouldMoveUpToFloorFromStoppedState()
        {
            var logger = new ElevatorLogger();
            var elevator = new Elevator(logger, _delaySimulator);
            var floor = FloorEnum.Two;
            await MoveToFloorAsync(elevator, floor);

            elevator.CurrentFloor.Should().Be(FloorEnum.Two);
            var visitedFloors = logger.VisitedFloors;
            visitedFloors.Should().HaveCount(1);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2 });
        }

        [Fact]
        public async Task ShouldMoveDownAfterMovedUp()
        {
            var logger = new ElevatorLogger();
            var elevator = new Elevator(logger, _delaySimulator);
            await MoveToFloorAsync(elevator, FloorEnum.Two);

            var floor = FloorEnum.One;
            await MoveToFloorAsync(elevator, floor);

            elevator.CurrentFloor.Should().Be(floor);
            var visitedFloors = logger.VisitedFloors;
            visitedFloors.Should().HaveCount(2);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2, 1 });
        }

        private async Task MoveToFloorAsync(Elevator elevator, FloorEnum floor){
            var type = CommandTypeEnum.Internal;
            var command = new Command(floor, type);

            elevator.AddCommand(command);
            var timeToWait = MILLISECONDS_TO_WAIT_FOR_EACH_FLOOR * (int) floor;
            await Task.Delay(timeToWait);
        }

        [Fact]
        public async Task ShouldMoveUpAndDown()
        {
            var internalCommandType = CommandTypeEnum.Internal;
            var internalCommand = new Command(FloorEnum.Two, internalCommandType);
            var finalFloor = FloorEnum.One;
            var downCommand = new Command(finalFloor, CommandTypeEnum.Down);
            var logger = new ElevatorLogger();
            var elevator = new Elevator(logger, _delaySimulator);

            elevator.AddCommand(internalCommand);
            elevator.AddCommand(downCommand);

            await Task.Delay(MILLISECONDS_TO_WAIT_FOR_EACH_FLOOR * 3);

            elevator.CurrentFloor.Should().Be(finalFloor);
            var visitedFloors = logger.VisitedFloors;
            visitedFloors.Should().HaveCount(2);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2, 1 });
        }

        [Fact]
        public async Task ShouldMoveUpWaitAndDownAndUp()
        {
            var logger = new ElevatorLogger();
            var elevator = new Elevator(logger, _delaySimulator);
            var floor = FloorEnum.Two;
            await MoveToFloorAsync(elevator, floor);
            var downCommand = new Command(FloorEnum.One, CommandTypeEnum.Down);
            var finalFloor = FloorEnum.Four;
            var upCommand = new Command(finalFloor, CommandTypeEnum.Up);

            elevator.AddCommand(downCommand);
            elevator.AddCommand(upCommand);

            await Task.Delay(MILLISECONDS_TO_WAIT_FOR_EACH_FLOOR * 5);

            elevator.CurrentFloor.Should().Be(finalFloor);
            var visitedFloors = logger.VisitedFloors;
            visitedFloors.Should().HaveCount(3);
            visitedFloors.Should().ContainInOrder(new List<int>() { 2, 1, 4 });
        }

        [Fact]
        public async Task ShouldMoveUpStoppingAtFloorsInAscendingFloorOrder()
        {
            var logger = new ElevatorLogger();
            var elevator = new Elevator(logger, _delaySimulator);
            var commandType = CommandTypeEnum.Up;
            var firstCommand = new Command(FloorEnum.Four, commandType);
            var secondCommand = new Command(FloorEnum.Three, commandType);
            var thirdCommand = new Command(FloorEnum.One, commandType);
            var fourthCommand = new Command(FloorEnum.Two, commandType);

            elevator.AddCommand(firstCommand);
            elevator.AddCommand(secondCommand);
            elevator.AddCommand(thirdCommand);
            elevator.AddCommand(fourthCommand);

            await Task.Delay(MILLISECONDS_TO_WAIT_FOR_EACH_FLOOR * 5);

            var visitedFloors = logger.VisitedFloors;
            visitedFloors.Should().HaveCount(4);
            visitedFloors.Should().ContainInOrder(new List<int>() { 1, 2, 3, 4 });
        }

        [Fact]
        public async Task ShouldMoveUpWhenReceiveExternalDownCommandFromUpperFloor()
        {
            var logger = new ElevatorLogger();
            var elevator = new Elevator(logger, _delaySimulator);
            var commandType = CommandTypeEnum.Down;
            var floor = FloorEnum.Four;
            var command = new Command(FloorEnum.Four, commandType);            

            elevator.AddCommand(command);

            await Task.Delay(MILLISECONDS_TO_WAIT_FOR_EACH_FLOOR * 4);

            var visitedFloors = logger.VisitedFloors;
            visitedFloors.Should().HaveCount(1);
            visitedFloors.Should().ContainInOrder(new List<int>() { 4 });
            elevator.CurrentFloor.Should().Be(floor);
        }
    }
}
