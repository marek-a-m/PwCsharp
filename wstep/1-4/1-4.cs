

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

    public static int RandomInt(int a, int b)
    {
        return random.Next(a, b + 1);
    }

    public static decimal RandomDecimal(decimal a, decimal b)
    {
        double range = (double)(b - a) * (double)random.NextDouble();
        return a + (decimal)range;
    }

    public static double RandomDouble(double a, double b)
    {
        return a + (b - a) * random.NextDouble();
    }

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

    public static T[] RandomFromArray<T>(int n, T[] array, bool repeat = false)
    {
        if (n > array.Length && !repeat)
        {
            throw new ArgumentException("Za duża liczba elementów.");
        }

        T[] result = new T[n];
        for (int i = 0; i < n; i++)
        {
            int index = random.Next(array.Length);
            result[i] = array[index];
            if (!repeat)
            {
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
        int number = 4;
        int randomInt = RandomUtility.RandomInt(1, 10);
        Console.WriteLine("Losowa liczba całkowita: " + randomInt);

        decimal randomDecimal = RandomUtility.RandomDecimal(1.0m, 10.0m);
        Console.WriteLine("Losowa liczba typu decimal: " + randomDecimal);

        double randomDouble = RandomUtility.RandomDouble(1.0, 10.0);
        Console.WriteLine("Losowa liczba typu double: " + randomDouble);

        string randomString = RandomUtility.RandomString(number);
        Console.WriteLine("Losowy łańcuch znaków: " + randomString);

        int[] array = { 1, 2, 3, 4, 5,7,8,9,10 };
        
        int[] randomFromArray = RandomUtility.RandomFromArray(number, array);
        Console.WriteLine($"Losowy wybór {number} elementów z tablicy: " + string.Join(", ", randomFromArray));

        string[] stringArray = { "a", "b", "c", "d", "e", "f", "g", "h"  };
        string[] randomStringArray = RandomUtility.RandomFromArray(number, stringArray, repeat: true);
        Console.WriteLine($"Losowy wybór {number} elementów z tablicy z powtórzeniami: " + string.Join(", ", randomStringArray));
    }
}