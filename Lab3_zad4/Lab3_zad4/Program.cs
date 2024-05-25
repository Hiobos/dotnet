using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSATool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Generuj klucze RSA");
            Console.WriteLine("2. Szyfruj plik");
            Console.WriteLine("3. Deszyfruj plik");
            Console.Write("Wybierz opcję: ");
            var opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    GenerujKluczeRSA();
                    break;
                case "2":
                    SzyfrujPlik();
                    break;
                case "3":
                    DeszyfrujPlik();
                    break;
                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }
        }

        static void GenerujKluczeRSA()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                var kluczPubliczny = rsa.ToXmlString(false);
                var kluczPrywatny = rsa.ToXmlString(true);

                File.WriteAllText("klucz_publiczny.xml", kluczPubliczny);
                File.WriteAllText("klucz_prywatny.xml", kluczPrywatny);

                Console.WriteLine("Klucze wygenerowane i zapisane do plików 'klucz_publiczny.xml' oraz 'klucz_prywatny.xml'.");
            }
        }

        static void SzyfrujPlik()
        {
            Console.Write("Podaj ścieżkę do pliku: ");
            var sciezkaPliku = Console.ReadLine();
            var dane = File.ReadAllBytes(sciezkaPliku);

            var kluczPubliczny = File.ReadAllText("klucz_publiczny.xml");
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(kluczPubliczny);
                var zaszyfrowaneDane = rsa.Encrypt(dane, false);
                File.WriteAllBytes(sciezkaPliku + ".enc", zaszyfrowaneDane);
                Console.WriteLine($"Plik zaszyfrowany i zapisany jako '{sciezkaPliku}.enc'.");
            }
        }

        static void DeszyfrujPlik()
        {
            Console.Write("Podaj ścieżkę do zaszyfrowanego pliku: ");
            var sciezkaPliku = Console.ReadLine();
            var zaszyfrowaneDane = File.ReadAllBytes(sciezkaPliku);

            var kluczPrywatny = File.ReadAllText("klucz_prywatny.xml");
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(kluczPrywatny);
                var odszyfrowaneDane = rsa.Decrypt(zaszyfrowaneDane, false);
                File.WriteAllBytes(sciezkaPliku.Replace(".enc", ".dec"), odszyfrowaneDane);
                Console.WriteLine($"Plik odszyfrowany i zapisany jako '{sciezkaPliku.Replace(".enc", ".dec")}'.");
            }
        }
    }
}
