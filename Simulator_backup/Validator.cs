namespace Simulator;

using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static string Shortener(string? value, int min, int max, char placeholder)
    {
        if (string.IsNullOrWhiteSpace(value))
            value = new string(placeholder, min);

        // trim edges and normalize internal whitespace
        var trimmed = value.Trim();
        trimmed = Regex.Replace(trimmed, @"\s+", " ");

        if (trimmed.Length > max)
            trimmed = trimmed.Substring(0, max).TrimEnd();

        if (trimmed.Length < min)
            trimmed = trimmed.PadRight(min, placeholder);

        // capitalize first letter if needed
        if (!string.IsNullOrEmpty(trimmed) && char.IsLower(trimmed[0]))
            trimmed = char.ToUpper(trimmed[0]) + trimmed[1..];

        return trimmed;
    }

    /// <summary>
    /// Check if a directions string is valid.
    /// Valid characters: U R D L u r d l and whitespace; others are invalid.
    /// Empty or whitespace-only string is considered valid (no directions).
    /// </summary>
    public static bool IsValidDirections(string? s)
    {
        if (s == null) return true;
        // allow letters U,R,D,L in any case and spaces
        foreach (char c in s)
        {
            if (char.IsWhiteSpace(c)) continue;
            char cu = char.ToUpperInvariant(c);
            if (cu != 'U' && cu != 'R' && cu != 'D' && cu != 'L')
                return false;
        }
        return true;
    }

    /// <summary>
    /// Validate creature/name: accepts only letters and optionally spaces/hyphens.
    /// Returns true for non-empty alphabetic names like "Orc" or "Elf" or "Big Orc".
    /// Returns false if contains digits or other symbols.
    /// </summary>
    public static bool ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;

        // allow letters, spaces and hyphens
        foreach (char c in name)
        {
            if (char.IsLetter(c) || c == ' ' || c == '-') continue;
            return false;
        }

        // at least one letter
        return name.Any(char.IsLetter);
    }
}
