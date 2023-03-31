using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace MorseCode;

public class Tests
{
    [Fact]
    public void TestWhenInputIsEmpty()
    {
        // Act
        var actual = new MorseDecoder().Decode(string.Empty).ToList();

        // Assert
        actual.Should().HaveCount(0);
    }

    [Theory]
    [InlineAutoData("...---..-....-", "sofia")]
    [InlineAutoData("...---..-....-", "eugenia")]
    public void TestWhenInputIsNotEmpty(string input, string expected)
    {
        // Act
        var actual = new MorseDecoder().Decode(input).ToList();

        // Assert
        actual.Should().HaveCount(5104);
        actual.Should().Contain(expected);
    }
}
