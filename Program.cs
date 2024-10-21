using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;
using System.Text.Json.Serialization;

// reading the file content
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
}

// parsing the JSON input
public class JsonParser
{
    public JsonInput Parse(string jsonString)
    {
        try
        {
            return JsonSerializer.Deserialize<JsonInput>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error parsing JSON: {ex.Message}");
            return null;
        }
    }
}

// classifying individuals into universes
public class Classifier
{
    public Dictionary<string, List<Individual>> CategorizeIndividuals(List<Individual> individuals)
    {
        var categorizedIndividuals = new Dictionary<string, List<Individual>>
        {
            { "Marvel", new List<Individual>() },
            { "Lord of the Rings", new List<Individual>() },
            { "Star Wars", new List<Individual>() },
            { "Hitchhiker", new List<Individual>() }
        };

        foreach (var individual in individuals)
        {
            string universe = ClassifyHumanoid(individual);

            if (categorizedIndividuals.ContainsKey(universe))
            {
                categorizedIndividuals[universe].Add(individual);
            }
        }

        return categorizedIndividuals;
    }

    private string ClassifyHumanoid(Individual individual)
    {
        if (individual.IsHumanoid.HasValue && individual.IsHumanoid.Value || !individual.IsHumanoid.HasValue)
        {
            if (!string.IsNullOrEmpty(individual.Planet))
            {
                if (individual.Planet == "Earth") return "Lord of the Rings";
                if (individual.Planet == "Asgard") return "Marvel";
                if (individual.Planet == "Betelgeuse") return "Hitchhiker";
            }
            else
            {
                if (individual.Traits != null &&
                    (individual.Traits.Contains("SHORT", StringComparer.OrdinalIgnoreCase) ||
                     individual.Traits.Contains("BULKY", StringComparer.OrdinalIgnoreCase)))
                    return "Lord of the Rings";

                if (individual.Traits != null &&
                    individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                    individual.Traits.Contains("BLONDE", StringComparer.OrdinalIgnoreCase))
                    return "Marvel";

                if (individual.Traits != null &&
                    individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                    individual.Traits.Contains("POINTY_EARS", StringComparer.OrdinalIgnoreCase))
                    return "Lord of the Rings";

                if (individual.Age.HasValue && individual.Age > 5000)
                    return "Lord of the Rings";
            }
        }

        if (individual.IsHumanoid.HasValue && !individual.IsHumanoid.Value)
        {
            if (!string.IsNullOrEmpty(individual.Planet))
            {
                if (individual.Planet == "Kashyyyk" || individual.Planet == "Endor") return "Star Wars";
                if (individual.Planet == "Vogsphere") return "Hitchhiker";
            }
            else
            {
                if (individual.Traits != null && individual.Traits.Contains("SHORT", StringComparer.OrdinalIgnoreCase)) return "Star Wars";
                if (individual.Traits != null &&
                    individual.Traits.Contains("TALL", StringComparer.OrdinalIgnoreCase) &&
                    individual.Traits.Contains("HAIRY", StringComparer.OrdinalIgnoreCase))
                    return "Star Wars";

                if (individual.Traits != null &&
                    (individual.Traits.Contains("GREEN", StringComparer.OrdinalIgnoreCase) ||
                     individual.Traits.Contains("BULKY", StringComparer.OrdinalIgnoreCase)))
                    return "Hitchhiker";

                if (individual.Age.HasValue && individual.Age > 200) return "Star Wars";
            }
        }

        return "Unknown Universe";
    }
}

// saving categorized individuals to JSON files
public class FileSaver
{
    public void SaveToJsonFile(string universe, List<Individual> individuals)
    {
        var output = new
        {
            name = universe,
            individuals = individuals
        };

        string json = JsonSerializer.Serialize(output, new JsonSerializerOptions { WriteIndented = true });

        string filePath = $"{universe}.json";  // save as marvel.json, lotr.json, etc.
        try
        {
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Saved {universe} data to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }
}

// classes for JSON structure
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

// class to tie everything together
public class Program
{
    public static void Main()
    {
        string filePath = "/home/dima/Documents/oop/main/input.json";  

        FileReader reader = new FileReader(filePath);
        string jsonString = reader.ReadFile();

        if (!string.IsNullOrEmpty(jsonString))
        {
            JsonParser parser = new JsonParser();
            JsonInput data = parser.Parse(jsonString);

            if (data != null)
            {
                Classifier classifier = new Classifier();
                var categorizedIndividuals = classifier.CategorizeIndividuals(data.Input);

                FileSaver saver = new FileSaver();
                foreach (var universe in categorizedIndividuals.Keys)
                {
                    saver.SaveToJsonFile(universe, categorizedIndividuals[universe]);
                }
            }
        }
    }
}
