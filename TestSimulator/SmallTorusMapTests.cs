using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void InvalidSize_ShouldThrow(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Fact]
    public void ValidSize_ShouldSetProperty()
    {
        var map = new SmallSquareMap(10);
        Assert.Equal(10, map.Size);
    }

    [Fact]
    public void Exist_ShouldReturnFalseOutside()
    {
        var map = new SmallSquareMap(10);
        Assert.False(map.Exist(new Point(-1, 5)));
        Assert.False(map.Exist(new Point(5, 10)));
    }

    [Fact]
    public void Next_ShouldStopAtBoundary()
    {
        var map = new SmallSquareMap(5);
        var p = new Point(4, 4);
        Assert.Equal(p, map.Next(p, Direction.Right));
        Assert.Equal(p, map.Next(p, Direction.Up));
    }

    [Fact]
    public void NextDiagonal_ShouldStopAtBoundary()
    {
        var map = new SmallSquareMap(5);
        var p = new Point(4, 4);
        Assert.Equal(p, map.NextDiagonal(p, Direction.Right));
    }
}
