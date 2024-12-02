public class Car
{
    public int Id { get; set; } 
    public string Type { get; set; }  
    public string Passengers { get; set; }  
    public bool IsDining { get; set; }  
    public int Consumption { get; set; }  

    public Car(int id, string type, string passengers, bool isDining, int consumption)
    {
        Id = id;
        Type = type;
        Passengers = passengers;
        IsDining = isDining;
        Consumption = consumption;
    }
}
