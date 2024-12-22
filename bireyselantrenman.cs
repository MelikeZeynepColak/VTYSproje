using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYSproje
{
    public partial class bireyselantrenman : Form
    {
        public bireyselantrenman()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from bireyselantrenmanbilgileri order by antrenmanid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            if (idtxt != null || idtxt.Text.Length != 0 || tarihtext!=null||saattext!=null||egitmenid!=null)
            {
                if (!int.TryParse(idtxt.Text, out int id))
                {
                    MessageBox.Show("Geçersiz id girdiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NpgsqlCommand komut1 = new NpgsqlCommand("update bireyselantrenmanbilgileri set tarih=@p1, saat=@p2,egitmenid=@p3 where antrenmanid=@p4", baglanti);

                baglanti.Open();
                komut1.Parameters.AddWithValue("@p1", DateTime.Parse(tarihtext.Text));
                komut1.Parameters.AddWithValue("@p2", DateTime.Parse(saattext.Text));
                komut1.Parameters.AddWithValue("@p3", int.Parse(egitmenid.Text));
                komut1.Parameters.AddWithValue("@p4", id);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Antrenman güncelleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string sorgu = "select * from bireyselantrenmanbilgileri order by antrenmanid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Güncellemek istediğiniz antrenmanın antrenman id değerini giriniz..!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
