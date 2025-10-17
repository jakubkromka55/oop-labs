// Write required code.

// Data - do not change it in code!
string[] names = {
    "Mickey Mouse", "Minnie Mouse", "Donald Duck", "Goofy", "Pluto", "Daisy Duck", "Simba", "Nala",
    "Timon", "Pumbaa", "Mufasa", "Ariel", "Flounder", "Sebastian", "Ursula", "Belle", "Beast", "Gaston",
    "Cinderella", "Prince Charming", "Aurora", "Maleficent", "Rapunzel", "Flynn Rider", "Elsa", "Anna",
    "Olaf", "Moana", "Maui", "Hercules"
};


// Print all array elements, *perLine* elements per one line
// After all elements except last one should be ", " - also on the end of lines.
// After last element should be ".".
void PrintGroups(string[] t, int perLine)
{
    for (int i = 0; i < t.Length; i++)
    {
        
        Console.Write(t[i]);

        
        if (i < t.Length - 1)
        {
            Console.Write(", "); 
        }
        else
        {
            Console.Write("."); 
        }

        
        if ((i + 1) % perLine == 0 && i != t.Length - 1)
        {
            Console.WriteLine();
        }
    }

    Console.WriteLine(); 
}



// Print all array elements in *perLine* columns.
// Each column must have given *width* (number of chars).
// Columns should be separated by "| ".
// If element is too long it should be trimmed.

void PrintColumns(string[] t, int perLine, int width)
{
    for (int i = 0; i < t.Length; i++)
    {
        
        string text = t[i].Length > width ? t[i].Substring(0, width) : t[i];

        
        Console.Write(text.PadRight(width));

        
        if ((i + 1) % perLine != 0 && i != t.Length - 1)
        {
            Console.Write(" | ");
        }

        
        if ((i + 1) % perLine == 0)
        {
            Console.WriteLine();
        }
    }

    Console.WriteLine(); 
}



Console.WriteLine("\nPrintGroups(names, 3):\n");
PrintGroups(names, 3);

Console.WriteLine("\nPrintGroups(names, 5):\n");
PrintGroups(names, 5);

Console.WriteLine("\nPrintGroups(names, 7):\n");
PrintGroups(names, 7);

Console.WriteLine("\nPrintGroups(names, 40):\n");
PrintGroups(names, 40);

Console.WriteLine("\n\nPrintColumns(names, 4, 17):\n");
PrintColumns(names, 4, 17);

Console.WriteLine("\n\nPrintColumns(names, 5, 15):\n");
PrintColumns(names, 5, 15);

Console.WriteLine("\n\nPrintColumns(names, 8, 10):\n");
PrintColumns(names, 8, 10);
