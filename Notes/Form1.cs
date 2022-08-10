using System.Diagnostics;
using System.Threading;

namespace Notes
{
    public partial class Form1 : Form
    {
        public static string plik = "";
        public static string NazwaPliku = "";
        Thread th;

        public Form1()
        {

            InitializeComponent();
            

            label1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a file";
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //otwiera Moje Dokumenty
            ofd.Multiselect = false;
            ofd.ShowDialog();
            while (ofd.FileName == "")
            {
                MessageBox.Show("Select a file!", "Error");
                ofd.ShowDialog();
            }

            label1.Visible = true;
            
            label1.Text = ofd.FileName;
            FileInfo fi = new FileInfo(ofd.FileName);
            PhotoViewer photoViewer = new PhotoViewer();
            plik = ofd.FileName;
            NazwaPliku = ofd.SafeFileName;
            switch (fi.Extension)
            {
                case ".txt":
                    this.Close();
                    th = new Thread(OpenTxt);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                    break;

                case ".png":
                    this.Hide();
                    photoViewer.Show();
                    break;
                    

                    

            }

        }

        private void OpenTxt(object obj)
        {
            Application.Run(new TxtViewer());
        }

    }

    }





        


