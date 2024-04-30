using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Zapisz dane do pliku binarnego");
        Console.WriteLine("2. Odczytaj dane z pliku binarnego");

        // Wczytanie wyboru użytkownika
        string wybor = Console.ReadLine();

        if (wybor == "1")
        {
            ZapiszDaneDoPliku();
        }
        else if (wybor == "2")
        {
            OdczytajDaneZPliku();
        }
        else
        {
            Console.WriteLine("Niepoprawny wybór.");
        }
    }

    static void ZapiszDaneDoPliku()
    {
        Console.WriteLine("Podaj dane do zapisu:");

        Console.Write("Imię: ");
        string imie = Console.ReadLine();

        Console.Write("Wiek: ");
        int wiek = int.Parse(Console.ReadLine());

        Console.Write("Adres: ");
        string adres = Console.ReadLine();

        // Tworzenie obiektu zawierającego dane
        DaneOsobowe dane = new DaneOsobowe(imie, wiek, adres);

        // Serializacja danych do formatu JSON i zapis do pliku
        string jsonString = JsonSerializer.Serialize(dane);
        File.WriteAllText("dane.json", jsonString);

        Console.WriteLine("Dane zostały zapisane do pliku.");
    }

    static void OdczytajDaneZPliku()
    {
        // Odczyt danych z pliku binarnego
        if (File.Exists("dane.json"))
        {
            // Odczyt zawartości pliku do stringa
            string jsonString = File.ReadAllText("dane.json");

            // Deserializacja danych z formatu JSON do obiektu
            DaneOsobowe dane = JsonSerializer.Deserialize<DaneOsobowe>(jsonString);

            Console.WriteLine("Odczytane dane:");
            Console.WriteLine("Imię: " + dane.Imie);
            Console.WriteLine("Wiek: " + dane.Wiek);
            Console.WriteLine("Adres: " + dane.Adres);
        }
        else
        {
            Console.WriteLine("Plik z danymi nie istnieje.");
        }
    }
}

class DaneOsobowe
{
    public string Imie { get; set; }
    public int Wiek { get; set; }
    public string Adres { get; set; }

    public DaneOsobowe(string imie, int wiek, string adres)
    {
        Imie = imie;
        Wiek = wiek;
        Adres = adres;
    }
}
