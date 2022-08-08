using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
    public partial class Macros : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\macro.txt";

        public Macros()
        {
            InitializeComponent();
            textBox1.Text = File.ReadLines(path).ElementAtOrDefault(0);
            textBox2.Text = File.ReadLines(path).ElementAtOrDefault(1);
            textBox3.Text = File.ReadLines(path).ElementAtOrDefault(2);
            textBox4.Text = File.ReadLines(path).ElementAtOrDefault(3);
            textBox5.Text = File.ReadLines(path).ElementAtOrDefault(4);
            textBox6.Text = File.ReadLines(path).ElementAtOrDefault(5);
            textBox7.Text = File.ReadLines(path).ElementAtOrDefault(6);
            textBox8.Text = File.ReadLines(path).ElementAtOrDefault(7);
            textBox9.Text = File.ReadLines(path).ElementAtOrDefault(8);
            textBox10.Text = File.ReadLines(path).ElementAtOrDefault(9);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text)
                || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) ||
                string.IsNullOrEmpty(textBox9.Text)
                || string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Macro cannot be empty", "Error");
                return;
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(textBox1.Text + "\n" + textBox2.Text + "\n"
                + textBox3.Text + "\n" + textBox4.Text + "\n" 
                + textBox5.Text + "\n" + textBox6.Text + "\n" 
                + textBox7.Text + "\n" + textBox8.Text + "\n" 
                + textBox9.Text + "\n" + textBox10.Text + "\n" );

            }

            MessageBox.Show("Succesfully saved!", "Success");
        }
    }
}
