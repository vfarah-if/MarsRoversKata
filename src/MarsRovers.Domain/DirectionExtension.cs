using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Domain
{
    public static class DirectionExtension
    {
        public static Direction RotateLeft(this Direction source)
        {
            switch (source)
            {
                case Direction.North:
                    return Direction.West;
                case Direction.West:
                    return Direction.South;
                case Direction.South:
                    return Direction.East;
                case Direction.East:
                    return Direction.North;
                default: throw new NotSupportedException();
            }
        }

        public static Direction RotateRight(this Direction source)
        {
            switch (source)
            {
                case Direction.North:
                    return Direction.East;
                case Direction.East:
                    return Direction.South;
                case Direction.South:
                    return Direction.West;
                case Direction.West:
                    return Direction.North;
                default: throw new NotSupportedException();
            }
        }
    }
}
