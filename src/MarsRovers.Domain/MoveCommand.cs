using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Domain
{
    public class MoveCommand: IRoverCommand
    {
        public Position Execute(Position current)
        {
            switch (current.Facing)
            {
                case Direction.North:
                    return new Position(current.X, current.Y + 1, current.Facing);
                case Direction.East:
                    return new Position(current.X + 1, current.Y, current.Facing);
                case Direction.West:
                    return new Position(current.X - 1, current.Y, current.Facing);
                case Direction.South:
                    return new Position(current.X, current.Y - 1, current.Facing);
                default: throw new NotSupportedException();
            }
        }
    }
}
