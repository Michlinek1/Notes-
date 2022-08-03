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
    public partial class ReplaceForm : Form
    {
        TxtViewer txtforms = new TxtViewer();
        public ReplaceForm()
        {
            InitializeComponent();
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            var text = TxtViewer.text;
            if (textBox1.Text == "" || textBox1.Text == null || textBox2.Text == "" || textBox2.Text == null)
            {
                MessageBox.Show("Labels cannot be empty!", "Error");
            }
            else if (!text.Contains(textBox1.Text))
            {
                MessageBox.Show("This word doesn't exist in your text!", "Error");
            }
            else
            {
                text = text.Replace(textBox1.Text, textBox2.Text);
                MessageBox.Show(text);
                this.Close();
                txtforms.Show();
                



            }

        }
    }
}
