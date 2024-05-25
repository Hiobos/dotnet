using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TestWydajnosciSzyfrowania
{
    class Program
    {
        static void Main(string[] args)
        {
            // Blok danych do testowania
            byte[] dane = Encoding.ASCII.GetBytes(new string('A', 1024)); // 1KB danych

            // Ścieżka pliku do testu wydajności HDD
            string sciezkaPliku = "plik_testowy.dat";

            // Algorytmy do testowania
            TestujAlgorytm("AES (CSP) 128 bit", () => new AesCryptoServiceProvider { KeySize = 128 }, dane, sciezkaPliku);
            TestujAlgorytm("AES (CSP) 256 bit", () => new AesCryptoServiceProvider { KeySize = 256 }, dane, sciezkaPliku);
            TestujAlgorytm("AES Managed 128 bit", () => new AesManaged { KeySize = 128 }, dane, sciezkaPliku);
            TestujAlgorytm("AES Managed 256 bit", () => new AesManaged { KeySize = 256 }, dane, sciezkaPliku);
            TestujAlgorytm("Rijndael Managed 128 bit", () => new RijndaelManaged { KeySize = 128 }, dane, sciezkaPliku);
            TestujAlgorytm("Rijndael Managed 256 bit", () => new RijndaelManaged { KeySize = 256 }, dane, sciezkaPliku);
            TestujAlgorytm("DES 56 bit", () => DES.Create(), dane, sciezkaPliku);
            TestujAlgorytm("3DES 168 bit", () => TripleDES.Create(), dane, sciezkaPliku);
        }

        static void TestujAlgorytm(string nazwaAlgorytmu, Func<SymmetricAlgorithm> fabrykaAlgorytmu, byte[] dane, string sciezkaPliku)
        {
            using (SymmetricAlgorithm algorytm = fabrykaAlgorytmu())
            {
                algorytm.GenerateKey();
                algorytm.GenerateIV();

                // Szyfrowanie i pomiar czasu na blok
                var czasSzyfrowania = MierzCzasSzyfrowania(algorytm, dane);

                // Pomiar przepustowości dla RAM
                var przepustowoscRAM = MierzPrzepustowosc(algorytm, dane);

                // Pomiar przepustowości dla HDD
                var przepustowoscHDD = MierzPrzepustowoscHDD(algorytm, dane, sciezkaPliku);

                Console.WriteLine($"{nazwaAlgorytmu}\t{czasSzyfrowania:F6} s/blok\t{przepustowoscRAM:F2} B/s (RAM)\t{przepustowoscHDD:F2} B/s (HDD)");
            }
        }

        static double MierzCzasSzyfrowania(SymmetricAlgorithm algorytm, byte[] dane)
        {
            using (ICryptoTransform szyfrator = algorytm.CreateEncryptor())
            {
                Stopwatch stoper = Stopwatch.StartNew();
                szyfrator.TransformFinalBlock(dane, 0, dane.Length);
                stoper.Stop();
                return stoper.Elapsed.TotalSeconds;
            }
        }

        static double MierzPrzepustowosc(SymmetricAlgorithm algorytm, byte[] dane)
        {
            using (ICryptoTransform szyfrator = algorytm.CreateEncryptor())
            {
                Stopwatch stoper = Stopwatch.StartNew();
                long przetworzoneBajty = 0;

                while (stoper.Elapsed.TotalSeconds < 1)
                {
                    szyfrator.TransformFinalBlock(dane, 0, dane.Length);
                    przetworzoneBajty += dane.Length;
                }

                return przetworzoneBajty / stoper.Elapsed.TotalSeconds;
            }
        }

        static double MierzPrzepustowoscHDD(SymmetricAlgorithm algorytm, byte[] dane, string sciezkaPliku)
        {
            using (ICryptoTransform szyfrator = algorytm.CreateEncryptor())
            {
                Stopwatch stoper = Stopwatch.StartNew();
                long przetworzoneBajty = 0;

                using (FileStream fs = new FileStream(sciezkaPliku, FileMode.Create, FileAccess.Write))
                {
                    while (stoper.Elapsed.TotalSeconds < 1)
                    {
                        byte[] zaszyfrowaneDane = szyfrator.TransformFinalBlock(dane, 0, dane.Length);
                        fs.Write(zaszyfrowaneDane, 0, zaszyfrowaneDane.Length);
                        przetworzoneBajty += dane.Length;
                    }
                }

                return przetworzoneBajty / stoper.Elapsed.TotalSeconds;
            }
        }
    }
}
