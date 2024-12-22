namespace VTYSproje
{
    partial class ziyaretform
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
            this.güncellebtn = new System.Windows.Forms.Button();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.giristarihitext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.datagrid = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnlistele = new System.Windows.Forms.Button();
            this.baslık = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.datagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.baslık.SuspendLayout();
            this.SuspendLayout();
            // 
            // güncellebtn
            // 
            this.güncellebtn.BackColor = System.Drawing.Color.PaleVioletRed;
            this.güncellebtn.Location = new System.Drawing.Point(398, 393);
            this.güncellebtn.Name = "güncellebtn";
            this.güncellebtn.Size = new System.Drawing.Size(121, 53);
            this.güncellebtn.TabIndex = 76;
            this.güncellebtn.Text = "Güncelle";
            this.güncellebtn.UseVisualStyleBackColor = false;
            this.güncellebtn.Click += new System.EventHandler(this.güncellebtn_Click);
            // 
            // idtxt
            // 
            this.idtxt.Location = new System.Drawing.Point(288, 395);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(104, 22);
            this.idtxt.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(255, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 18);
            this.label3.TabIndex = 74;
            this.label3.Text = "id: ";
            // 
            // giristarihitext
            // 
            this.giristarihitext.Location = new System.Drawing.Point(288, 422);
            this.giristarihitext.Name = "giristarihitext";
            this.giristarihitext.Size = new System.Drawing.Size(104, 22);
            this.giristarihitext.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(199, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "Giriş Tarihi:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VTYSproje.Properties.Resources.previous_icon_icons_com_69318;
            this.pictureBox1.Location = new System.Drawing.Point(729, 453);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // datagrid
            // 
            this.datagrid.Controls.Add(this.dataGridView1);
            this.datagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.datagrid.Location = new System.Drawing.Point(0, 35);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(800, 331);
            this.datagrid.TabIndex = 70;
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
            this.btnlistele.Location = new System.Drawing.Point(0, 393);
            this.btnlistele.Name = "btnlistele";
            this.btnlistele.Size = new System.Drawing.Size(143, 49);
            this.btnlistele.TabIndex = 68;
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
            this.baslık.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ziyaretçi Kayıtları";
            // 
            // ziyaretform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.güncellebtn);
            this.Controls.Add(this.idtxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.giristarihitext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.btnlistele);
            this.Controls.Add(this.baslık);
            this.Name = "ziyaretform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ziyaret Kayıtları";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.datagrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.baslık.ResumeLayout(false);
            this.baslık.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button güncellebtn;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox giristarihitext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel datagrid;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnlistele;
        private System.Windows.Forms.Panel baslık;
        private System.Windows.Forms.Label label1;
    }
}