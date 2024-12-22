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
    public partial class ziyaretform : Form
    {
        public ziyaretform()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user ID=postgres; password=melike04");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            if (idtxt != null || idtxt.Text.Length != 0)
            {
                if (!int.TryParse(idtxt.Text, out int id))
                {
                    MessageBox.Show("Geçersiz id girdiniz..!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NpgsqlCommand komut1 = new NpgsqlCommand("update ziyaretkayitlari set giristarihi=@p1 where ziyaretid=@p2", baglanti);

                baglanti.Open();
                komut1.Parameters.AddWithValue("@p1", int.Parse(giristarihitext.Text));
                komut1.Parameters.AddWithValue("@p2", id);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ziyaretçi güncelleme başarılı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string sorgu = "select * from ziyaretkayitlari order by ziyaretid asc";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Güncellemek istediğiniz ziyaretçinin ziyaret id değerini giriniz..!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from ziyaretkayitlari order by ziyaretid asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
