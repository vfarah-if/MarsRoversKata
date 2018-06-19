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

        public PositionInfo Execute(PositionInfo current)
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

        private PositionInfo MoveSouth(PositionInfo current)
        {
            var y = current.Position.Y - 1;
            if (y < 0)
            {
                y = maxGridSize;
            }
            return new PositionInfo(current.Position.X, y, current.Facing);
        }

        private PositionInfo MoveNorth(PositionInfo current)
        {
            var y = current.Position.Y + 1;
            if (y > maxGridSize)
            {
                y = 0;
            }
            return new PositionInfo(current.Position.X, y, current.Facing);
        }

        private PositionInfo MoveWest(PositionInfo current)
        {
            var x = current.Position.X - 1;
            if (x < 0)
            {
                x = maxGridSize;
            }
            return new PositionInfo(x, current.Position.Y, current.Facing);
        }

        private PositionInfo MoveEast(PositionInfo current)
        {
            var x = current.Position.X + 1;
            if (x > maxGridSize)
            {
                x = 0;
            }
            return new PositionInfo(x, current.Position.Y, current.Facing);
        }
    }
}
