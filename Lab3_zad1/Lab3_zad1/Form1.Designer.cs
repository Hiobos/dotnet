namespace Lab3_zad1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            comboBoxAlgorithm = new ComboBox();
            textBoxKey = new TextBox();
            textBoxIV = new TextBox();
            textBoxPlainText = new TextBox();
            textBoxCipherTextASCII = new TextBox();
            textBoxCipherTextHEX = new TextBox();
            textBoxPlainTextASCII = new TextBox();
            textBoxPlainTextHEX = new TextBox();
            buttonGenerateKeyIV = new Button();
            buttonEncrypt = new Button();
            buttonDecrypt = new Button();
            buttonGetEncryptTime = new Button();
            buttonGetDecryptTime = new Button();
            labelEncryptTime = new Label();
            labelDecryptTime = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // comboBoxAlgorithm
            // 
            comboBoxAlgorithm.FormattingEnabled = true;
            comboBoxAlgorithm.Location = new Point(13, 13);
            comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            comboBoxAlgorithm.Size = new Size(175, 23);
            comboBoxAlgorithm.TabIndex = 0;
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(265, 40);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(275, 23);
            textBoxKey.TabIndex = 1;
            // 
            // textBoxIV
            // 
            textBoxIV.Location = new Point(265, 83);
            textBoxIV.Name = "textBoxIV";
            textBoxIV.Size = new Size(275, 23);
            textBoxIV.TabIndex = 2;
            // 
            // textBoxPlainText
            // 
            textBoxPlainText.Location = new Point(265, 131);
            textBoxPlainText.Name = "textBoxPlainText";
            textBoxPlainText.Size = new Size(275, 23);
            textBoxPlainText.TabIndex = 3;
            // 
            // textBoxCipherTextASCII
            // 
            textBoxCipherTextASCII.Location = new Point(265, 178);
            textBoxCipherTextASCII.Name = "textBoxCipherTextASCII";
            textBoxCipherTextASCII.Size = new Size(275, 23);
            textBoxCipherTextASCII.TabIndex = 4;
            // 
            // textBoxCipherTextHEX
            // 
            textBoxCipherTextHEX.Location = new Point(265, 205);
            textBoxCipherTextHEX.Name = "textBoxCipherTextHEX";
            textBoxCipherTextHEX.Size = new Size(275, 23);
            textBoxCipherTextHEX.TabIndex = 5;
            // 
            // textBoxPlainTextASCII
            // 
            textBoxPlainTextASCII.Location = new Point(265, 318);
            textBoxPlainTextASCII.Name = "textBoxPlainTextASCII";
            textBoxPlainTextASCII.Size = new Size(275, 23);
            textBoxPlainTextASCII.TabIndex = 6;
            // 
            // textBoxPlainTextHEX
            // 
            textBoxPlainTextHEX.Location = new Point(265, 289);
            textBoxPlainTextHEX.Name = "textBoxPlainTextHEX";
            textBoxPlainTextHEX.Size = new Size(275, 23);
            textBoxPlainTextHEX.TabIndex = 7;
            // 
            // buttonGenerateKeyIV
            // 
            buttonGenerateKeyIV.Location = new Point(13, 68);
            buttonGenerateKeyIV.Name = "buttonGenerateKeyIV";
            buttonGenerateKeyIV.Size = new Size(175, 23);
            buttonGenerateKeyIV.TabIndex = 8;
            buttonGenerateKeyIV.Text = "Generate Key and IV";
            buttonGenerateKeyIV.UseVisualStyleBackColor = true;
            buttonGenerateKeyIV.Click += ButtonGenerateKeyIV_Click;
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point(13, 191);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(175, 23);
            buttonEncrypt.TabIndex = 9;
            buttonEncrypt.Text = "Encrypt";
            buttonEncrypt.UseVisualStyleBackColor = true;
            buttonEncrypt.Click += ButtonEncrypt_Click;
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Location = new Point(13, 276);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(175, 23);
            buttonDecrypt.TabIndex = 10;
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += ButtonDecrypt_Click;
            // 
            // buttonGetEncryptTime
            // 
            buttonGetEncryptTime.Location = new Point(13, 350);
            buttonGetEncryptTime.Name = "buttonGetEncryptTime";
            buttonGetEncryptTime.Size = new Size(175, 23);
            buttonGetEncryptTime.TabIndex = 11;
            buttonGetEncryptTime.Text = "Get Encrypt Time";
            buttonGetEncryptTime.UseVisualStyleBackColor = true;
            buttonGetEncryptTime.Click += ButtonGetEncryptTime_Click;
            // 
            // buttonGetDecryptTime
            // 
            buttonGetDecryptTime.Location = new Point(13, 379);
            buttonGetDecryptTime.Name = "buttonGetDecryptTime";
            buttonGetDecryptTime.Size = new Size(175, 23);
            buttonGetDecryptTime.TabIndex = 12;
            buttonGetDecryptTime.Text = "Get Decrypt Time";
            buttonGetDecryptTime.UseVisualStyleBackColor = true;
            buttonGetDecryptTime.Click += ButtonGetDecryptTime_Click;
            // 
            // labelEncryptTime
            // 
            labelEncryptTime.AutoSize = true;
            labelEncryptTime.Location = new Point(265, 350);
            labelEncryptTime.Name = "labelEncryptTime";
            labelEncryptTime.Size = new Size(114, 15);
            labelEncryptTime.TabIndex = 13;
            labelEncryptTime.Text = "Get Encryption Time";
            // 
            // labelDecryptTime
            // 
            labelDecryptTime.AutoSize = true;
            labelDecryptTime.Location = new Point(265, 380);
            labelDecryptTime.Name = "labelDecryptTime";
            labelDecryptTime.Size = new Size(115, 15);
            labelDecryptTime.TabIndex = 14;
            labelDecryptTime.Text = "Get Decryption Time";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 113);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 15;
            label1.Text = "Plain Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(265, 21);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 16;
            label2.Text = "Key";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 68);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 17;
            label3.Text = "IV";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(227, 181);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 18;
            label4.Text = "ASCII";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(233, 213);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 19;
            label5.Text = "HEX";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(233, 321);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 21;
            label6.Text = "HEX";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(224, 292);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 20;
            label7.Text = "ASCII";
            // 
            // Form1
            // 
            ClientSize = new Size(604, 464);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelDecryptTime);
            Controls.Add(labelEncryptTime);
            Controls.Add(buttonGetDecryptTime);
            Controls.Add(buttonGetEncryptTime);
            Controls.Add(buttonDecrypt);
            Controls.Add(buttonEncrypt);
            Controls.Add(buttonGenerateKeyIV);
            Controls.Add(textBoxPlainTextHEX);
            Controls.Add(textBoxPlainTextASCII);
            Controls.Add(textBoxCipherTextHEX);
            Controls.Add(textBoxCipherTextASCII);
            Controls.Add(textBoxPlainText);
            Controls.Add(textBoxIV);
            Controls.Add(textBoxKey);
            Controls.Add(comboBoxAlgorithm);
            Name = "Form1";
            Text = "Symmetric Encryption Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxIV;
        private System.Windows.Forms.TextBox textBoxPlainText;
        private System.Windows.Forms.TextBox textBoxCipherTextASCII;
        private System.Windows.Forms.TextBox textBoxCipherTextHEX;
        private System.Windows.Forms.TextBox textBoxPlainTextASCII;
        private System.Windows.Forms.TextBox textBoxPlainTextHEX;
        private System.Windows.Forms.Button buttonGenerateKeyIV;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Button buttonGetEncryptTime;
        private System.Windows.Forms.Button buttonGetDecryptTime;
        private System.Windows.Forms.Label labelEncryptTime;
        private System.Windows.Forms.Label labelDecryptTime;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
