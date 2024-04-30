using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Ścieżka do pliku źródłowego
        string sciezkaZrodlowa = "plik_zrodlowy.txt";
        // Ścieżka do pliku docelowego
        string sciezkaDocelowa = "plik_docelowy.txt";

        // Utworzenie pliku źródłowego o wielkości 300 MB
        UtworzPlik(sciezkaZrodlowa, 300 * 1024 * 1024); // 300 MB

        // Testowanie czasu kopiowania za pomocą różnych metod

        // 1. Kopiowanie za pomocą metody z poprzedniego zadania
        Console.WriteLine("Kopiowanie za pomocą FileStream:");
        TestujKopiowanie(sciezkaZrodlowa, sciezkaDocelowa, KopiowanieFileStream);

        // 2. Kopiowanie za pomocą metody File.Copy
        Console.WriteLine("Kopiowanie za pomocą File.Copy:");
        TestujKopiowanie(sciezkaZrodlowa, sciezkaDocelowa, KopiowanieFileCopy);

        // 3. Kopiowanie za pomocą metody File.ReadAllBytes i File.WriteAllBytes
        Console.WriteLine("Kopiowanie za pomocą File.ReadAllBytes i File.WriteAllBytes:");
        TestujKopiowanie(sciezkaZrodlowa, sciezkaDocelowa, KopiowanieReadAllBytesWriteAllBytes);

        // Usunięcie plików źródłowego i docelowego po zakończeniu testów
        File.Delete(sciezkaZrodlowa);
        File.Delete(sciezkaDocelowa);
    }

    static void UtworzPlik(string sciezka, long rozmiar)
    {
        using (FileStream fs = new FileStream(sciezka, FileMode.Create))
        {
            fs.SetLength(rozmiar);
        }
    }

    static void TestujKopiowanie(string sciezkaZrodlowa, string sciezkaDocelowa, Action<string, string> metodaKopiowania)
    {
        Stopwatch stoper = new Stopwatch();

        stoper.Start();
        metodaKopiowania(sciezkaZrodlowa, sciezkaDocelowa);
        stoper.Stop();

        Console.WriteLine("Czas kopiowania: " + stoper.Elapsed);
    }

    static void KopiowanieFileStream(string sciezkaZrodlowa, string sciezkaDocelowa)
    {
        using (FileStream fsZrodlo = new FileStream(sciezkaZrodlowa, FileMode.Open))
        using (FileStream fsDocelowy = new FileStream(sciezkaDocelowa, FileMode.Create))
        {
            byte[] bufor = new byte[1024];
            int odczytaneBajty;
            while ((odczytaneBajty = fsZrodlo.Read(bufor, 0, bufor.Length)) > 0)
            {
                fsDocelowy.Write(bufor, 0, odczytaneBajty);
            }
        }
    }

    static void KopiowanieFileCopy(string sciezkaZrodlowa, string sciezkaDocelowa)
    {
        File.Copy(sciezkaZrodlowa, sciezkaDocelowa);
    }

    static void KopiowanieReadAllBytesWriteAllBytes(string sciezkaZrodlowa, string sciezkaDocelowa)
    {
        byte[] dane = File.ReadAllBytes(sciezkaZrodlowa);
        File.WriteAllBytes(sciezkaDocelowa, dane);
    }
}
