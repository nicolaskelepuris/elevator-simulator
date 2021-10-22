using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IElevatorDelaySimulator
    {
        Task SimulateMoveToNextFloor();
        Task SimulateFloorVisit();
    }
}