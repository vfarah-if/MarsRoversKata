using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Domain
{
    public class Rover
    {
        private readonly IDictionary<char, IRoverCommand> roverCommands
            = new Dictionary<char, IRoverCommand>
            {
                {'L', new LeftCommand()},
                {'R', new RightCommand()}
            };

        public Rover(): this(0,0,Direction.North)
        {    
        }

        private Rover(int x, int y, Direction direction)
        {
           CurrentPosition = new Position(x, y, direction);
        }

        public Position CurrentPosition {get; private set;}

        public void Execute(params char[] commands)
        {
            foreach (var command in commands)
            {
                if (roverCommands.ContainsKey(command))
                {
                    CurrentPosition = roverCommands[command].Execute(CurrentPosition);
                }           

                if (command == 'M')
                {
                    Move();
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


        private void Move()
        {
            switch (CurrentPosition.Facing)
            {
                case Direction.North:
                    CurrentPosition = new Position(CurrentPosition.X, CurrentPosition.Y + 1, CurrentPosition.Facing);
                    break;
                case Direction.East:
                    CurrentPosition = new Position(CurrentPosition.X + 1, CurrentPosition.Y, CurrentPosition.Facing);
                    break;
                case Direction.West:
                    CurrentPosition = new Position(CurrentPosition.X - 1, CurrentPosition.Y, CurrentPosition.Facing);
                    break;
                case Direction.South:
                    CurrentPosition = new Position(CurrentPosition.X, CurrentPosition.Y - 1, CurrentPosition.Facing);
                    break;                  
                default: throw new NotSupportedException();
            }
        }
    }
}
