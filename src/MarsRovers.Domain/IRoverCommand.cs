namespace MarsRovers.Domain
{
    public interface IRoverCommand
    {
        Position Execute(Position current);
    }
}
