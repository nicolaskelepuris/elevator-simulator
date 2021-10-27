using System;
using System.Linq;

namespace Domain.Enums.Extensions
{
    public static class CommandTypeEnumExtensions
    {
        public static bool IsValidFor(this CommandTypeEnum commandType, FloorEnum floor)
        {
            if ((IsLowestFloor(floor) && IsDownCommandType(commandType)) || (IsHighestFloor(floor) && IsUpCommandType(commandType)))
            {
                return false;
            }

            return true;
        }

        private static bool IsLowestFloor(FloorEnum floor)
        {
            var floors = Enum.GetValues<FloorEnum>();

            return floors.First() == floor;
        }

        private static bool IsDownCommandType(CommandTypeEnum commandType)
        {
            return commandType == CommandTypeEnum.Down;
        }

        private static bool IsHighestFloor(FloorEnum floor)
        {
            var floors = Enum.GetValues<FloorEnum>();

            return floors.Last() == floor;
        }

        private static bool IsUpCommandType(CommandTypeEnum commandType)
        {
            return commandType == CommandTypeEnum.Up;
        }
    }
}