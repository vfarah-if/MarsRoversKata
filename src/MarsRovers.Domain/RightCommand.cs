namespace MarsRovers.Domain
{
    public class RightCommand: IRoverCommand
    {
        public PositionInfo Execute(PositionInfo current)
        {
            return new PositionInfo(current.Position.X, current.Position.Y, current.Facing.RotateRight());
        }
    }
}
