using System;
using System.Linq;

namespace MarsRovers.Domain
{
    public class MoveCommand : RoverCommandBase
    {
        private readonly int maxGridSize;

        public MoveCommand() 
            : this(10, Enumerable.Empty<Position>().ToArray())
        {
        }

        public MoveCommand(int maxGridSize, params Position[] obstructions) 
            : base(obstructions)
        {
            this.maxGridSize = maxGridSize - 1;
        }

        public override PositionInfo Execute(PositionInfo current)
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
            return new PositionInfo(
                current.Position.X, 
                y, 
                current.Facing, 
                HasObstructionAt(current.Position.X, y));
        }

        private PositionInfo MoveNorth(PositionInfo current)
        {
            var y = current.Position.Y + 1;
            if (y > maxGridSize)
            {
                y = 0;
            }
            return new PositionInfo(
                current.Position.X, 
                y, 
                current.Facing, 
                HasObstructionAt(current.Position.X, y));
        }

        private PositionInfo MoveWest(PositionInfo current)
        {
            var x = current.Position.X - 1;
            if (x < 0)
            {
                x = maxGridSize;
            }
            return new PositionInfo(
                x, 
                current.Position.Y, 
                current.Facing,
                HasObstructionAt(x, current.Position.Y));
        }

        private PositionInfo MoveEast(PositionInfo current)
        {
            var x = current.Position.X + 1;
            if (x > maxGridSize)
            {
                x = 0;
            }
            return new PositionInfo(
                x, 
                current.Position.Y, 
                current.Facing,
                HasObstructionAt(x, current.Position.Y));
        }
    }
}
