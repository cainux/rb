using FluentAssertions;
using RB.Core;
using Xunit;

namespace RB.Tests
{
    public class RobotTests
    {
        [Theory]
        [InlineData(5, 5, 3, 3, 'N', "F", 3, 4, 'N', false)] // Move North
        [InlineData(5, 5, 3, 3, 'E', "F", 4, 3, 'N', false)] // Move East
        [InlineData(5, 5, 3, 3, 'S', "F", 3, 2, 'N', false)] // Move South
        [InlineData(5, 5, 3, 3, 'W', "F", 2, 3, 'N', false)] // Move West
        public void Moves(
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
