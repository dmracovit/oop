using System;
using System.IO;

public class FileReader
{
    public string FilePath { get; set; }

    public FileReader(string filePath)
    {
        FilePath = filePath;
    }

    public string ReadFile()
    {
        try
        {
            return File.ReadAllText(FilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return string.Empty;
        }
    }

    public void PrintRawJson()
    {
        string jsonString = ReadFile();

        if (!string.IsNullOrEmpty(jsonString))
        {
            Console.WriteLine("Raw JSON Content:");
            Console.WriteLine(jsonString);
        }
        else
        {
            Console.WriteLine("No content to display.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        string filePath = "/home/dima/Documents/oop/main/input.json";  
        
        FileReader reader = new FileReader(filePath);
        reader.PrintRawJson(); 
    }
}
