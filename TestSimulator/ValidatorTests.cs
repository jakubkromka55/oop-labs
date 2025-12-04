using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData("URDL", true)]
    [InlineData("XYZ", false)]
    [InlineData("", true)]
    public void IsValidDirectionString_ShouldWork(string input, bool expected)
    {
        var result = Validator.IsValidDirections(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ValidateCreatureName_ShouldAcceptAlphabetic()
    {
        Assert.True(Validator.ValidateName("Orc"));
    }

    [Fact]
    public void ValidateCreatureName_ShouldRejectInvalidCharacters()
    {
        Assert.False(Validator.ValidateName("Orc123"));
    }
}
