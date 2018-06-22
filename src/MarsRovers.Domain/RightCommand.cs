namespace MarsRovers.Domain
{
    public class RightCommand : RoverCommandBase
    {
        public RightCommand() 
        {
        }

        public RightCommand(params Position[] obstructions) 
            : base(obstructions)
        {
        }

        public override PositionInfo Execute(PositionInfo current)
        {
            var x = current.Position.X;
            var y = current.Position.Y;
            return new PositionInfo(x, y, current.Facing.RotateRight(), this.HasObstructionAt(x, y));
        }
    }
}
