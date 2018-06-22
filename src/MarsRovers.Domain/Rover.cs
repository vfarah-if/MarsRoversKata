using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Domain
{
    public class Rover
    {
        private readonly IDictionary<char, IRoverCommand> roverCommands;
            

        public Rover() : this(0, 0, Direction.North, 10, Enumerable.Empty<Position>().ToArray())
        {
        }
        public Rover(params Position[] obstructions) : this(0, 0, Direction.North, 10, obstructions)
        {
        }

        private Rover(int x, int y, Direction direction, int maxGridSizeNotZeroBased, params Position[] obstructions)
        {
            CurrentPosition = new PositionInfo(
                x, 
                y, 
                direction, 
                obstructions.Any(obstruction => obstruction.X == x && obstruction.Y == y));
            roverCommands = new Dictionary<char, IRoverCommand>
            {
                {'L', new LeftCommand(obstructions)},
                {'R', new RightCommand(obstructions)},
                {'M', new MoveCommand(maxGridSizeNotZeroBased, obstructions)}
            };
        }

        public PositionInfo CurrentPosition { get; private set; }

        public void Execute(params char[] commands)
        {
            foreach (var command in commands)
            {
                if (roverCommands.ContainsKey(command))
                {
                    CurrentPosition = roverCommands[command].Execute(CurrentPosition);
                }
            }
        }

        public void Execute(string commands)
        {
            foreach (var command in commands)
            {
                Execute(command);
            }
        }
    }
}
