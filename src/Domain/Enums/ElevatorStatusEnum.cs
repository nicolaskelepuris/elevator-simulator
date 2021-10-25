using System.ComponentModel;

namespace Domain.Enums
{
    public enum ElevatorStatusEnum
    {
        [Description("Parado")]
        Stopped,
        [Description("Subindo")]
        GoingUp,
        [Description("Descendo")]
        GoingDown,
        [Description("Visitando")]
        VisitingFloor
    }
}
