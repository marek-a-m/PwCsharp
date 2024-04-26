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
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrize { get; set; }

    public Sprzedaz(string product, int quantity, decimal unitprize)
    {
        Product = product;
        Quantity = quantity;
        UnitPrize = unitprize;
    }
}

class Zamowienie
{
    private DateTime DeliveryDate;
    private string Client;
    private Sprzedaz[] OrderItems;
    private int ItemNo;

    public Zamowienie(DateTime deliverydate, string client)
    {
        this.DeliveryDate = deliverydate;
        this.Client = client;
        OrderItems = new Sprzedaz[20]; 
        ItemNo = 0;
    }

    public void DodajPozycje(Sprzedaz pozycja)
    {
        if (ItemNo < 20)
        {
            OrderItems[ItemNo] = pozycja;
            ItemNo++;
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
        Console.WriteLine("Szczególy zamówienia:");
        Console.WriteLine($"Data realizacji: {DeliveryDate}");
        Console.WriteLine($"Klient: {Client}");
        Console.WriteLine("Pozycje zamówienia:");
        for (int i = 0; i < ItemNo; i++)
        {
            Console.WriteLine($"{i + 1}. Produkt: {OrderItems[i].Product}, Ilość: {OrderItems[i].Quantity}, Cena jednostkowa: {OrderItems[i].UnitPrize}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Zamowienie zamowienie = new Zamowienie(DateTime.Now, "Klient");
        zamowienie.DodajPozycje(new Sprzedaz("Koparka", 2, 250000));
        zamowienie.DodajPozycje("Szpadel", 30, 200);
        zamowienie.WypiszInformacje();
    }
}