using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Command
    {
        public FloorEnum Floor { get; private set; }
        public CommandTypeEnum Type { get; private set; }

        public Command(FloorEnum floor, CommandTypeEnum type)
        {
            Floor = floor;
            Type = type;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            Command otherCommand = (Command)obj;
            return Floor == otherCommand.Floor && Type == otherCommand.Type;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Floor, Type).GetHashCode();
        }
    }
}