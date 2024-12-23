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
    public partial class grupDersleriForm : Form
    {
        public grupDersleriForm()
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
            string sorgu = "select * from grupdersibilgileri order by grupdersiid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tarihtext.Text) || string.IsNullOrEmpty(saattext.Text) || string.IsNullOrEmpty(egitmenid.Text) || string.IsNullOrEmpty(dersaditxt.Text))
            {
                MessageBox.Show("Ad ve Soyad alanları boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into grupdersibilgileri values (default,@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", dersaditxt.Text);
            komut1.Parameters.AddWithValue("@p2", int.Parse(egitmenid.Text));

            komut1.Parameters.AddWithValue("@p4", DateTime.Parse(saattext.Text));

            string format = "yyyy-MM-dd"; // Beklenen tarih formatı
            if (DateTime.TryParseExact(tarihtext.Text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                komut1.Parameters.AddWithValue("@p3", parsedDate); // Geçerli tarih
            }
            else
            {
                MessageBox.Show("Geçersiz tarih formatı! Lütfen 'yyyy-MM-dd' formatında bir tarih girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hata durumunda işlemi iptal ediyoruz
            }


            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Grup dersi ekleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK);

            // Bağlantıyı kapatıyoruz
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
                return;
            }
            string sorgu = "select * from grupdersibilgileri order by grupdersiid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand(" Delete from grupdersibilgileri where grupdersiid=@p1", baglanti);
            if (idtxt != null)
            {
                komut2.Parameters.AddWithValue("@p1", int.Parse(idtxt.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Silindi..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string sorgu = "select * from grupdersibilgileri order by grupdersiid asc";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (idtxt != null || idtxt.Text.Length != 0 || tarihtext != null || saattext != null || egitmenid != null|| string.IsNullOrEmpty(dersaditxt.Text))
            {
                if (!int.TryParse(idtxt.Text, out int id))
                {
                    MessageBox.Show("Geçersiz id girdiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NpgsqlCommand komut1 = new NpgsqlCommand("update grupdersibilgileri set dersadi=@p5, tarih=@p1, saat=@p2,egitmenid=@p3 where grupdersiid=@p4", baglanti);

                baglanti.Open();
                komut1.Parameters.AddWithValue("@p1", DateTime.Parse(tarihtext.Text));
                komut1.Parameters.AddWithValue("@p2", DateTime.Parse(saattext.Text));
                komut1.Parameters.AddWithValue("@p3", int.Parse(egitmenid.Text));
                komut1.Parameters.AddWithValue("@p5", dersaditxt.Text);
                komut1.Parameters.AddWithValue("@p4", id);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Grup dersi güncelleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string sorgu = "select * from grupdersibilgileri order by grupdersiid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Güncellemek istediğiniz dersin ders id değerini giriniz..!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
