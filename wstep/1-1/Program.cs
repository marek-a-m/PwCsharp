using System;

class Produkt
{
    public string Name;
    public double Prize;
    public string Uom;
    public DateOnly PurchaseDate;
    public int VatRate;
    public double Margin;

    public Produkt(string name, double prize, string uom, DateOnly purchaseDate, int vatRate, double margin)
    {
        Name = name;
        Prize = prize;
        Uom = uom;
        PurchaseDate = purchaseDate;
        VatRate = vatRate;
        Margin = margin;
    }
}

//Utwórz klasę o nazwie Produkt.

/*W klasie zdefiniuj pola reprezentujące nazwę, cenę zakupu, jednostkę miary, datę zakupu, stawkę VAT, marżę (zysku).
    Zaimplementuj konstruktor klasy (przekazujący wartości do pól) oraz metodę wypisującą dane produktu na konsolę.
    Zaimplementuj konstruktor tworzący obiekt w oparciu o wartości podane z konsoli.
    Dodaj kilka obiektów.
*/