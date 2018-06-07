using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace MarsRovers.Domain.UnitTests
{
    [TestFixture]
    public class WhenUsingTheRoverToPlayMarsRovers
    {
        // Should set the maximum size of a grid
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
        public void ShouldMoveEastWhenCommandLIsExecuted(string command, int x, int y, Direction direction)
        {
            var rover = new Rover();

            rover.Execute(command);

            rover.CurrentPosition.Should().Be(new Position(x, y, direction));
        }
    }
}
