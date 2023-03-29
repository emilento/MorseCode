using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace MorseCode
{
    public class Tests
    {
        [Fact]
        public void TestWhenInputIsEmpty()
        {
            // Arrange
            var morse = new MorseDecoder();
            
            // Act
            var actual = morse.Decode(string.Empty).ToList();

            // Assert
            actual.Should().HaveCount(1);
            actual[0].Should().BeEmpty();
        }

        [Theory]
        [InlineAutoData("...---..-....-", "SOFIA")]
        [InlineAutoData("...---..-....-", "EUGENIA")]
        public void TestWhenInputIsNotEmpty(string input, string expected)
        {
            // Arrange
            var morse = new MorseDecoder();

            // Act
            var actual = morse.Decode(input).ToList();

            // Assert
            actual.Should().HaveCountGreaterOrEqualTo(1);
            actual.Should().Contain(expected);
        }
    }
}
