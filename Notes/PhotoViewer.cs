using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
    public partial class PhotoViewer : Form
    {
        public PhotoViewer()
        {
            InitializeComponent();

        }
        private void PhotoViewer_load(object sender, PrintPageEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Form1.plik);
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
