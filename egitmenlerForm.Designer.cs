namespace VTYSproje
{
    partial class egitmenlerForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.datagrid = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.baslık = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlistele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.datagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.baslık.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VTYSproje.Properties.Resources.previous_icon_icons_com_69318;
            this.pictureBox1.Location = new System.Drawing.Point(729, 449);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // datagrid
            // 
            this.datagrid.Controls.Add(this.dataGridView1);
            this.datagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.datagrid.Location = new System.Drawing.Point(0, 35);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(800, 258);
            this.datagrid.TabIndex = 39;
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
            this.dataGridView1.Size = new System.Drawing.Size(800, 258);
            this.dataGridView1.TabIndex = 2;
            // 
            // baslık
            // 
            this.baslık.Controls.Add(this.label1);
            this.baslık.Dock = System.Windows.Forms.DockStyle.Top;
            this.baslık.Location = new System.Drawing.Point(0, 0);
            this.baslık.Name = "baslık";
            this.baslık.Size = new System.Drawing.Size(800, 35);
            this.baslık.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Egitmen Bilgileri";
            // 
            // btnlistele
            // 
            this.btnlistele.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnlistele.Location = new System.Drawing.Point(0, 308);
            this.btnlistele.Name = "btnlistele";
            this.btnlistele.Size = new System.Drawing.Size(143, 49);
            this.btnlistele.TabIndex = 37;
            this.btnlistele.Text = "Tümünü Listele";
            this.btnlistele.UseVisualStyleBackColor = false;
            this.btnlistele.Click += new System.EventHandler(this.btnlistele_Click);
            // 
            // egitmenlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.btnlistele);
            this.Controls.Add(this.baslık);
            this.Name = "egitmenlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Egitmen Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.datagrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.baslık.ResumeLayout(false);
            this.baslık.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel datagrid;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel baslık;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlistele;
    }
}