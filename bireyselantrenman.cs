using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
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
            try
            {
                string sorgu = "select * from bireyselantrenmanbilgileri order by antrenmanid asc";
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

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtxt.Text) || string.IsNullOrEmpty(tarihtext.Text) || string.IsNullOrEmpty(saattext.Text) || string.IsNullOrEmpty(egitmenid.Text))
            {
                MessageBox.Show("Tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(idtxt.Text, out int id))
            {
                MessageBox.Show("Geçersiz ID girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                baglanti.Open();
                string sorgu = "update bireyselantrenmanbilgileri set tarih=@p1, saat=@p2, egitmenid=@p3 where antrenmanid=@p4";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", DateTime.Parse(tarihtext.Text));
                    komut.Parameters.AddWithValue("@p2", DateTime.Parse(saattext.Text));
                    komut.Parameters.AddWithValue("@p3", int.Parse(egitmenid.Text));
                    komut.Parameters.AddWithValue("@p4", id);
                    komut.ExecuteNonQuery();
                }

                MessageBox.Show("Antrenman güncelleme başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi yenile
                btnlistele_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtxt.Text) || string.IsNullOrEmpty(tarihtext.Text) || string.IsNullOrEmpty(saattext.Text) || string.IsNullOrEmpty(egitmenid.Text))
            {
                MessageBox.Show("Tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                baglanti.Open();
                string sorgu = "insert into bireyselantrenmanbilgileri values (default, @p1, @p2, @p3, @p4)";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", int.Parse(idtxt.Text));
                    komut.Parameters.AddWithValue("@p2", int.Parse(egitmenid.Text));
                    komut.Parameters.AddWithValue("@p4", DateTime.Parse(saattext.Text));

                    string format = "yyyy-MM-dd";
                    if (DateTime.TryParseExact(tarihtext.Text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        komut.Parameters.AddWithValue("@p3", parsedDate);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz tarih formatı! Lütfen 'yyyy-MM-dd' formatında girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    komut.ExecuteNonQuery();
                }

                MessageBox.Show("Antrenman ekleme başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi yenile
                btnlistele_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtxt.Text))
            {
                MessageBox.Show("Geçerli bir ID girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(idtxt.Text, out int id))
            {
                MessageBox.Show("Geçersiz ID formatı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                baglanti.Open();
                string sorgu = "delete from bireyselantrenmanbilgileri where antrenmanid=@p1";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", id);
                    komut.ExecuteNonQuery();
                }

                MessageBox.Show("Kayıt silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Listeyi yenile
                btnlistele_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }

        }
    }
}
