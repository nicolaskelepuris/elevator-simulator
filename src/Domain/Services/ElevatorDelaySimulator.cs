using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services
{
    public class ElevatorDelaySimulator : IElevatorDelaySimulator
    {
        private const int MILLISECONDS_TO_MOVE_BEETWEEN_FLOORS = 3000;
        private const int MILLISECONDS_TO_VISIT_FLOOR = 5000;

        public async Task SimulateFloorVisit()
        {
            await Task.Delay(MILLISECONDS_TO_MOVE_BEETWEEN_FLOORS);
        }

        public async Task SimulateMoveToNextFloor()
        {
            await Task.Delay(MILLISECONDS_TO_VISIT_FLOOR);
        }
    }
}