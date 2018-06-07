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
        // Should have something to represent the direction or compass points
        [Test]
        public void ShouldStartTheRoverAtPositionZeroFacingNorth()
        {
            var rover = new Rover();

            rover.X.Should().Be(0);
            rover.Y.Should().Be(0);
            rover.Facing.Should().Be(Direction.North);
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

            rover.X.Should().Be(x);
            rover.Y.Should().Be(y);
            rover.Facing.Should().Be(direction);
        }
    }
}
