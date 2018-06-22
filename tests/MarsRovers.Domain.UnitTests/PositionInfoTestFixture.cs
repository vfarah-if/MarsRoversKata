using FluentAssertions;
using NUnit.Framework;

namespace MarsRovers.Domain.UnitTests
{
    [TestFixture]
    public class PositionInfoTestFixture
    {
        [Test]
        public void WhenConfiguredWithObstruction_ShouldOutputStringInExpectedFormat()
        {
            var withExpectedFormat = "O,2,2,N";

            var positionInfo = new PositionInfo(2,2, Direction.North, true);

            positionInfo.ToString().Should().Be(withExpectedFormat);
        }


        [Test]
        public void WhenConfiguredWithoutObstruction_ShouldOutputStringInExpectedFormat()
        {
            var withExpectedFormat = "0,1,S";

            var positionInfo = new PositionInfo(0, 1, Direction.South);

            positionInfo.ToString().Should().Be(withExpectedFormat);
        }
    }
}
