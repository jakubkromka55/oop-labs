using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Next_Up_ShouldIncreaseY()
    {
        var p = new Point(5, 5);
        var result = p.Next(Direction.Up);
        Assert.Equal(new Point(5, 6), result);
    }

    [Fact]
    public void Next_Left_ShouldDecreaseX()
    {
        var p = new Point(10, 3);
        var result = p.Next(Direction.Left);
        Assert.Equal(new Point(9, 3), result);
    }

    [Fact]
    public void NextDiagonal_Right_ShouldMoveCorrectly()
    {
        var p = new Point(0, 0);
        var result = p.NextDiagonal(Direction.Right);
        Assert.Equal(new Point(1, -1), result);
    }

    [Theory]
    [InlineData(Direction.Up, 1, 1)]
    [InlineData(Direction.Right, 1, -1)]
    [InlineData(Direction.Down, -1, -1)]
    [InlineData(Direction.Left, -1, 1)]
    public void NextDiagonal_ShouldRotate45Degrees(Direction dir, int dx, int dy)
    {
        var p = new Point(10, 10);
        var r = p.NextDiagonal(dir);

        Assert.Equal(new Point(10 + dx, 10 + dy), r);
    }
}
