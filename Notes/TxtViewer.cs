using System;
using System.IO;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace Notes
{
    public partial class TxtViewer : Form
    {
        Timer timer = new Timer();
        float CurrentSize = 8.5f;
        public static string text = "";

        public TxtViewer()
        {
            
            InitializeComponent();
            label2.Text = "0";
            timer.Interval = 2000;
            textBox1.Text = text;




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
                sw.Write(textBox1.Text);
                sw.Close();
                sw.Dispose();
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
                sw.Write(textBox1.Text);
                sw.Close();
                sw.Dispose();
            }

        }

        private void lenghtOfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size + 3f);
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
                textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size - 3f);
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

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceForm replaceform = new ReplaceForm();
            text = textBox1.Text;
            replaceform.Show();
            this.Close();
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text);
        }
    }
    }



     
        

    
    

