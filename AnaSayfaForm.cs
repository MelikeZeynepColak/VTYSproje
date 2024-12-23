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

        private void abonelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abonelikForm aboneler = new abonelikForm();
            aboneler.Show();
        }

        private void beslenmeProgramlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beslenmeprogramForm program = new beslenmeprogramForm();
            program.Show();
        }

        private void bireyselAntrenmanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bireyselantrenman bireyselantrenman = new bireyselantrenman();
            bireyselantrenman.Show();
        }

        private void grupDersleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grupDersleriForm grupDersleri = new grupDersleriForm();
            grupDersleri.Show();
        }

        private void etkinlikBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etkinlikbilgileri etkinlikbilgileri = new etkinlikbilgileri();
            etkinlikbilgileri.Show();
        }

        private void katılımcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etkinlikKatilimciar etkinlikKatilimciar = new etkinlikKatilimciar();
            etkinlikKatilimciar.Show();
        }
        private void ödemeBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odemeBilgileri odemeBilgileri = new odemeBilgileri();
            odemeBilgileri.Show();
        }

        private void şikayetVeÖnerilerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ekipmanBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ekipmanbilgileri ekipmanbilgileri = new ekipmanbilgileri();
            ekipmanbilgileri.Show();
        }

        private void kullanımKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ekipmanlarKullanim ekipmanlar = new ekipmanlarKullanim();
            ekipmanlar.Show();
        }

        private void ziyaretçilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ziyaretform ziyaret = new ziyaretform();
            ziyaret.Show();
        }
    }
}
