namespace MarsRovers.Domain
{
    public class LeftCommand : RoverCommandBase
    {
        public LeftCommand() : base()
        {
        }

        public LeftCommand(params Position[] obstructions) : base(obstructions)
        {

        }

        public override PositionInfo Execute(PositionInfo current)
        {
            var x = current.Position.X;
            var y = current.Position.Y;
            return new PositionInfo(x, y, current.Facing.RotateLeft(), this.HasObstructionAt(x, y));
        }
    }
}