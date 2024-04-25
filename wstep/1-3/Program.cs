/*3.Utwórz klasę Zamowienie.

    W klasie zdefiniuj pola reprezentujące datę realizacji, nazwę klienta, pozycje zamównienia (jako tablicę obiektów klasy Sprzedaz, zakładając obecność maksymalnie 20-stu pozycji w jednym zamówieniu).
    Zaimplementuj konstruktor, który przekazuje datę i kupującego oraz przydziela pamięć dla tablicy pozycji zamówienia.
    Zaimplementuj metodę dodajPozycje() dodającą do zamówienia kolejną pozycję. Zaimplementuj dwie postaci tej metody:

-dodajPozycje(Sprzedaz pozycja) oraz dodajPozycje(string p, int a, decimal sP).
-Zaimplementuj metodę wypisującą informacje o zamówieniu (w tym informacje o wszystkich pozycjach tego zamówienia) na konsoli.

Przetestuj zaimplementowane składowe pisząc odpowiedni kod testowy w metodzie Main().*/
using System;

class Sprzedaz
{
    public string Produkt { get; set; }
    public int Ilosc { get; set; }
    public decimal CenaJednostkowa { get; set; }

    public Sprzedaz(string produkt, int ilosc, decimal cenaJednostkowa)
    {
        Produkt = produkt;
        Ilosc = ilosc;
        CenaJednostkowa = cenaJednostkowa;
    }
}

class Zamowienie
{
    private DateTime dataRealizacji;
    private string klient;
    private Sprzedaz[] pozycjeZamowienia;
    private int iloscPozycji;

    public Zamowienie(DateTime dataRealizacji, string klient)
    {
        this.dataRealizacji = dataRealizacji;
        this.klient = klient;
        pozycjeZamowienia = new Sprzedaz[20]; // Maksymalnie 20 pozycji w zamówieniu
        iloscPozycji = 0;
    }

    public void DodajPozycje(Sprzedaz pozycja)
    {
        if (iloscPozycji < 20)
        {
            pozycjeZamowienia[iloscPozycji] = pozycja;
            iloscPozycji++;
        }
        else
        {
            Console.WriteLine("Nie można dodać kolejnej pozycji. Limit pozycji w zamówieniu został osiągnięty.");
        }
    }

    public void DodajPozycje(string produkt, int ilosc, decimal cenaJednostkowa)
    {
        DodajPozycje(new Sprzedaz(produkt, ilosc, cenaJednostkowa));
    }

    public void WypiszInformacje()
    {
        Console.WriteLine($"Data realizacji: {dataRealizacji}");
        Console.WriteLine($"Klient: {klient}");
        Console.WriteLine("Pozycje zamówienia:");
        for (int i = 0; i < iloscPozycji; i++)
        {
            Console.WriteLine($"{i + 1}. Produkt: {pozycjeZamowienia[i].Produkt}, Ilość: {pozycjeZamowienia[i].Ilosc}, Cena jednostkowa: {pozycjeZamowienia[i].CenaJednostkowa}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie zamówienia
        Zamowienie zamowienie = new Zamowienie(DateTime.Now, "Firma XYZ");

        // Dodawanie pozycji do zamówienia
        zamowienie.DodajPozycje(new Sprzedaz("Laptop", 2, 2500));
        zamowienie.DodajPozycje("Monitor", 3, 600);

        // Wyświetlenie informacji o zamówieniu
        zamowienie.WypiszInformacje();
    }
}