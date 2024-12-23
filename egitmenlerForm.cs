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
    public partial class egitmenlerForm : Form
    {
        public egitmenlerForm()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "select * from egitmenbilgileri";
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

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtxt.Text) || string.IsNullOrEmpty(uzmantxt.Text))
            {
                MessageBox.Show("Tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(idtxt.Text, out int id))
            {
                MessageBox.Show("Geçersiz eğitmen ID girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                baglanti.Open();
                string sorgu = "update egitmenbilgileri set uzmanlikalani=@p1 where egitmenid=@p2";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", uzmantxt.Text);
                    komut.Parameters.AddWithValue("@p2", id);
                    komut.ExecuteNonQuery();
                }

                MessageBox.Show("Eğitmen bilgisi güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi yenile
                btnlistele_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
