using System.Threading.Tasks;
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
            var logger = new ElevatorLogger();
            var elevator = new AutomaticElevator(new ElevatorLogger(), _simulator);
        
            elevator.AddCommand(command);

            logger.VisitedFloors.Should().BeEmpty();
            elevator.CommandQueueContains(new Command(floor, type)).Should().BeTrue();
        }

        [Fact]
        public void ShouldNotAddExternalCommand()
        {
            var floor = FloorEnum.Two;
            var type = CommandTypeEnum.Down;
            var command = new Command(floor, type);
            var logger = new ElevatorLogger();
            var elevator = new AutomaticElevator(logger, _simulator);
        
            elevator.AddCommand(command);

            logger.VisitedFloors.Should().BeEmpty();
            elevator.CommandQueueContains(new Command(floor, type)).Should().BeFalse();
        }

        [Fact]
        public async Task ShouldAddRandomCommandAfterSimulationTimeAsync()
        {
            var logger = new ElevatorLogger();
            var elevator = new AutomaticElevator(logger, _simulator);

            logger.VisitedFloors.Should().BeEmpty();
            
            var delayTime = _simulator.MillisecondsIntervalToGenerateRandomCommand + _simulator.MillisecondsToMoveBeetweenFloors;
            await Task.Delay(delayTime);

            logger.VisitedFloors.Should().NotBeEmpty();
        }
    }
}