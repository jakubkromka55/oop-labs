using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldSwapCoordinatesIfOutOfOrder()
    {
        var r = new Rectangle(10, 10, 0, 0);
        Assert.Equal("(0, 0):(10, 10)", r.ToString());
    }

    [Fact]
    public void Constructor_DegenerateRectangle_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 5));
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 5, 1));
    }

    [Theory]
    [InlineData(0, 0, 10, 10, 5, 5, true)]
    [InlineData(0, 0, 10, 10, 11, 5, false)]
    [InlineData(0, 0, 10, 10, 10, 10, true)]
    public void Contains_ShouldReturnCorrectResult(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var r = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(expected, r.Contains(new Point(px, py)));
    }
}
