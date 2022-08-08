using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Timer = System.Windows.Forms.Timer;
using System.Linq;


namespace Notes
{
    public partial class TxtViewer : Form
    {
        Timer timer = new Timer();
        float CurrentSize = 8.5f; 
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\macro.txt";

        public TxtViewer()
        {
            
            InitializeComponent();
            label2.Text = "0";
            timer.Interval = 2000;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }





        }

        private void TxtViewer_Load(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(Form1.plik);
            
            
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            using (StreamWriter sw = new StreamWriter(Form1.plik))
            {
                if (textBox1.Text.StartsWith(".LOG"))
                {
                    sw.WriteLine(textBox1.Text + DateTime.Now.ToString());
                    sw.Close();
                    sw.Dispose();
                }
                else
                {
                    sw.Write(textBox1.Text);
                    sw.Close();
                    sw.Dispose();
                }
            }

            this.Text = "File has been Saved!";



        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save a file";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.ShowDialog();
            while (saveFileDialog.FileName == "")
            {
                MessageBox.Show("Write a name of the file", "Error");
                saveFileDialog.ShowDialog();
                
            }

            using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
            {
                if (textBox1.Text.StartsWith(".LOG"))
                {
                    sw.WriteLine(textBox1.Text + DateTime.Now.ToString());
                    sw.Close();
                    sw.Dispose();
                }
                else
                {
                    sw.Write(textBox1.Text);
                    sw.Close();
                    sw.Dispose();
                }
            }

        }

        private void lenghtOfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Font.Size.ToString());
            if (lenghtOfFileToolStripMenuItem.Checked)
            {
                label1.Visible = false;
                label2.Visible = false;
            }
            else
            {

                label1.Visible = true;
                label2.Visible = true;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text.Length.ToString();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }


        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var convert = int.Parse(labelzoom.Text) - 5;
                labelzoom.Text = convert.ToString();
                textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size + 0.45f);
                CurrentSize += 3f;

            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured!", "Error");
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var convert = int.Parse(labelzoom.Text) + 5;
                labelzoom.Text = convert.ToString();
                textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size - 0.45f);
                CurrentSize -= 3f;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured!", "Error");
            }


        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void customColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = color.Color;
            }
        }

        private void fontColodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = color.Color;
            }
        }

        private void timeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var czas = DateTime.Now;
            textBox1.Text += czas.ToString(); 
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#04293A");
            System.Drawing.Color col2 = System.Drawing.ColorTranslator.FromHtml("#041C32");
            this.BackColor = col;
            textBox1.BackColor = col2;
            textBox1.ForeColor = Color.White;
            menuStrip1.BackColor = col2;
            menuStrip1.ForeColor = Color.White;
            labelzoom.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem1.Checked)
            {
                ;
            }
            
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = font.Font;
            }
        }

        private void autoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(autoSaveToolStripMenuItem.Checked)
                timer.Stop();
                using StreamWriter sw = new StreamWriter(Form1.plik);
                sw.Write(textBox1.Text);
                timer.Start();
            }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


        private void encryptDecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\Users\Michal\Desktop\zadaniainformatyaa\encryptor\main.py"))
            {
                MessageBox.Show("You have to download the encryptor from: https://github.com/Michlinek1/Encryptor-Decryptor", "Error!");
                Process.Start(new ProcessStartInfo("https://github.com/Michlinek1/Encryptor-Decryptor") { UseShellExecute = true });
                return;
            }
            Process.Start(new ProcessStartInfo(@"C:\Users\Michal\Desktop\zadaniainformatyaa\encryptor\main.py") { UseShellExecute = true });
        }

        private void rightToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightToLeftToolStripMenuItem.Checked)
            {
                textBox1.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                textBox1.RightToLeft = RightToLeft.No;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    textBox1.Text += File.ReadLines(path).First().ToString();
                    break;
                case Keys.F2:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(1).ToString();
                    break;
                case Keys.F3:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(2).ToString();
                    break;
                case Keys.F4:

                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(3).ToString();
                    break;
                case Keys.F6:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(4).ToString();
                    break;
                case Keys.F7:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(5).ToString();
                    break;
                case Keys.F8:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(6).ToString();
                    break;
                case Keys.F9:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(7).ToString();
                    break;
                case Keys.F10:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(8).ToString();
                    break;
                case Keys.F11:
                    textBox1.Text += File.ReadLines(path).ElementAtOrDefault(9).ToString();
                    break;
            }
        }

        private void macrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Macros macrosform = new Macros();
            macrosform.Show();
        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelzoom.Text = "100";
            textBox1.Font = new Font(textBox1.Font.Name, 9);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, textBox1.Font, Brushes.Black, 150,125);
        }
    }
    }



     
        

    
    

