public class Car
{
    public int Id { get; set; }  // ID машины как строка
    public string Type { get; set; }  // Тип машины: ELECTRIC или GAS
    public string Passengers { get; set; }  // Кто в машине: PEOPLE или ROBOTS
    public bool IsDining { get; set; }  // Нужно ли подавать ужин
    public int Consumption { get; set; }  // Потребление энергии/топлива

    public Car(int id, string type, string passengers, bool isDining, int consumption)
    {
        Id = id;
        Type = type;
        Passengers = passengers;
        IsDining = isDining;
        Consumption = consumption;
    }
}
