using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Domain
{
    public abstract class RoverCommandBase: IRoverCommand
    {
        protected readonly IEnumerable<Position> obstructions;
        

        protected RoverCommandBase() : this(Enumerable.Empty<Position>().ToArray())
        {
        }

        protected RoverCommandBase(params Position[] obstructions)
        {
            this.obstructions = obstructions;            
        }

        public abstract PositionInfo Execute(PositionInfo current);

        protected bool HasObstructionAt(int x, int y)
        {
            return obstructions.Any(position => position.X == x && position.Y == y);
        }
   
    }
}