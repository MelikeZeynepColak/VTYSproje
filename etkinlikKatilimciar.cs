using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYSproje
{
    public partial class etkinlikKatilimciar : Form
    {
        public etkinlikKatilimciar()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from etkinlikkatilimcilari order by katilimciid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kisiidtext.Text) || string.IsNullOrEmpty(etkinlikidtext.Text))
            {
                MessageBox.Show(" Alanlar boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into etkinlikkatilimcilari values (default,@p1,@p2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(etkinlikidtext.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(kisiidtext.Text));

            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Katılımcı ekleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK);

            // Bağlantıyı kapatıyoruz
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
                return;
            }
            string sorgu = "select * from etkinlikkatilimcilari order by katilimciid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            if (idtxt != null || idtxt.Text.Length != 0 || etkinlikidtext != null || kisiidtext != null)
            {
                if (!int.TryParse(idtxt.Text, out int id))
                {
                    MessageBox.Show("Geçersiz id girdiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NpgsqlCommand komut1 = new NpgsqlCommand("update etkinlikbilgileri set  etkinlikid=@p1, kisiid=@p2 where katilimciid=@p3", baglanti);

                baglanti.Open();
                komut1.Parameters.AddWithValue("@p1", int.Parse(etkinlikidtext.Text));
                komut1.Parameters.AddWithValue("@p2", int.Parse(kisiidtext.Text));
                komut1.Parameters.AddWithValue("@p3", id);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Katılımcı güncelleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string sorgu = "select * from etkinlikkatilimcilari order by katilimciid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Güncellemek istediğiniz katılımcının katılımcı id değerini giriniz..!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand(" Delete from etkinlikkatilimcilari where katilimciid=@p1", baglanti);
            if (idtxt != null)
            {
                komut2.Parameters.AddWithValue("@p1", int.Parse(idtxt.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Katılımcı Silindi..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string sorgu = "select * from etkinlikkatilimcilari order by katilimciid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Lütfen geçerli id giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
