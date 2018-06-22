using System;
using System.Text;

namespace MarsRovers.Domain
{
    public struct PositionInfo
    {
        public PositionInfo(int x, int y, Direction facing, bool hasObstruction = false) : this()
        {
            Position = new Position(x, y);
            Facing = facing;
            HasObstruction = hasObstruction;
        }

        public Position Position { get; }
        public Direction Facing { get; }
        public bool HasObstruction { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is PositionInfo))
                return false;

            var other = (PositionInfo)obj;

            return other.Position.Equals(this.Position)
                && other.Facing == Facing
                && other.HasObstruction == HasObstruction;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode()
                + Facing.GetHashCode()
                + HasObstruction.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (HasObstruction)
            {
                result.Append("O,");
            }
            result.Append($"{this.Position.X},{this.Position.Y},{(char)Facing}");
            return result.ToString();
        }
    }
}