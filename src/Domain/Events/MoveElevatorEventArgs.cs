using Domain.Enums;

namespace Domain.Events
{
    public class MoveElevatorEventArgs
    {
        public MoveTypeEnum MoveType { get; private set; }

        public MoveElevatorEventArgs(MoveTypeEnum moveType)
        {
            MoveType = moveType;
        }
    }
}