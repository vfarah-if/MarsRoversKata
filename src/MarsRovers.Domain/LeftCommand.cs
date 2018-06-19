namespace MarsRovers.Domain
{
    public class LeftCommand : IRoverCommand
    {
        public PositionInfo Execute(PositionInfo current)
        {
            return new PositionInfo(current.Position.X, current.Position.Y, current.Facing.RotateLeft());
        }
    }
}