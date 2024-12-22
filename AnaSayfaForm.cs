using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYSproje
{
    public partial class AnaSayfaForm : Form
    {
        public AnaSayfaForm()
        {
            InitializeComponent();
        }

        private void tümüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();

        }

        private void eğitmenlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            egitmenlerForm egitmenler = new egitmenlerForm();
            egitmenler.Show();

        }
    }
}
