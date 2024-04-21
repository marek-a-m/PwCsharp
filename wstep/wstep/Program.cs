class Program
{
    static void Main(string[] args)
    {
        // Prośba o podanie prędkości w km/h
        Console.WriteLine("Podaj prędkość w kilometrach na godzinę:");
        double kmh = Convert.ToDouble(Console.ReadLine());

        // Przeliczenie prędkości na m/s
        double ms = kmh * 1000 / 3600;
        string formattedMs = ms.ToString("0.##");

        // Wyświetlenie wyniku
        Console.WriteLine($"Prędkość w metrach na sekundę: {formattedMs} m/s");
    }
}