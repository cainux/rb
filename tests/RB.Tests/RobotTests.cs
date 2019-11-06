using FluentAssertions;
using RB.Core;
using Xunit;

namespace RB.Tests
{
    public class RobotTests
    {
        [Theory]
        // Moving Forward
        [InlineData(5, 5, 3, 3, 'N', "F", 3, 4, 'N', false)]
        [InlineData(5, 5, 3, 3, 'E', "F", 4, 3, 'E', false)]
        [InlineData(5, 5, 3, 3, 'S', "F", 3, 2, 'S', false)]
        [InlineData(5, 5, 3, 3, 'W', "F", 2, 3, 'W', false)]

        // Rotating Right
        [InlineData(0, 0, 0, 0, 'N', "R", 0, 0, 'E', false)]
        [InlineData(0, 0, 0, 0, 'E', "R", 0, 0, 'S', false)]
        [InlineData(0, 0, 0, 0, 'S', "R", 0, 0, 'W', false)]
        [InlineData(0, 0, 0, 0, 'W', "R", 0, 0, 'N', false)]

        // Rotating Left
        [InlineData(0, 0, 0, 0, 'N', "L", 0, 0, 'W', false)]
        [InlineData(0, 0, 0, 0, 'E', "L", 0, 0, 'N', false)]
        [InlineData(0, 0, 0, 0, 'S', "L", 0, 0, 'E', false)]
        [InlineData(0, 0, 0, 0, 'W', "L", 0, 0, 'S', false)]

        // Combination of movements
        [InlineData(5, 5, 0, 0, 'N', "FRFLFRRFLFF", 3, 1, 'E', false)]
        public void Movement(
            int planetWidth, int planetHeight,
            int startX, int startY, char startOrientation, string instructions,
            int expectedX, int expectedY, char expectedOrientation, bool expectedLost)
        {
            // Arrange
            var mars = new Planet(planetWidth, planetHeight);
            var robot = new Robot(startX, startY, startOrientation, instructions, mars);

            // Act
            robot.Run();
            var actual = robot.Status;

            // Assert
            actual.Should().Be($"{expectedX} {expectedY} {expectedOrientation}" + (expectedLost ? " LOST" : string.Empty));
        }
    }
}
