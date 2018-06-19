namespace MarsRovers.Domain
{
    public interface IRoverCommand
    {
        PositionInfo Execute(PositionInfo current);
    }
}
