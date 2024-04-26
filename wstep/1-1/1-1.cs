//Utwórz klasę o nazwie Produkt.

/*W klasie zdefiniuj pola reprezentujące nazwę, cenę zakupu, jednostkę miary, datę zakupu, stawkę VAT, marżę (zysku).
    Zaimplementuj konstruktor klasy (przekazujący wartości do pól) oraz metodę wypisującą dane produktu na konsolę.
    Zaimplementuj konstruktor tworzący obiekt w oparciu o wartości podane z konsoli.
    Dodaj kilka obiektów.
*/
using System;

class Produkt
{
    public string Name;
    public double Prize;
    public string Uom;
    public DateTime PurchaseDate;
    public int VatRate;
    public double Margin;

    public Produkt(string name, double prize, string uom, DateTime purchaseDate, int vatRate, double margin)
    {
        Name = name;
        Prize = prize;
        Uom = uom;
        PurchaseDate = purchaseDate;
        VatRate = vatRate;
        Margin = margin;
    }
    public Produkt()
    {
        Console.WriteLine("Podaj nazwę produktu:");
        Name = Console.ReadLine();

        Console.WriteLine("Podaj cenę zakupu:");
        Prize = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Podaj jednostkę miary:");
        Uom = Console.ReadLine();

        Console.WriteLine("Podaj datę zakupu (RRRR-MM-DD):");
        PurchaseDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Podaj stawkę VAT (%):");
        VatRate = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Podaj marżę (%):");
        Margin = Convert.ToDouble(Console.ReadLine());
    }
    public void WypiszInformacje()
    {
        Console.WriteLine("Nazwa: " + Name);
        Console.WriteLine("Cena zakupu: " + Prize + " zł");
        Console.WriteLine("Jednostka miary: " + Uom);
        Console.WriteLine("Data zakupu: " + PurchaseDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("Stawka VAT: " + VatRate + "%");
        Console.WriteLine("Marża: " + Margin + "%");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Produkt produkt1 = new Produkt("Woda", 2.50, "litr", new DateTime(2024, 4, 20), 23, 10);
        Produkt produkt2 = new Produkt();
        Console.WriteLine("Informacje o produkcie 1:");
        produkt1.WypiszInformacje();
        Console.WriteLine("\nInformacje o produkcie 2:");
        produkt2.WypiszInformacje();
    }
}

