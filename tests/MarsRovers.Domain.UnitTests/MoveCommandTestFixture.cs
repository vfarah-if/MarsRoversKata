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
        public void ShouldMoveForwardInARelativeDirection(
            int startX, 
            int startY, 
            Direction startDirection, 
            int endX, 
            int endY, 
            Direction endDirection)
        {
            var startingPosition = new PositionInfo(startX, startY, startDirection);
            var command = new MoveCommand();

            var endingPosition = command.Execute(startingPosition);

            endingPosition.Should().Be(new PositionInfo(endX, endY, endDirection));
        }


        [TestCase(0, 0, Direction.West, 9, 0, Direction.West)]
        [TestCase(0, 9, Direction.North, 0, 0, Direction.North)]
        [TestCase(0, 0, Direction.South, 0, 9, Direction.South)]
        [TestCase(9, 0, Direction.East, 0, 0, Direction.East)]
        public void ShouldWrapTheTenByTenGridWhenMovingoffTheEdge(
            int startX, 
            int startY, 
            Direction startDirection, 
            int endX, 
            int endY, 
            Direction endDirection)
        {
            var startingPosition = new PositionInfo(startX, startY, startDirection);
            var command = new MoveCommand(10);

            var endingPosition = command.Execute(startingPosition);

            endingPosition.Should().Be(new PositionInfo(endX, endY, endDirection));
        }

        [TestCase(0, 0, Direction.West, 9, 0, Direction.West, true)]
        [TestCase(0, 9, Direction.North, 0, 0, Direction.North, false)]
        public void ShouldShowValidObstructionInformation(
            int startX,
            int startY,
            Direction startDirection,
            int endX,
            int endY,
            Direction endDirection,
            bool hasObstruction)
        {
            var startingPosition = new PositionInfo(startX, startY, startDirection);
            var obstruction = new Position(9, 0);
            var command = new MoveCommand(10, obstruction);
            var expectedEndPositionInfo = new PositionInfo(endX, endY, endDirection, hasObstruction);

            var endingPosition = command.Execute(startingPosition);

            endingPosition.Should().Be(expectedEndPositionInfo);
        }
    }
}
