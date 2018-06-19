namespace MarsRovers.Domain
{
    public struct PositionInfo
    {
        public PositionInfo(int x, int y, Direction facing) : this()
        {
            Position = new Position(x, y);
            Facing = facing;
        }

        public Position Position { get; }
        public Direction Facing {get; }

        public override bool Equals(object obj)
        {
            if (!(obj is PositionInfo))
                return false;

            var other = (PositionInfo)obj; 

            return other.Position.Equals(this.Position)
                && other.Facing == Facing;            
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode() 
                + Facing.GetHashCode();
        }

    }
}