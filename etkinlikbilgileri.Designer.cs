namespace VTYSproje
{
    partial class etkinlikbilgileri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.eklebtn = new System.Windows.Forms.Button();
            this.saattext = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.güncellebtn = new System.Windows.Forms.Button();
            this.tarihtext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnlistele = new System.Windows.Forms.Button();
            this.baslık = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.salonid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.etkinlikaditxt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.datagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.baslık.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.BurlyWood;
            this.button2.Location = new System.Drawing.Point(407, 471);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 41);
            this.button2.TabIndex = 106;
            this.button2.Text = "Sil";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // eklebtn
            // 
            this.eklebtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.eklebtn.Location = new System.Drawing.Point(407, 379);
            this.eklebtn.Name = "eklebtn";
            this.eklebtn.Size = new System.Drawing.Size(121, 43);
            this.eklebtn.TabIndex = 105;
            this.eklebtn.Text = "Ekle";
            this.eklebtn.UseVisualStyleBackColor = false;
            this.eklebtn.Click += new System.EventHandler(this.eklebtn_Click);
            // 
            // saattext
            // 
            this.saattext.Location = new System.Drawing.Point(287, 447);
            this.saattext.Name = "saattext";
            this.saattext.Size = new System.Drawing.Size(104, 22);
            this.saattext.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(236, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 101;
            this.label4.Text = "Saat:";
            // 
            // güncellebtn
            // 
            this.güncellebtn.BackColor = System.Drawing.Color.PaleVioletRed;
            this.güncellebtn.Location = new System.Drawing.Point(407, 428);
            this.güncellebtn.Name = "güncellebtn";
            this.güncellebtn.Size = new System.Drawing.Size(121, 41);
            this.güncellebtn.TabIndex = 100;
            this.güncellebtn.Text = "Güncelle";
            this.güncellebtn.UseVisualStyleBackColor = false;
            this.güncellebtn.Click += new System.EventHandler(this.güncellebtn_Click);
            // 
            // tarihtext
            // 
            this.tarihtext.Location = new System.Drawing.Point(287, 416);
            this.tarihtext.Name = "tarihtext";
            this.tarihtext.Size = new System.Drawing.Size(104, 22);
            this.tarihtext.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(236, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 96;
            this.label2.Text = "Tarih:";
            // 
            // datagrid
            // 
            this.datagrid.Controls.Add(this.dataGridView1);
            this.datagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.datagrid.Location = new System.Drawing.Point(0, 35);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(800, 331);
            this.datagrid.TabIndex = 94;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 331);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnlistele
            // 
            this.btnlistele.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnlistele.Location = new System.Drawing.Point(0, 389);
            this.btnlistele.Name = "btnlistele";
            this.btnlistele.Size = new System.Drawing.Size(143, 49);
            this.btnlistele.TabIndex = 92;
            this.btnlistele.Text = "Tümünü Listele";
            this.btnlistele.UseVisualStyleBackColor = false;
            this.btnlistele.Click += new System.EventHandler(this.btnlistele_Click);
            // 
            // baslık
            // 
            this.baslık.Controls.Add(this.label1);
            this.baslık.Dock = System.Windows.Forms.DockStyle.Top;
            this.baslık.Location = new System.Drawing.Point(0, 0);
            this.baslık.Name = "baslık";
            this.baslık.Size = new System.Drawing.Size(800, 35);
            this.baslık.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Etkinlik Bilgileri";
            // 
            // idtxt
            // 
            this.idtxt.Location = new System.Drawing.Point(549, 471);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(104, 22);
            this.idtxt.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(546, 443);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 18);
            this.label6.TabIndex = 107;
            this.label6.Text = "id: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(213, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 103;
            this.label5.Text = "Salon Id:";
            // 
            // salonid
            // 
            this.salonid.Location = new System.Drawing.Point(287, 480);
            this.salonid.Name = "salonid";
            this.salonid.Size = new System.Drawing.Size(104, 22);
            this.salonid.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(197, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 98;
            this.label3.Text = "Etkinlik Adı: ";
            // 
            // etkinlikaditxt
            // 
            this.etkinlikaditxt.Location = new System.Drawing.Point(287, 389);
            this.etkinlikaditxt.Name = "etkinlikaditxt";
            this.etkinlikaditxt.Size = new System.Drawing.Size(104, 22);
            this.etkinlikaditxt.TabIndex = 99;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VTYSproje.Properties.Resources.previous_icon_icons_com_69318;
            this.pictureBox1.Location = new System.Drawing.Point(729, 447);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 95;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // etkinlikbilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.idtxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.eklebtn);
            this.Controls.Add(this.salonid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saattext);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.güncellebtn);
            this.Controls.Add(this.etkinlikaditxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tarihtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.btnlistele);
            this.Controls.Add(this.baslık);
            this.Name = "etkinlikbilgileri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etkinlik Bilgileri";
            this.datagrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.baslık.ResumeLayout(false);
            this.baslık.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button eklebtn;
        private System.Windows.Forms.TextBox saattext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button güncellebtn;
        private System.Windows.Forms.TextBox tarihtext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel datagrid;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnlistele;
        private System.Windows.Forms.Panel baslık;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox salonid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox etkinlikaditxt;
    }
}