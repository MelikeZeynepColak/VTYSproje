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
    public partial class ekipmanbilgileri : Form
    {
        public ekipmanbilgileri()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "select * from ekipmanbilgileri order by ekipmanid asc";
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

        private void eklebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(miktartext.Text) || string.IsNullOrEmpty(ekipmanaditext.Text))
                {
                    MessageBox.Show("Alanlar boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();
                NpgsqlCommand komut1 = new NpgsqlCommand("insert into ekipmanbilgileri values (default,@p1,@p2)", baglanti);
                komut1.Parameters.AddWithValue("@p1", ekipmanaditext.Text);
                komut1.Parameters.AddWithValue("@p2", int.Parse(miktartext.Text));
                komut1.ExecuteNonQuery();

                MessageBox.Show("Kayıt ekleme başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnlistele_Click(sender, e); // Listeyi güncelle
            }
            catch (NpgsqlException sqlEx)
            {
                MessageBox.Show($"SQL Hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (string.IsNullOrEmpty(idtxt.Text) || string.IsNullOrEmpty(ekipmanaditext.Text) || string.IsNullOrEmpty(miktartext.Text))
                {
                    MessageBox.Show("Güncellemek istediğiniz tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(idtxt.Text, out int id))
                {
                    MessageBox.Show("Geçersiz id girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();
                NpgsqlCommand komut1 = new NpgsqlCommand("update ekipmanbilgileri set ekipmanadi=@p1, miktar=@p2 where ekipmanid=@p3", baglanti);
                komut1.Parameters.AddWithValue("@p1", ekipmanaditext.Text);
                komut1.Parameters.AddWithValue("@p2", int.Parse(miktartext.Text));
                komut1.Parameters.AddWithValue("@p3", id);
                komut1.ExecuteNonQuery();

                MessageBox.Show("Kayıt güncelleme başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnlistele_Click(sender, e); // Listeyi güncelle
            }
            catch (NpgsqlException sqlEx)
            {
                MessageBox.Show($"SQL Hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idtxt.Text))
                {
                    MessageBox.Show("Silmek istediğiniz ekipmanın ID'sini giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(idtxt.Text, out int id))
                {
                    MessageBox.Show("Geçersiz ID girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();
                NpgsqlCommand komut2 = new NpgsqlCommand("DELETE FROM ekipmanbilgileri WHERE ekipmanid=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", id);
                komut2.ExecuteNonQuery();

                MessageBox.Show("Kayıt silme işlemi başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnlistele_Click(sender, e); // Listeyi güncelle
            }
            catch (NpgsqlException sqlEx)
            {
                MessageBox.Show($"SQL Hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
