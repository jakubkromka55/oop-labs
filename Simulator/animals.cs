namespace Simulator;

public class Animals
{
    private string desc = "Unknown";

    public required string Description
    {
        get => desc;
        init
        {
            string d = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();

            if (d.Length > 15) d = d.Substring(0, 15).TrimEnd();
            if (d.Length < 3) d = d.PadRight(3, '#');
            if (char.IsLower(d[0])) d = char.ToUpper(d[0]) + d.Substring(1);

            desc = d;
        }
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
