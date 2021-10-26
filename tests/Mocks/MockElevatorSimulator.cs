using System.Threading.Tasks;
using Domain.Interfaces;
using Moq;

namespace tests.Mocks
{
    public static class MockElevatorSimulator
    {
        private const int delay = 100;
        public static IElevatorSimulator CreateMockedInstance()
        {
            var mock = new Mock<IElevatorSimulator>();
            mock.Setup(p => p.SimulateMoveToNextFloor()).Returns(Task.Delay(delay));
            mock.Setup(p => p.SimulateFloorVisit()).Returns(Task.Delay(delay));
            mock.SetupGet(p => p.MillisecondsIntervalToGenerateRandomCommand).Returns(delay);
            mock.SetupGet(p => p.MillisecondsToMoveBeetweenFloors).Returns(delay);
            return mock.Object;
        }
    }
}