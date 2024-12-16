namespace VTYSproje
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnlistele = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.baslık = new System.Windows.Forms.Panel();
            this.datagrid = new System.Windows.Forms.Panel();
            this.ekle = new System.Windows.Forms.Button();
            this.epostatext = new System.Windows.Forms.TextBox();
            this.tarihtext = new System.Windows.Forms.MaskedTextBox();
            this.telefontext = new System.Windows.Forms.MaskedTextBox();
            this.kategoritext = new System.Windows.Forms.ComboBox();
            this.adrestext = new System.Windows.Forms.TextBox();
            this.soyadtext = new System.Windows.Forms.TextBox();
            this.adtext = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.baslık.SuspendLayout();
            this.datagrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnlistele
            // 
            this.btnlistele.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnlistele.Location = new System.Drawing.Point(645, 311);
            this.btnlistele.Name = "btnlistele";
            this.btnlistele.Size = new System.Drawing.Size(143, 49);
            this.btnlistele.TabIndex = 1;
            this.btnlistele.Text = "Tümünü Listele";
            this.btnlistele.UseVisualStyleBackColor = false;
            this.btnlistele.Click += new System.EventHandler(this.btnlistele_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 258);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kişi Bilgileri";
            // 
            // baslık
            // 
            this.baslık.Controls.Add(this.label1);
            this.baslık.Dock = System.Windows.Forms.DockStyle.Top;
            this.baslık.Location = new System.Drawing.Point(0, 0);
            this.baslık.Name = "baslık";
            this.baslık.Size = new System.Drawing.Size(800, 35);
            this.baslık.TabIndex = 4;
            // 
            // datagrid
            // 
            this.datagrid.Controls.Add(this.dataGridView1);
            this.datagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.datagrid.Location = new System.Drawing.Point(0, 35);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(800, 258);
            this.datagrid.TabIndex = 5;
            // 
            // ekle
            // 
            this.ekle.BackColor = System.Drawing.Color.MistyRose;
            this.ekle.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ekle.Location = new System.Drawing.Point(262, 308);
            this.ekle.Name = "ekle";
            this.ekle.Size = new System.Drawing.Size(131, 49);
            this.ekle.TabIndex = 6;
            this.ekle.Text = "ekle";
            this.ekle.UseVisualStyleBackColor = false;
            this.ekle.Click += new System.EventHandler(this.ekle_Click);
            // 
            // epostatext
            // 
            this.epostatext.Location = new System.Drawing.Point(115, 363);
            this.epostatext.Name = "epostatext";
            this.epostatext.Size = new System.Drawing.Size(121, 22);
            this.epostatext.TabIndex = 32;
            // 
            // tarihtext
            // 
            this.tarihtext.Location = new System.Drawing.Point(115, 447);
            this.tarihtext.Mask = "0000-00-00";
            this.tarihtext.Name = "tarihtext";
            this.tarihtext.Size = new System.Drawing.Size(121, 22);
            this.tarihtext.TabIndex = 31;
            this.tarihtext.ValidatingType = typeof(System.DateTime);
            // 
            // telefontext
            // 
            this.telefontext.Location = new System.Drawing.Point(115, 391);
            this.telefontext.Mask = "000-0000";
            this.telefontext.Name = "telefontext";
            this.telefontext.Size = new System.Drawing.Size(121, 22);
            this.telefontext.TabIndex = 30;
            // 
            // kategoritext
            // 
            this.kategoritext.FormattingEnabled = true;
            this.kategoritext.Items.AddRange(new object[] {
            "üye",
            "abone",
            "eğitmen"});
            this.kategoritext.Location = new System.Drawing.Point(115, 475);
            this.kategoritext.Name = "kategoritext";
            this.kategoritext.Size = new System.Drawing.Size(121, 24);
            this.kategoritext.TabIndex = 29;
            // 
            // adrestext
            // 
            this.adrestext.Location = new System.Drawing.Point(115, 419);
            this.adrestext.Name = "adrestext";
            this.adrestext.Size = new System.Drawing.Size(121, 22);
            this.adrestext.TabIndex = 28;
            // 
            // soyadtext
            // 
            this.soyadtext.Location = new System.Drawing.Point(115, 335);
            this.soyadtext.Name = "soyadtext";
            this.soyadtext.Size = new System.Drawing.Size(121, 22);
            this.soyadtext.TabIndex = 27;
            // 
            // adtext
            // 
            this.adtext.Location = new System.Drawing.Point(115, 306);
            this.adtext.Name = "adtext";
            this.adtext.Size = new System.Drawing.Size(121, 22);
            this.adtext.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(21, 477);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 25;
            this.label7.Text = "kategori:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(21, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 18);
            this.label6.TabIndex = 24;
            this.label6.Text = "doğum tarihi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(21, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "telefon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(21, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "eposta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(21, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "adres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(21, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "soyad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(21, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "ad:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.epostatext);
            this.Controls.Add(this.tarihtext);
            this.Controls.Add(this.telefontext);
            this.Controls.Add(this.kategoritext);
            this.Controls.Add(this.adrestext);
            this.Controls.Add(this.soyadtext);
            this.Controls.Add(this.adtext);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ekle);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.btnlistele);
            this.Controls.Add(this.baslık);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spor Salonu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.baslık.ResumeLayout(false);
            this.baslık.PerformLayout();
            this.datagrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnlistele;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel baslık;
        private System.Windows.Forms.Panel datagrid;
        private System.Windows.Forms.Button ekle;
        private System.Windows.Forms.TextBox epostatext;
        private System.Windows.Forms.MaskedTextBox tarihtext;
        private System.Windows.Forms.MaskedTextBox telefontext;
        private System.Windows.Forms.ComboBox kategoritext;
        private System.Windows.Forms.TextBox adrestext;
        private System.Windows.Forms.TextBox soyadtext;
        private System.Windows.Forms.TextBox adtext;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
    }
}

