using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Ścieżka do pliku tekstowego
        string sciezkaDoPliku = "D:\\studia\\programowanie .net\\dotnet\\1\\zadanie3\\zadanie3/text.txt";

        try
        {
            // Otwarcie pliku za pomocą FileStream
            using (FileStream fs = new FileStream(sciezkaDoPliku, FileMode.Open, FileAccess.Read))
            {
                // Utworzenie czytnika StreamReader
                using (StreamReader sr = new StreamReader(fs))
                {
                    // Odczytanie i wyświetlenie zawartości pliku linia po linii
                    string linia;
                    while ((linia = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linia);
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik nie istnieje.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Błąd wejścia-wyjścia: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.Message);
        }
    }
}
