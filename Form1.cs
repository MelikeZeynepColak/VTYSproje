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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");
        private void btnlistele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kisibilgileri order by kisiid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
            
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into kisibilgileri values (nextval('kisibilgileri_kisiid_seq'),@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut1.Parameters.AddWithValue("@p1", adtext.Text);
            komut1.Parameters.AddWithValue("@p2", soyadtext.Text);
            komut1.Parameters.AddWithValue("@p3", epostatext.Text);
            komut1.Parameters.AddWithValue("@p4", telefontext.Text);
            komut1.Parameters.AddWithValue("@p5", adrestext.Text);
            string format = "yyyy-MM-dd"; // Beklenen tarih formatı
            if (DateTime.TryParseExact(tarihtext.Text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                komut1.Parameters.AddWithValue("@p6", parsedDate); // Geçerli tarih
            }
            else
            {
                MessageBox.Show("Geçersiz tarih formatı! Lütfen 'yyyy-MM-dd' formatında bir tarih girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hata durumunda işlemi iptal ediyoruz
            }

            komut1.Parameters.AddWithValue("@p7", kategoritext.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi ekleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK);

                // Bağlantıyı kapatıyoruz
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
                return;
            }
            string sorgu = "select * from kisibilgileri order by kisiid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

    }
}
