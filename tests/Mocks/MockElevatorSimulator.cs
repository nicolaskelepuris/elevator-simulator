using System.Threading.Tasks;
using Domain.Interfaces;
using Moq;

namespace tests.Mocks
{
    public static class MockElevatorSimulator
    {
        public static IElevatorSimulator CreateMockedInstance()
        {
            var mock = new Mock<IElevatorSimulator>();
            mock.Setup(p => p.SimulateMoveToNextFloor()).Returns(Task.Delay(50));
            mock.Setup(p => p.SimulateFloorVisit()).Returns(Task.Delay(50));
            return mock.Object;
        }
    }
}