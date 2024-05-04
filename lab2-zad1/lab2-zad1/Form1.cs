using System.Drawing.Text;

namespace lab2_zad1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //przycisk oblicz
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text, out double value1) && double.TryParse(textBox1.Text, out double value2))
            {
                //dzielenie
                double result = value1 / value2;
                //podmiana wyniku w textbox3 odpowiedzialnym za wynik
                textBox3.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Wprowadź poprawną wartość");
            }
        }


        //dzielna
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //dzielnik
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //wynik
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
