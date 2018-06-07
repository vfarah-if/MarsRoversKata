using System;

namespace MarsRovers.Domain
{
    public class MoveCommand : IRoverCommand
    {
        private readonly int maxGridSize;

        public MoveCommand() : this(10)
        {
        }

        public MoveCommand(int maxGridSize)
        {
            this.maxGridSize = maxGridSize - 1;
        }

        public Position Execute(Position current)
        {
            switch (current.Facing)
            {
                case Direction.East:
                    {
                        return MoveEast(current);
                    }

                case Direction.West:
                    {
                        return MoveWest(current);
                    }
                case Direction.North:
                    {
                        return MoveNorth(current);
                    }
                case Direction.South:
                    {
                        return MoveSouth(current);
                    }
                default: throw new NotSupportedException();
            }
        }

        private Position MoveSouth(Position current)
        {
            var y = current.Y - 1;
            if (y < 0)
            {
                y = maxGridSize;
            }
            return new Position(current.X, y, current.Facing);
        }

        private Position MoveNorth(Position current)
        {
            var y = current.Y + 1;
            if (y > maxGridSize)
            {
                y = 0;
            }
            return new Position(current.X, y, current.Facing);
        }

        private Position MoveWest(Position current)
        {
            var x = current.X - 1;
            if (x < 0)
            {
                x = maxGridSize;
            }
            return new Position(x, current.Y, current.Facing);
        }

        private Position MoveEast(Position current)
        {
            var x = current.X + 1;
            if (x > maxGridSize)
            {
                x = 0;
            }
            return new Position(x, current.Y, current.Facing);
        }
    }
}
