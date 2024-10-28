using System;
using System.IO;

public class FileReader
{
    public string ReadFileIntoString(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File not found: {ex.Message}");
            return string.Empty; 
        }
    }
}
