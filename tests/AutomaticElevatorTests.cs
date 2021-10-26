using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Services;
using FluentAssertions;
using tests.Mocks;
using Xunit;

namespace tests
{
    public class AutomaticElevatorTests
    {

        private readonly IElevatorSimulator _simulator;
        public AutomaticElevatorTests()
        {
            _simulator = MockElevatorSimulator.CreateMockedInstance();
        }

        [Fact]
        public void ShouldAddInternalCommand()
        {
            var floor = FloorEnum.Two;
            var type = CommandTypeEnum.Internal;
            var command = new Command(floor, type);
            var elevator = new Elevator(new ElevatorLogger(), _simulator);
        
            elevator.AddCommand(command);

            elevator.CommandQueueContains(new Command(floor, type)).Should().BeTrue();
        }

        [Fact]
        public void ShouldNotAddExternalCommand()
        {
            var floor = FloorEnum.Two;
            var type = CommandTypeEnum.Up;
            var command = new Command(floor, type);
            var elevator = new Elevator(new ElevatorLogger(), _simulator);
        
            elevator.AddCommand(command);

            elevator.CommandQueueContains(new Command(floor, type)).Should().BeFalse();
        }
    }
}