/*2.Napisać klasę Zespolone opisujące operacje na liczbach zespolonych.

    Pokazać w main podstawowe obliczenia.*/

class Zespolone
{
    private double re;
    private double im;


    public Zespolone(double real, double imaginary)
    {
        re = real;
        im = imaginary;
    }

    public Zespolone Add(Zespolone z)
    {
        return new Zespolone(re + z.re, im + z.im);
    }

 
    public Zespolone Substract(Zespolone z)
    {
        return new Zespolone(re - z.re, im - z.im);
    }

    public Zespolone Multiply(Zespolone z)
    {
        double realPart = re * z.re - im * z.im;
        double imagPart = re * z.im + im * z.re;
        return new Zespolone(realPart, imagPart);
    }

    public override string ToString()
    {
        if (im >= 0)
            return $"{re} + {im}i";
        else
            return $"{re} - {-im}i";
    }
}

class Program
{
    static void Main(string[] args)
    {

        Zespolone z1 = new Zespolone(5, 15);
        Zespolone z2 = new Zespolone(10, -12);
        Console.WriteLine($"z1 = {z1}");
        Console.WriteLine($"z2 = {z2}");
        Console.WriteLine($"Suma: {z1.Add(z2)}");
        Console.WriteLine($"Różnica: {z1.Substract(z2)}");
        Console.WriteLine($"Iloczyn: {z1.Multiply(z2)}");
    }
}