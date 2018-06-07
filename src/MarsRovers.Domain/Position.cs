namespace MarsRovers.Domain
{
    public struct Position
    {
        public Position(int x, int y, Direction facing) : this()
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public int X {get; private set;}
        public int Y {get; private set;}
        public Direction Facing {get; private set;}

        public override bool Equals(object obj)
        {
            if (!(obj is Position))
                return false;

            var other = (Position)obj; 

            return other.X == X 
                && other.Y == Y
                && other.Facing == Facing;            
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 17 
                + Y.GetHashCode() * 17 
                + Facing.GetHashCode();
        }

    }
}