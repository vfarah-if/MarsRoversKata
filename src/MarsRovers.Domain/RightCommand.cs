namespace MarsRovers.Domain
{
    public class RightCommand: IRoverCommand
    {
        public Position Execute(Position current)
        {
            return new Position(current.X, current.Y, current.Facing.RotateRight());
        }
    }
}
