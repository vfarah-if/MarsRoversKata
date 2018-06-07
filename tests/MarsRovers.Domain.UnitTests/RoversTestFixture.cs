using FluentAssertions;
using NUnit.Framework;

namespace MarsRovers.Domain.UnitTests
{
    [TestFixture]
    public class WhenUsingTheRoverToPlayMarsRovers
    {
        [Test]
        public void ShouldStartTheRoverAtPositionZeroFacingNorth()
        {
            var expectedStartingPosition = new Position(0, 0, Direction.North);

            var rover = new Rover();

            rover.CurrentPosition.Should().Be(expectedStartingPosition);
        }

        [TestCase("L", 0, 0, Direction.West)]
        [TestCase("R", 0, 0, Direction.East)]
        [TestCase("M", 0, 1, Direction.North)]
        [TestCase("RM" , 1, 0, Direction.East)]
        [TestCase("RMLLM", 0, 0, Direction.West)]
        [TestCase("MLLM", 0, 0, Direction.South)]
        [TestCase("LM", 9, 0, Direction.West)]
        [TestCase("MMMMMMMMMM", 0, 0, Direction.North)]
        [TestCase("LLM", 0, 9, Direction.South)]
        [TestCase("RRM", 0, 9, Direction.South)]
        [TestCase("RMMMMMMMMMM", 0, 0, Direction.East)]
        public void ShouldMoveByCommandToAnExpectedEndPosition(string command, int endX, int endY, Direction endDirection)
        {
            var rover = new Rover();

            rover.Execute(command);

            rover.CurrentPosition.Should().Be(new Position(endX, endY, endDirection));
        }
    }
}
