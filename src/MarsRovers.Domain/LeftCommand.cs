namespace MarsRovers.Domain
{
    public class LeftCommand : IRoverCommand
    {
        public Position Execute(Position current)
        {
            return new Position(current.X, current.Y, current.Facing.RotateLeft());
        }
    }
}