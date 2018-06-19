﻿using System.Collections.Generic;

namespace MarsRovers.Domain
{
    public class Rover
    {
        private readonly IDictionary<char, IRoverCommand> roverCommands
            = new Dictionary<char, IRoverCommand>
            {
                {'L', new LeftCommand()},
                {'R', new RightCommand()},
                {'M', new MoveCommand()}
            };

        public Rover() : this(0, 0, Direction.North)
        {
        }

        private Rover(int x, int y, Direction direction)
        {
            CurrentPosition = new PositionInfo(x, y, direction);
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
