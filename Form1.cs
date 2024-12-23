using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VTYSproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int index;
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");
        private void btnlistele_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "select * from kisibilgileri order by kisiid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(adtext.Text) || string.IsNullOrEmpty(soyadtext.Text))
                {
                    MessageBox.Show("Ad ve Soyad alanları boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();
                NpgsqlCommand komut1 = new NpgsqlCommand("insert into kisibilgileri values (nextval('kisibilgileri_kisiid_seq'), @p1, @p2, @p3, @p4, @p5, @p6, @p7)", baglanti);
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
                    return;
                }

                komut1.Parameters.AddWithValue("@p7", kategoritext.Text);
                komut1.ExecuteNonQuery();
                MessageBox.Show("Kişi ekleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK);
                baglanti.Close();

                // Listeleme işlemi sonrası veri güncelleme
                string sorgu = "select * from kisibilgileri order by kisiid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

            try
            {
                if (idtext.Text != null || idtext.Text.Length != 0)
                {
                    if (!int.TryParse(idtext.Text, out int id))
                    {
                        MessageBox.Show("Geçersiz id girdiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    NpgsqlCommand komut1 = new NpgsqlCommand("update kisibilgileri set ad=@p1, soyad=@p2, eposta=@p3, telefon=@p4, adres=@p5, dogumtarihi=@p6, kategori=@p7 where kisiid=@p8", baglanti);

                    baglanti.Open();
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
                        return;
                    }

                    komut1.Parameters.AddWithValue("@p7", kategoritext.Text);
                    komut1.Parameters.AddWithValue("@p8", id);
                    komut1.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kişi güncelleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeleme işlemi sonrası veri güncelleme
                    string sorgu = "select * from kisibilgileri order by kisiid asc";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Güncellemek istediğiniz kişinin id değerini giriniz..!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            
            DataGridViewRow satır = dataGridView1.Rows[index];
           

            idtext.Text = satır.Cells[0].Value.ToString();
            adtext.Text = satır.Cells[1].Value.ToString();
            soyadtext.Text = satır.Cells[2].Value.ToString();
            epostatext.Text = satır.Cells[3].Value.ToString();
            telefontext.Text = satır.Cells[4].Value.ToString();
            adrestext.Text = satır.Cells[5].Value.ToString();
            tarihtext.Text =satır.Cells[6].Value.ToString();
            kategoritext.Text = satır.Cells[7].Value.ToString();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut2 = new NpgsqlCommand("Delete from kisibilgileri where kisiid=@p1", baglanti);
                if (idtext != null)
                {
                    komut2.Parameters.AddWithValue("@p1", int.Parse(idtext.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kişi Silindi..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Listeleme işlemi sonrası veri güncelleme
                    string sorgu = "select * from kisibilgileri order by kisiid asc";
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
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
