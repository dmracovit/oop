using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

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

    public void ParseAndPrint()
    {
        string jsonString = ReadFile();

        if (!string.IsNullOrEmpty(jsonString))
        {
            try
            {
                var data = JsonSerializer.Deserialize<JsonInput>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                Console.WriteLine("Parsed JSON Content:");
                foreach (var individual in data.Input)
                {
                    Console.WriteLine($"ID: {individual.Id}");

                    if (individual.IsHumanoid.HasValue)
                    {
                        Console.WriteLine($"Is Humanoid: {individual.IsHumanoid.Value}");
                    }

                    if (!string.IsNullOrWhiteSpace(individual.Planet))
                    {
                        Console.WriteLine($"Planet: {individual.Planet}");
                    }

                    if (individual.Age.HasValue)
                    {
                        Console.WriteLine($"Age: {individual.Age.Value}");
                    }

                    if (individual.Traits != null && individual.Traits.Count > 0)
                    {
                        Console.WriteLine($"Traits: {string.Join(", ", individual.Traits)}");
                    }

                    Console.WriteLine();  
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
        }
    }
}

public class JsonInput
{
    [JsonPropertyName("input")]
    public List<Individual> Input { get; set; }
}

public class Individual
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("isHumanoid")]
    public bool? IsHumanoid { get; set; }

    [JsonPropertyName("planet")]
    public string Planet { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int? Age { get; set; }

    [JsonPropertyName("traits")]
    public List<string> Traits { get; set; } = new List<string>();
}

public class Program
{
    public static void Main()
    {
        string filePath = "/home/dima/Documents/oop/main/input.json";  
        
        FileReader reader = new FileReader(filePath);
        reader.ParseAndPrint();  
    }
}
