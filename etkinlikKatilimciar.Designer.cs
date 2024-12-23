namespace VTYSproje
{
    partial class etkinlikKatilimciar
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
            this.idtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.eklebtn = new System.Windows.Forms.Button();
            this.güncellebtn = new System.Windows.Forms.Button();
            this.etkinlikidtext = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kisiidtext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnlistele = new System.Windows.Forms.Button();
            this.baslık = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.datagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.baslık.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // idtxt
            // 
            this.idtxt.Location = new System.Drawing.Point(551, 460);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(104, 22);
            this.idtxt.TabIndex = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(548, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 18);
            this.label6.TabIndex = 124;
            this.label6.Text = "id: ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.BurlyWood;
            this.button2.Location = new System.Drawing.Point(407, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 41);
            this.button2.TabIndex = 123;
            this.button2.Text = "Sil";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // eklebtn
            // 
            this.eklebtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.eklebtn.Location = new System.Drawing.Point(407, 380);
            this.eklebtn.Name = "eklebtn";
            this.eklebtn.Size = new System.Drawing.Size(121, 43);
            this.eklebtn.TabIndex = 122;
            this.eklebtn.Text = "Ekle";
            this.eklebtn.UseVisualStyleBackColor = false;
            this.eklebtn.Click += new System.EventHandler(this.eklebtn_Click);
            // 
            // güncellebtn
            // 
            this.güncellebtn.BackColor = System.Drawing.Color.PaleVioletRed;
            this.güncellebtn.Location = new System.Drawing.Point(407, 429);
            this.güncellebtn.Name = "güncellebtn";
            this.güncellebtn.Size = new System.Drawing.Size(121, 41);
            this.güncellebtn.TabIndex = 117;
            this.güncellebtn.Text = "Güncelle";
            this.güncellebtn.UseVisualStyleBackColor = false;
            this.güncellebtn.Click += new System.EventHandler(this.güncellebtn_Click);
            // 
            // etkinlikidtext
            // 
            this.etkinlikidtext.Location = new System.Drawing.Point(287, 390);
            this.etkinlikidtext.Name = "etkinlikidtext";
            this.etkinlikidtext.Size = new System.Drawing.Size(104, 22);
            this.etkinlikidtext.TabIndex = 116;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(209, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 115;
            this.label3.Text = "Etkinlik Id: ";
            // 
            // kisiidtext
            // 
            this.kisiidtext.Location = new System.Drawing.Point(287, 417);
            this.kisiidtext.Name = "kisiidtext";
            this.kisiidtext.Size = new System.Drawing.Size(104, 22);
            this.kisiidtext.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(230, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 113;
            this.label2.Text = "Kişi id:";
            // 
            // datagrid
            // 
            this.datagrid.Controls.Add(this.dataGridView1);
            this.datagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.datagrid.Location = new System.Drawing.Point(0, 35);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(800, 331);
            this.datagrid.TabIndex = 111;
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
            this.btnlistele.Location = new System.Drawing.Point(0, 390);
            this.btnlistele.Name = "btnlistele";
            this.btnlistele.Size = new System.Drawing.Size(143, 49);
            this.btnlistele.TabIndex = 109;
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
            this.baslık.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Katılımcılar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VTYSproje.Properties.Resources.previous_icon_icons_com_69318;
            this.pictureBox1.Location = new System.Drawing.Point(729, 448);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // etkinlikKatilimciar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.idtxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.eklebtn);
            this.Controls.Add(this.güncellebtn);
            this.Controls.Add(this.etkinlikidtext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kisiidtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.btnlistele);
            this.Controls.Add(this.baslık);
            this.Name = "etkinlikKatilimciar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etkinlik Katılımcı Bilgileri";
            this.datagrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.baslık.ResumeLayout(false);
            this.baslık.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button eklebtn;
        private System.Windows.Forms.Button güncellebtn;
        private System.Windows.Forms.TextBox etkinlikidtext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox kisiidtext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel datagrid;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnlistele;
        private System.Windows.Forms.Panel baslık;
        private System.Windows.Forms.Label label1;
    }
}