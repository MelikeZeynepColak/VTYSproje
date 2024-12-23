using Npgsql;
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
    public partial class ekipmanlarKullanim : Form
    {
        public ekipmanlarKullanim()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "select * from ekipmankullanimkayitlari order by kullanimid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Listeleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(kisiidtext.Text) || string.IsNullOrEmpty(ekipmanidtext.Text) || string.IsNullOrEmpty(tarihtxt.Text))
                {
                    MessageBox.Show("Alanlar boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();

                NpgsqlCommand komut1 = new NpgsqlCommand("insert into ekipmankullanimkayitlari values (default,@p1,@p2,@p3)", baglanti);
                komut1.Parameters.AddWithValue("@p1", int.Parse(ekipmanidtext.Text));
                komut1.Parameters.AddWithValue("@p2", int.Parse(kisiidtext.Text));
                komut1.Parameters.AddWithValue("@p3", DateTime.Parse(tarihtxt.Text));

                komut1.ExecuteNonQuery();
                MessageBox.Show("Kayıt ekleme başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException sqlEx)
            {
                // SQL hatalarını yakalar
                MessageBox.Show($"SQL Hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException formatEx)
            {
                // Veri türü hatalarını yakalar
                MessageBox.Show($"Format Hatası: {formatEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Diğer hataları yakalar
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapatma işlemi
                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }

            // Kaydı yenilemek için tekrar listeleme
            try
            {
                string sorgu = "select * from ekipmankullanimkayitlari order by kullanimid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Listeleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
