using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    public void ClassifyAndPrint()
    {
        string jsonString = ReadFile();

        if (!string.IsNullOrEmpty(jsonString))
        {
            try
            {
                var data = JsonSerializer.Deserialize<JsonInput>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                Console.WriteLine("Classified Individuals by Universe:");
                foreach (var individual in data.Input)
                {
                    Console.WriteLine($"ID: {individual.Id}");

                    string universe = ClassifyHumanoid(individual);

                    Console.WriteLine($"Assigned Universe: {universe}");

                    if (individual.IsHumanoid.HasValue)
                        Console.WriteLine($"Is Humanoid: {individual.IsHumanoid.Value}");

                    if (!string.IsNullOrWhiteSpace(individual.Planet))
                        Console.WriteLine($"Planet: {individual.Planet}");

                    if (individual.Age.HasValue)
                        Console.WriteLine($"Age: {individual.Age.Value}");

                    if (individual.Traits != null && individual.Traits.Count > 0)
                        Console.WriteLine($"Traits: {string.Join(", ", individual.Traits)}");

                    Console.WriteLine();  
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
        }
    }

public string ClassifyHumanoid(Individual individual)
{
    if (individual.IsHumanoid.HasValue && individual.IsHumanoid.Value || !individual.IsHumanoid.HasValue)
    {
        if (!string.IsNullOrEmpty(individual.Planet))
        {
            if (individual.Planet == "Earth")
                return "Lord of the Rings";  

            if (individual.Planet == "Asgard")
                return "Marvel"; 
            if (individual.Planet == "Betelgeuse")
                return "Hitchhiker";
        }
        else
        {

            if (individual.Traits != null && 
                individual.Traits.Contains("SHORT", StringComparer.OrdinalIgnoreCase) ||
                individual.Traits.Contains("BULKY", StringComparer.OrdinalIgnoreCase))
            {
                return "Lord of the Rings";
            }

            if (individual.Traits != null &&
                individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                individual.Traits.Contains("BLONDE", StringComparer.OrdinalIgnoreCase))
            {
                return "Marvel";
            }

            if (individual.Traits != null &&
                individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                individual.Traits.Contains("POINTY_EARS", StringComparer.OrdinalIgnoreCase))
            {
                return "Lord of the Rings";
            }

            if (individual.Age.HasValue && individual.Age > 5000)
            {
                return "Lord of the Rings";  
            }
        }
    }
    
    if (individual.IsHumanoid.HasValue && !individual.IsHumanoid.Value)
    {
        if (!string.IsNullOrEmpty(individual.Planet))
        {
            if (individual.Planet == "Kashyyyk" || individual.Planet == "Endor")
                return "Star Wars"; 

            if (individual.Planet == "Vogsphere")
                return "Hitchhiker";
        }
        else
        {

            if (individual.Traits != null && individual.Traits.Contains("SHORT", StringComparer.OrdinalIgnoreCase))
            {
                return "Star Wars";
            }

            if (individual.Traits != null &&
                individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                individual.Traits.Contains("HAIRY", StringComparer.OrdinalIgnoreCase))
            {
                return "Star Wars";
            }

            if (individual.Traits != null &&
                individual.Traits.Contains("GREEN", StringComparer.OrdinalIgnoreCase) ||
                individual.Traits.Contains("BULKY", StringComparer.OrdinalIgnoreCase))
            {
                return "Hitchhiker";
            }

            if (individual.Age.HasValue && individual.Age > 200)
            {
                return "Star Wars";  
            }
        }
    }

    if (!individual.IsHumanoid.HasValue)
    {
        if (!string.IsNullOrEmpty(individual.Planet))
        {
            if (individual.Planet == "Earth")
                return "Lord of the Rings";  

            if (individual.Planet == "Asgard")
                return "Marvel"; 

            if (individual.Planet == "Betelgeuse" || individual.Planet == "Vogsphere")
                return "Hitchhiker"; 

            if (individual.Planet == "Kashyyyk" || individual.Planet == "Endor")
                return "Star Wars";

        }
        else
        {

            if (individual.Traits != null &&
                individual.Traits.Contains("SHORT", StringComparer.OrdinalIgnoreCase) &&
                individual.Traits.Contains("BULKY", StringComparer.OrdinalIgnoreCase))
            {
                return "Lord of the Rings";  
            }

            if (individual.Traits != null &&
                individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                individual.Traits.Contains("BLONDE", StringComparer.OrdinalIgnoreCase))
            {
                return "Marvel";
            }

            if (individual.Traits != null &&
                individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                individual.Traits.Contains("POINTY_EARS", StringComparer.OrdinalIgnoreCase))
            {
                return "Lord of the Rings";
            }

            if (individual.Traits != null && individual.Traits.Contains("HAIRY", StringComparer.OrdinalIgnoreCase))
            {
                return "Star Wars";
            }
            if (individual.Traits != null && individual.Traits.Contains("EXTRA_ARMS", StringComparer.OrdinalIgnoreCase)||
            individual.Traits.Contains("EXTRA_HEAD", StringComparer.OrdinalIgnoreCase))
                return "Hitchhiker";
        }
    }

    return "Unknown Universe";
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
        reader.ClassifyAndPrint();  
    }
}
