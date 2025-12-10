namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string s)
    {
        var list = new List<Direction>();

        foreach (char c in s.ToUpper())
        {
            switch (c)
            {
                case 'U': list.Add(Direction.Up); break;
                case 'R': list.Add(Direction.Right); break;
                case 'D': list.Add(Direction.Down); break;
                case 'L': list.Add(Direction.Left); break;
            }
        }

        return list.ToArray();
    }
}
