

/*4.Utwórz klasę RandomUtility zawierającą narzędzia do generowania losowego.


        W klasie zdefiniuj metody:

    a) do losowego generowania liczby z podanego przedziału dla różnych typów liczbowych ( int, decimal, double): randomInt(a, b), randomDecimal(a, b), randomDouble(a, b)
    b) do losowego generowania łańcucha znakowego (stringa) składającego się z n dowolnych znaków: randomString(n)
    dla uproszczenia można założyć, że string ma składać się wyłącznie z liter
    c) do losowego wybierania n elementów z podanej tablicy (z możliwością powtórzeń lub bez): randomFromArray(n, array, rep)

Przetestuj te metody w klasie testowej (z metodą Main()).*/

using System;

class RandomUtility
{
    private static Random random = new Random();

    // Metoda do generowania losowej liczby całkowitej z podanego przedziału [a, b]
    public static int RandomInt(int a, int b)
    {
        return random.Next(a, b + 1);
    }

    // Metoda do generowania losowej liczby typu decimal z podanego przedziału [a, b]
    public static decimal RandomDecimal(decimal a, decimal b)
    {
        double range = (double)(b - a) * (double)random.NextDouble();
        return a + (decimal)range;
    }

    // Metoda do generowania losowej liczby typu double z podanego przedziału [a, b)
    public static double RandomDouble(double a, double b)
    {
        return a + (b - a) * random.NextDouble();
    }

    // Metoda do generowania losowego łańcucha znaków o długości n
    public static string RandomString(int n)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        char[] result = new char[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }
        return new string(result);
    }

    // Metoda do losowego wybierania n elementów z tablicy (z możliwością powtórzeń lub bez)
    public static T[] RandomFromArray<T>(int n, T[] array, bool repeat = false)
    {
        if (n > array.Length && !repeat)
        {
            throw new ArgumentException("Liczba elementów do wylosowania przekracza rozmiar tablicy.");
        }

        T[] result = new T[n];
        for (int i = 0; i < n; i++)
        {
            int index = random.Next(array.Length);
            result[i] = array[index];
            if (!repeat)
            {
                // Usunięcie wylosowanego elementu z tablicy, jeśli losowanie bez powtórzeń
                T[] newArray = new T[array.Length - 1];
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);
                array = newArray; 
            }
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Przykładowe użycie metod klasy RandomUtility

        // Losowa liczba całkowita z przedziału [1, 10]
        int randomInt = RandomUtility.RandomInt(1, 10);
        Console.WriteLine("Losowa liczba całkowita: " + randomInt);

        // Losowa liczba typu decimal z przedziału [1.0, 10.0]
        decimal randomDecimal = RandomUtility.RandomDecimal(1.0m, 10.0m);
        Console.WriteLine("Losowa liczba typu decimal: " + randomDecimal);

        // Losowa liczba typu double z przedziału [1.0, 10.0)
        double randomDouble = RandomUtility.RandomDouble(1.0, 10.0);
        Console.WriteLine("Losowa liczba typu double: " + randomDouble);

        // Losowy łańcuch znaków o długości 5
        string randomString = RandomUtility.RandomString(5);
        Console.WriteLine("Losowy łańcuch znaków: " + randomString);

        // Losowy wybór 3 elementów z tablicy, bez powtórzeń
        int[] array = { 1, 2, 3, 4, 5 };
        int[] randomFromArray = RandomUtility.RandomFromArray(3, array);
        Console.WriteLine("Losowy wybór 3 elementów z tablicy: " + string.Join(", ", randomFromArray));

        // Losowy wybór 5 elementów z tablicy, z powtórzeniami
        string[] stringArray = { "a", "b", "c", "d", "e" };
        string[] randomStringArray = RandomUtility.RandomFromArray(5, stringArray, repeat: true);
        Console.WriteLine("Losowy wybór 5 elementów z tablicy z powtórzeniami: " + string.Join(", ", randomStringArray));
    }
}