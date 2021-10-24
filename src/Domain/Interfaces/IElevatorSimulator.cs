using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IElevatorSimulator
    {
        Task SimulateMoveToNextFloor();
        Task SimulateFloorVisit();
    }
}