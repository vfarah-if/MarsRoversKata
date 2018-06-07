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
            var startingPosition = new Position(0, 0, Direction.North);
            var command = new LeftCommand();

            var endingPosition = command.Execute(startingPosition);

            endingPosition.Should().Be(new Position(0, 0, Direction.West));
        }        
    }
}