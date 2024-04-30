using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj ścieżkę do pliku źródłowego:");
        string sciezkaZrodlowa = Console.ReadLine();

        Console.WriteLine("Podaj ścieżkę do pliku docelowego:");
        string sciezkaDocelowa = Console.ReadLine();

        try
        {
            // Otwarcie pliku źródłowego do odczytu
            using (FileStream fsZrodlo = new FileStream(sciezkaZrodlowa, FileMode.Open))
            {
                // Otwarcie pliku docelowego do zapisu
                using (FileStream fsDocelowy = new FileStream(sciezkaDocelowa, FileMode.Create))
                {
                    // Kopiowanie zawartości z pliku źródłowego do pliku docelowego
                    byte[] bufor = new byte[1024];
                    int odczytaneBajty;
                    while ((odczytaneBajty = fsZrodlo.Read(bufor, 0, bufor.Length)) > 0)
                    {
                        fsDocelowy.Write(bufor, 0, odczytaneBajty);
                    }
                }
            }

            Console.WriteLine("Plik został skopiowany pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.Message);
        }
    }
}
