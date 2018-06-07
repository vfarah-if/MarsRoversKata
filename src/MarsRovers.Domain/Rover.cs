using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Domain
{
    public class Rover
    {
        public Rover(): this(0,0,Direction.North)
        {
            
        }

        private Rover(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Facing = direction;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Facing { get; private set; }

        public void Execute(params char[] commands)
        {
            foreach (var command in commands)
            {
                if (command == 'L')
                {
                    MoveLeft();
                }

                if (command == 'R')
                {
                    MoveRight();
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
            switch (Facing)
            {
                case Direction.North:
                    Y = Y + 1;
                    break;
                case Direction.East:
                    X = X + 1;
                    break;
                case Direction.West:
                    X = X - 1;
                    break;
                case Direction.South:
                    Y = Y - 1;
                    break;
                default: throw new NotSupportedException();
            }
        }


        private void MoveRight()
        {
            Facing = Facing.RotateRight();
        }

        private void MoveLeft()
        {
            Facing = Facing.RotateLeft();
        }
    }
}
