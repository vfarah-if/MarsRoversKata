using FluentAssertions;
using NUnit.Framework;

namespace MarsRovers.Domain.UnitTests
{
    [TestFixture]
    public class LeftCommandTestFixture
    {
        [Test]
        public void ShouldRotateFacingLeft()
        {
            var startingPosition = new PositionInfo(0, 0, Direction.North);
            var command = new LeftCommand();

            var endingPosition = command.Execute(startingPosition);

            endingPosition.Should().Be(new PositionInfo(0, 0, Direction.West));
        }

        [Test]
        public void ShouldHaveObstruction_WhenAnObstructionIsSetAtTheSamePosition()
        {
            var startingPosition = new PositionInfo(0, 0, Direction.North);
            var obstruction = startingPosition.Position;
            var command = new LeftCommand(obstruction);

            var endingPosition = command.Execute(startingPosition);

            endingPosition.HasObstruction.Should().BeTrue();
        }
    }
}