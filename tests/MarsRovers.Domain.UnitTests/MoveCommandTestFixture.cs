using FluentAssertions;
using NUnit.Framework;

namespace MarsRovers.Domain.UnitTests
{
    [TestFixture]
    public class MoveCommandTestFixture
    {
        [TestCase(0, 0, Direction.North, 0, 1, Direction.North)]
        [TestCase(0, 1, Direction.South, 0, 0, Direction.South)]
        [TestCase(0, 0, Direction.East, 1, 0, Direction.East)]
        [TestCase(1, 0, Direction.West, 0, 0, Direction.West)]
        public void ShouldMoveForwardInARelativeDirection(int startX, int startY, Direction startDirection, int endX, int endY, Direction endDirection)
        {
            var startingPosition = new Position(startX, startY, startDirection);
            var command = new MoveCommand();

            var endingPosition = command.Execute(startingPosition);

            endingPosition.Should().Be(new Position(endX, endY, endDirection));
        }
    }
}
