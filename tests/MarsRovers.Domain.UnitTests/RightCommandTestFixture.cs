using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace MarsRovers.Domain.UnitTests
{
    [TestFixture]
    public class RightCommandTestFixture
    {
        [Test]
        public void ShouldRotateFacingRight()
        {
            var startingPosition = new PositionInfo(0, 0, Direction.North);
            var command = new RightCommand();

            var endingPosition = command.Execute(startingPosition);

            endingPosition.Should().Be(new PositionInfo(0, 0, Direction.East));
        }

        [Test]
        public void ShouldHaveObstruction_WhenAnObstructionIsSetAtTheSamePosition()
        {
            var startingPosition = new PositionInfo(0, 0, Direction.North);
            var obstruction = startingPosition.Position;
            var command = new RightCommand(obstruction);

            var endingPosition = command.Execute(startingPosition);

            endingPosition.HasObstruction.Should().BeTrue();
        }
    }
}
