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
    public partial class abonelikForm : Form
    {
        public abonelikForm()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "select abonelikid,kisiid,sure,ucret(sure) from abonelikbilgileri order by abonelikid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (NpgsqlException sqlEx)
            {
                MessageBox.Show($"SQL Hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idtxt.Text) || string.IsNullOrEmpty(suretext.Text))
                {
                    MessageBox.Show("Abonelik ID ve süre alanları boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(idtxt.Text, out int id))
                {
                    MessageBox.Show("Geçersiz Abonelik ID girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                baglanti.Open();
                NpgsqlCommand komut1 = new NpgsqlCommand("update abonelikbilgileri set sure=@p1 where kisiid=@p2", baglanti);
                komut1.Parameters.AddWithValue("@p1", int.Parse(suretext.Text));
                komut1.Parameters.AddWithValue("@p2", id);
                komut1.ExecuteNonQuery();

                MessageBox.Show("Abonelik bilgisi güncelleme başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi güncelle
                btnlistele_Click(sender, e);
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
