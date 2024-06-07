using System;

class Garaz
{
    private string adres;
    private int pojemnosc;
    private int liczbaSamochodow;
    private Samochod[] samochody;

    public string Adres
    {
        get { return adres; }
        set { adres = value; }
    }

    public int Pojemnosc
    {
        get { return pojemnosc; }
        set
        {
            pojemnosc = value;
            samochody = new Samochod[pojemnosc];
        }
    }

    public Garaz()
    {
        adres = "nieznany";
        pojemnosc = 0;
        liczbaSamochodow = 0;
        samochody = null;
    }

    public Garaz(string adres_, int pojemnosc_)
    {
        adres = adres_;
        Pojemnosc = pojemnosc_;
        liczbaSamochodow = 0;
    }

    public void WprowadzSamochod(Samochod samochod)
    {
        if (liczbaSamochodow < pojemnosc)
        {
            samochody[liczbaSamochodow] = samochod;
            liczbaSamochodow++;
        }
        else
        {
            Console.WriteLine("Garaż jest pełny.");
        }
    }

    public Samochod WyprowadzSamochod()
    {
        if (liczbaSamochodow > 0)
        {
            Samochod ostatniSamochod = samochody[liczbaSamochodow - 1];
            samochody[liczbaSamochodow - 1] = null;
            liczbaSamochodow--;
            return ostatniSamochod;
        }
        else
        {
            Console.WriteLine("Garaż jest pusty.");
            return null;
        }
    }

    public void WypiszInfo()
    {
        Console.WriteLine("Adres garażu: " + adres);
        Console.WriteLine("Pojemność garażu: " + pojemnosc);
        Console.WriteLine("Liczba garażowanych samochodów: " + liczbaSamochodow);
        Console.WriteLine("Informacje o garażowanych samochodach:");
        for (int i = 0; i < liczbaSamochodow; i++)
        {
            Console.WriteLine("Samochód " + (i + 1) + ":");
            samochody[i].WypiszInfo();
        }
    }
}
