namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns>True if point exists inside the map.</returns>
    public abstract bool Exist(Simulator.Point p);

    /// <summary>
    /// Next position from the given point in the given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction of movement.</param>
    /// <returns>New point after movement.</returns>
    public abstract Simulator.Point Next(Simulator.Point p, Simulator.Direction d);

    /// <summary>
    /// Next diagonal position rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction of movement.</param>
    /// <returns>New point after diagonal movement.</returns>
    public abstract Simulator.Point NextDiagonal(Simulator.Point p, Simulator.Direction d);
}
