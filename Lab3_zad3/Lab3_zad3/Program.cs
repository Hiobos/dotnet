using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DESBruteForce
{
    class Program
    {
        static void Main(string[] args)
        {
            string szyfrogramHex = "23c73dde8faedd91413fb5dd1d7e066d70425ed1e058d0e2f7e9e43501824a95446baf28f6ce7ffd3c544f40efb5c80f235de1321214328781a6ea0c0c4c7b74be3968ca1ffb8455";
            byte[] szyfrogram = KonwertujHexNaBajty(szyfrogramHex);
            string znanyPrefix = "test";
            string koncowkaKlucza = "5555";

            var stoper = Stopwatch.StartNew();
            BruteforceDES(szyfrogram, znanyPrefix, koncowkaKlucza);
            stoper.Stop();
            Console.WriteLine($"Czas bruteforce: {stoper.Elapsed.TotalSeconds} s");
        }

        static void BruteforceDES(byte[] szyfrogram, string znanyPrefix, string koncowkaKlucza)
        {
            byte[] bajtyKoncowkaKlucza = Encoding.ASCII.GetBytes(koncowkaKlucza);
            byte[] iv = new byte[8]; // Założenie, że IV jest zerowe dla uproszczenia
            byte[] bajtyTestowe = Encoding.ASCII.GetBytes(znanyPrefix);

            for (int k1 = 0; k1 < 256; k1++)
            {
                for (int k2 = 0; k2 < 256; k2++)
                {
                    byte[] klucz = new byte[8];
                    klucz[0] = (byte)k1;
                    klucz[1] = (byte)k2;
                    klucz[2] = bajtyKoncowkaKlucza[0];
                    klucz[3] = bajtyKoncowkaKlucza[1];
                    klucz[4] = bajtyKoncowkaKlucza[2];
                    klucz[5] = bajtyKoncowkaKlucza[3];
                    klucz[6] = 0;
                    klucz[7] = 0;

                    byte[] odszyfrowane = OdszyfrujDES(szyfrogram, klucz, iv);
                    if (odszyfrowane.Take(4).SequenceEqual(bajtyTestowe))
                    {
                        Console.WriteLine($"Znaleziony klucz: {BitConverter.ToString(klucz).Replace("-", "")}");
                        Console.WriteLine($"Odszyfrowany tekst: {Encoding.ASCII.GetString(odszyfrowane)}");
                        return;
                    }
                }
            }
        }

        static byte[] OdszyfrujDES(byte[] szyfrogram, byte[] klucz, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = klucz;
                des.IV = iv;
                des.Padding = PaddingMode.None;
                des.Mode = CipherMode.ECB;

                using (ICryptoTransform deszyfrator = des.CreateDecryptor())
                {
                    return deszyfrator.TransformFinalBlock(szyfrogram, 0, szyfrogram.Length);
                }
            }
        }

        static byte[] KonwertujHexNaBajty(string hex)
        {
            int liczbaZnakow = hex.Length;
            byte[] bajty = new byte[liczbaZnakow / 2];
            for (int i = 0; i < liczbaZnakow; i += 2)
            {
                bajty[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bajty;
        }
    }
}
