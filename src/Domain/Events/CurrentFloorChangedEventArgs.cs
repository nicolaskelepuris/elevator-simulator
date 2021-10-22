using Domain.Enums;

namespace Domain.Events
{
    public class CurrentFloorChangedEventArgs
    {
        public CurrentFloorChangedEventArgs(FloorEnum floor)
        {
            Floor = floor;
        }

        public FloorEnum Floor { get; set; }
    }
}