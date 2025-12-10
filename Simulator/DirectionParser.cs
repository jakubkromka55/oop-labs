namespace Simulator;

using System;
using System.Collections.Generic;

public static class DirectionParser
{
    /// <summary>
    /// Parse whole string into array of directions.
    /// Keeps only valid characters: U R D L (case-insensitive).
    /// </summary>
    public static Direction[] Parse(string s)
    {
        var list = new List<Direction>();

        if (string.IsNullOrEmpty(s))
            return list.ToArray();

        foreach (char c in s.ToUpper())
        {
            switch (c)
            {
                case 'U': list.Add(Direction.Up); break;
                case 'R': list.Add(Direction.Right); break;
                case 'D': list.Add(Direction.Down); break;
                case 'L': list.Add(Direction.Left); break;
                default: break; // ignore invalid chars
            }
        }

        return list.ToArray();
    }

    /// <summary>
    /// Tries to parse a single-character (or single-letter) direction.
    /// Accepts "U","R","D","L" (case-insensitive) or the whole word ("Up","Right",...).
    /// Returns true if parsed, false otherwise.
    /// </summary>
    public static bool TryParse(string s, out Direction d)
    {
        d = default;

        if (string.IsNullOrEmpty(s))
            return false;

        // Accept single character like "U" or full words like "Up"
        var t = s.Trim().ToUpper();

        if (t.Length == 0)
            return false;

        // if the caller passed a multi-char string, try to match known names
        if (t.Equals("UP", StringComparison.OrdinalIgnoreCase))
        {
            d = Direction.Up;
            return true;
        }
        if (t.Equals("RIGHT", StringComparison.OrdinalIgnoreCase))
        {
            d = Direction.Right;
            return true;
        }
        if (t.Equals("DOWN", StringComparison.OrdinalIgnoreCase))
        {
            d = Direction.Down;
            return true;
        }
        if (t.Equals("LEFT", StringComparison.OrdinalIgnoreCase))
        {
            d = Direction.Left;
            return true;
        }

        // take first char if given as single-letter
        char c = t[0];
        switch (c)
        {
            case 'U': d = Direction.Up; return true;
            case 'R': d = Direction.Right; return true;
            case 'D': d = Direction.Down; return true;
            case 'L': d = Direction.Left; return true;
            default: return false;
        }
    }
}
