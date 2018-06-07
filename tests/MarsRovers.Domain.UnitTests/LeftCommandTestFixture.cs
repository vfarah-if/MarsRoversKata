using FluentAssertions;
using NUnit.Framework;

namespace MarsRovers.Domain
{
    [TestFixture]
    public class LeftCommandTestFixture
    {
        [Test]
        public void Should_Rotate_Facing_Left()
        {
            var startingPosition = new Position(0, 0, Direction.North);
            var command = new LeftCommand();

            var endingPosition = command.Execute(startingPosition);

            endingPosition.X.Should().Be(0);
            endingPosition.Y.Should().Be(0);
            endingPosition.Facing.Should().Be(Direction.West);
        }        
    }
}