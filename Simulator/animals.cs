namespace Simulator;

public class Animals
{
    private string description = "Unknown";

    public string Description
    {
        get => description;
        set => description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
