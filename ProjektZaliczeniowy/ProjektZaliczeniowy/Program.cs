using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiThreadedFileEncryption
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30 };
            string filePath = "person.json";
            string encryptedFilePath = "person_encrypted.json";
            string decryptedFilePath = "person_decrypted.json";

            // Serializacja
            string json = Serialize(person);
            Console.WriteLine("Serialized JSON: " + json);

            // Zapis do pliku
            await WriteToFileAsync(filePath, json);

            // Odczyt z pliku
            string readJson = await ReadFromFileAsync(filePath);
            Console.WriteLine("Read JSON from file: " + readJson);

            // Deserializacja
            var deserializedPerson = Deserialize<Person>(readJson);
            Console.WriteLine($"Deserialized Person: {deserializedPerson.FirstName} {deserializedPerson.LastName}, Age {deserializedPerson.Age}");

            // Szyfrowanie
            string encryptedData = Encrypt(json, "password123");
            await WriteToFileAsync(encryptedFilePath, encryptedData);
            Console.WriteLine("Encrypted Data: " + encryptedData);

            // Deszyfrowanie
            string encryptedFileContent = await ReadFromFileAsync(encryptedFilePath);
            string decryptedData = Decrypt(encryptedFileContent, "password123");
            await WriteToFileAsync(decryptedFilePath, decryptedData);
            Console.WriteLine("Decrypted Data: " + decryptedData);
        }

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static async Task WriteToFileAsync(string filePath, string content)
        {
            await File.WriteAllTextAsync(filePath, content);
        }

        public static async Task<string> ReadFromFileAsync(string filePath)
        {
            return await File.ReadAllTextAsync(filePath);
        }

        public static string Encrypt(string plainText, string password)
        {
            byte[] key = Encoding.UTF8.GetBytes(password.PadRight(32));
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length); // Write IV at the beginning of the stream
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string password)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];
            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            byte[] key = Encoding.UTF8.GetBytes(password.PadRight(32));
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
                using (var ms = new MemoryStream(cipher))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
