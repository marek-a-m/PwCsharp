using System;

class Program
{
    static void Main(string[] args)
    {
        Produkt mleko = new Produkt("mleko", 3.5);
        Produkt jajka = new Produkt("jajka", 10);
        Produkt ser = new Produkt("ser", 15);
        Produkt majonez = new Produkt("majonez", 5);
        Koszyk koszyk = new Koszyk();
        koszyk.DodajProdukt(mleko);
        koszyk.DodajProdukt(jajka);
        koszyk.DodajProdukt(ser);
        koszyk.DodajProdukt(majonez);
        koszyk.Zawartosc();

       

    }
}
class Produkt
{
    public string Nazwa;
    private double Cena;

    public Produkt(string nazwa, double cena)
    {
        Nazwa = nazwa;
        Cena = cena;
    }

    public double ZwrocCene()
    {
        return Cena;
    }

}
class Koszyk
{
    public List<Produkt>? zawartosc;
    private double wartoscKoszyka = 0;
    public Koszyk()
    {
        zawartosc = new List<Produkt>();
    }
    public void DodajProdukt(Produkt produkt)
    {
        this.zawartosc.Add(produkt);
    }
    public void Zawartosc()
    {
        foreach (Produkt produkt in  zawartosc)
        {
            System.Console.WriteLine(produkt.Nazwa);
            wartoscKoszyka = wartoscKoszyka + produkt.ZwrocCene();
        }
        System.Console.WriteLine($"Cena końcowa {wartoscKoszyka}");
    }

}
class Samochod
{
    public string Nazwa = "Seat";
    public string Marka;
    public int Poziom_Paliwa;
    public bool czy_jedzie = false;
    public Samochod(string nazwa, string marka, int poziom_Paliwa)
    {
        Nazwa = nazwa;
        Marka = marka;
        Poziom_Paliwa = poziom_Paliwa;
    }

    public void Dzwiek()
    {
        Console.WriteLine("Odglos silnika");
    }
    public void Zatankuj (int iloscPaliwa)
    {
        this.Poziom_Paliwa = iloscPaliwa + Poziom_Paliwa;
    }

    public void Jedz()
    {
        if (this.Poziom_Paliwa == 0 )
        {
            Console.WriteLine("Zbiornik pusty");
            this.czy_jedzie = false;

        } else
        {
            Console.WriteLine($"Zostało {this.Poziom_Paliwa}");
            this.czy_jedzie = true;
        }
    }

}
class Osoba
{
    public string Imie;
    private int Wiek;

    public Osoba(string imie, int wiek)
    {
        Imie = imie;
        Wiek = wiek;
    }

    public void Wyswietl()
    {
        Console.WriteLine($"Imie: {Imie}, Wiek: {Wiek}");
    }
}

class Bmi
{
    public Bmi() {
        try
        {

            Console.WriteLine("Podaj wagę w kilogramach:");
            double waga = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj swój wzrost w metrach: ");
            double wzrost = Convert.ToDouble(Console.ReadLine());
            double bmi = waga / (wzrost * wzrost);
            string formatedBmi = bmi.ToString("0.##");

            // Wyświetlenie wyniku
            Console.Write($"Twoje BMI to: {formatedBmi}");
            if (bmi < 15)
            {
                Console.WriteLine(" wskazuje na wygłodzenie");

            }
            else if (bmi < 17.5 && bmi >= 15)
            {
                Console.WriteLine(" wskazuje na wychudzenie");
            }
            else if (bmi >= 17.5 && bmi < 18.5)
            {
                Console.WriteLine(" wskazuje na niedowagę");
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                Console.WriteLine(" wskazuje na wagę prawidłową");
            }
            else if (bmi >= 25 && bmi < 30)
            {
                Console.WriteLine(" wskazuje na nadwagę");
            }
            else if (bmi >= 30 && bmi < 35)
            {
                Console.WriteLine(" wskazuje na I stopień odyłości");
            }
            else if (bmi >= 35 && bmi < 40)
            {
                Console.WriteLine(" wskazuje na II stopień odyłości");
            }
            else
            {
                Console.WriteLine(" wzkazuje na otyłość skrajną");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.ToString());
            Console.WriteLine("błąd - wymagana liczba");
        }
    }
}