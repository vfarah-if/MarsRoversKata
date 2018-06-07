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
    }
}