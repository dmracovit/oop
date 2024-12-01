using Newtonsoft.Json;
using System;
using System.IO;


public enum CarType
{
    ELECTRIC,
    GAS
}


public class Car
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Passengers { get; set; }
    public bool IsDining { get; set; }
    public int Consumption { get; set; }

    public static Car FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Car>(json);
    }
}