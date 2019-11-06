using FluentAssertions;
using RB.Core;
using Xunit;

namespace RB.Tests
{
    public class PlanetTests
    {
        [Theory]
        // Inside
        [InlineData(2, 2, 0, 0, true)]
        [InlineData(2, 2, 0, 2, true)]
        [InlineData(2, 2, 2, 2, true)]
        [InlineData(2, 2, 2, 0, true)]

        // Outside
        [InlineData(2, 2, -1, -1, false)]
        [InlineData(2, 2, -1, 0, false)]
        [InlineData(2, 2, 0, -1, false)]
        [InlineData(2, 2, 3, 0, false)]
        [InlineData(2, 2, 0, 3, false)]
        [InlineData(2, 2, 3, 3, false)]
        public void WithinWorld(int width, int height, int x, int y, bool expected)
        {
            // Arrange
            var mars = new Planet(width, height);

            // Act
            var actual = mars.WithinWorld(x, y);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(5, 5, 3, 3, 3, 3, true)]
        [InlineData(5, 5, 3, 3, 0, 0, false)]
        public void LeaveScent(int width, int height, int leaveX, int leaveY, int checkX, int checkY, bool expected)
        {
            // Arrange
            var mars = new Planet(width, height);

            // Act
            mars.LeaveScent(leaveX, leaveY);
            var actual = mars.CheckScent(checkX, checkY);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
