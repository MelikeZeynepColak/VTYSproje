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
    public partial class etkinlikbilgileri : Form
    {
        public etkinlikbilgileri()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "select * from etkinlikbilgileri order by etkinlikid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Listeleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(etkinlikaditxt.Text) || string.IsNullOrEmpty(tarihtext.Text) || string.IsNullOrEmpty(saattext.Text) || string.IsNullOrEmpty(salonid.Text))
            {
                MessageBox.Show("Tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                baglanti.Open();
                string sorgu = "insert into etkinlikbilgileri (etkinlikadi, tarih, saat, salonid) values (@p1, @p2, @p3, @p4)";
                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", etkinlikaditxt.Text);

                    if (DateTime.TryParseExact(tarihtext.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        komut.Parameters.AddWithValue("@p2", parsedDate);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz tarih formatı! Lütfen 'yyyy-MM-dd' formatında girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TimeSpan.TryParse(saattext.Text, out TimeSpan parsedTime))
                    {
                        komut.Parameters.AddWithValue("@p3", parsedTime);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz saat formatı! Lütfen 'HH:mm:ss' formatında girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    komut.Parameters.AddWithValue("@p4", int.Parse(salonid.Text));

                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Etkinlik başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnlistele.PerformClick();  // Listeyi güncellemek için butona tıklıyoruz
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ekleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtxt.Text) || string.IsNullOrEmpty(etkinlikaditxt.Text) || string.IsNullOrEmpty(tarihtext.Text) || string.IsNullOrEmpty(saattext.Text) || string.IsNullOrEmpty(salonid.Text))
            {
                MessageBox.Show("Tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!int.TryParse(idtxt.Text, out int etkinlikId))
                {
                    MessageBox.Show("Geçersiz etkinlik ID girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();
                string sorgu = "update etkinlikbilgileri set etkinlikadi=@p1, tarih=@p2, saat=@p3, salonid=@p4 where etkinlikid=@p5";
                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", etkinlikaditxt.Text);

                    if (DateTime.TryParseExact(tarihtext.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        komut.Parameters.AddWithValue("@p2", parsedDate);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz tarih formatı! Lütfen 'yyyy-MM-dd' formatında girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TimeSpan.TryParse(saattext.Text, out TimeSpan parsedTime))
                    {
                        komut.Parameters.AddWithValue("@p3", parsedTime);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz saat formatı! Lütfen 'HH:mm:ss' formatında girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    komut.Parameters.AddWithValue("@p4", int.Parse(salonid.Text));
                    komut.Parameters.AddWithValue("@p5", etkinlikId);

                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Etkinlik başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnlistele.PerformClick();  // Listeyi güncellemek için butona tıklıyoruz
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Silmek istediğiniz etkinliğin ID'sini giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!int.TryParse(idtxt.Text, out int etkinlikId))
                {
                    MessageBox.Show("Geçersiz etkinlik ID girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();
                string sorgu = "delete from etkinlikbilgileri where etkinlikid=@p1";
                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", etkinlikId);
                    komut.ExecuteNonQuery();
                }
                MessageBox.Show("Etkinlik başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnlistele.PerformClick();  // Listeyi güncellemek için butona tıklıyoruz
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
