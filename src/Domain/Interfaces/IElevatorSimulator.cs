using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IElevatorSimulator
    {
        Task SimulateMoveToNextFloor();
        Task SimulateFloorVisit();
        int MillisecondsIntervalToGenerateRandomCommand { get; }
        int MillisecondsToMoveBeetweenFloors { get; }
    }
}