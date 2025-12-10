namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        set => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => level;
        set => level = Validator.Limiter(value, 1, 10);
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void Upgrade() => Level = Validator.Limiter(Level + 1, 1, 10);

    public abstract void SayHi();

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract int Power { get; }

    // Map and position management
    private Simulator.Maps.Map? map = null;
    private Point? position = null;

    public (Simulator.Maps.Map? Map, Point? Position) Location => (map, position);

    /// <summary>
    /// Assign creature to a map at a given point. This will place the creature on the map immediately.
    /// </summary>
    public void AssignToMap(Simulator.Maps.Map targetMap, Point p)
    {
        if (targetMap is null) throw new ArgumentNullException(nameof(targetMap));
        if (!targetMap.Exist(p)) throw new ArgumentOutOfRangeException(nameof(p));
        // If currently on another map/position, remove
        if (map != null && position != null)
            map.Remove(this, position.Value);
        map = targetMap;
        position = p;
        map.Add(this, p);
    }

    /// <summary>
    /// Move creature one step in given direction using rules of the assigned map.
    /// If creature has no map assigned, it will not move.
    /// </summary>
    public void Go(Direction d)
    {
        if (map == null || position == null) return;
        var from = position.Value;
        var to = map.Next(from, d);
        // ask map to move creature (map may validate and update internal state)
        map.Move(this, from, to);
        position = to;
    }
}
