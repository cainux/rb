using FluentAssertions;
using RB.Core;
using Xunit;

namespace RB.Tests
{
    public class SimulationTests
    {
        [Fact]
        public void RBExample()
        {
            // Arrange
            var input = new[]
            {
                "5 3",
                "1 1 E",
                "RFRFRFRF",
                "3 2 N",
                "FRRFLLFFRRFLL",
                "0 3 W",
                "LLFFFLFLFL"
            };

            var simulation = new Simulation(input);

            // Act
            var actual = simulation.Run();

            // Assert
            actual.Should().Be(
@"1 1 E
3 3 N LOST
2 3 S
"
);
        }
    }
}
