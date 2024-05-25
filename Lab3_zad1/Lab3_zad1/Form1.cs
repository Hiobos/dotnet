using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;



namespace Lab3_zad1
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorithm;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBoxAlgorithm.Items.AddRange(new string[] { "DES", "AES" });
            comboBoxAlgorithm.SelectedIndex = 0;
        }

        private void ButtonGenerateKeyIV_Click(object sender, EventArgs e)
        {
            switch (comboBoxAlgorithm.SelectedItem.ToString())
            {
                case "DES":
                    algorithm = DES.Create();
                    break;
                case "AES":
                    algorithm = Aes.Create();
                    break;
            }

            algorithm.GenerateKey();
            algorithm.GenerateIV();

            textBoxKey.Text = BitConverter.ToString(algorithm.Key).Replace("-", "");
            textBoxIV.Text = BitConverter.ToString(algorithm.IV).Replace("-", "");
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            byte[] encrypted;
            byte[] plainTextBytes = Encoding.ASCII.GetBytes(textBoxPlainText.Text);

            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
            {
                encrypted = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            }

            textBoxCipherTextASCII.Text = Encoding.ASCII.GetString(encrypted);
            textBoxCipherTextHEX.Text = BitConverter.ToString(encrypted).Replace("-", "");
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            byte[] cipherTextBytes = ConvertHexStringToByteArray(textBoxCipherTextHEX.Text);
            byte[] decrypted;

            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
            {
                decrypted = decryptor.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);
            }

            textBoxPlainTextASCII.Text = Encoding.ASCII.GetString(decrypted);
            textBoxPlainTextHEX.Text = BitConverter.ToString(decrypted).Replace("-", "");
        }

        private void ButtonGetEncryptTime_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ButtonEncrypt_Click(sender, e);
            stopwatch.Stop();
            labelEncryptTime.Text = $"Time: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void ButtonGetDecryptTime_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ButtonDecrypt_Click(sender, e);
            stopwatch.Stop();
            labelDecryptTime.Text = $"Time: {stopwatch.ElapsedMilliseconds} ms";
        }

        private byte[] ConvertHexStringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
