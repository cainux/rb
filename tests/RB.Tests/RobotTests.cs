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

        // Move off the world (test all 4 directions)
        [InlineData(0, 0, 0, 0, 'N', "F", 0, 0, 'N', true)]
        [InlineData(0, 0, 0, 0, 'E', "F", 0, 0, 'E', true)]
        [InlineData(0, 0, 0, 0, 'S', "F", 0, 0, 'S', true)]
        [InlineData(0, 0, 0, 0, 'W', "F", 0, 0, 'W', true)]

        // Move off this thin world
        [InlineData(0, 5, 0, 0, 'N', "FFFFFFFFFFFFFF", 0, 5, 'N', true)]
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

            // Assert
            robot.Status.Should().Be($"{expectedX} {expectedY} {expectedOrientation}" + (expectedLost ? " LOST" : string.Empty));

            if (expectedLost)
            {
                mars.CheckScent(expectedX, expectedY).Should().BeTrue();
            }
        }

        [Fact]
        public void ScentIsObeyed()
        {
            // Arrange
            var mars = new Planet(5, 3);
            var robot1 = new Robot(0, 0, 'N', "FFFFFFFFFF", mars);
            var robot2 = new Robot(0, 0, 'N', "FFFFFFFFFF", mars);

            // Act
            robot1.Run();
            robot2.Run();

            // Assert
            robot1.Status.Should().Be("0 3 N LOST");
            robot2.Status.Should().Be("0 3 N");
        }
    }
}
