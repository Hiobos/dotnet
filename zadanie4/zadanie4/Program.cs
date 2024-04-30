using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Ścieżka do pliku tekstowego
        string sciezkaDoPliku = "D:\\studia\\programowanie .net\\dotnet\\1\\zadanie4\\zadanie4/text.txt";

        try
        {
            // Otwarcie pliku za pomocą StreamReader
            using (StreamReader sr = new StreamReader(sciezkaDoPliku))
            {
                string linia;
                while ((linia = sr.ReadLine()) != null)
                {
                    // Wyświetlenie linii w odwrotnej kolejności
                    for (int i = linia.Length - 1; i >= 0; i--)
                    {
                        Console.Write(linia[i]);
                    }
                    Console.WriteLine(); // Nowa linia po każdej linii
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
