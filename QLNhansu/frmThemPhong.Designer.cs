namespace QLNhaTro
{
    partial class frmThemPhong
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dgvThemPhong = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Phòng";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(619, 42);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(105, 51);
            this.btnTim.TabIndex = 12;
            this.btnTim.Text = "Lọc";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(238, 55);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(319, 24);
            this.txtTimKiem.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tìm Kiếm";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::QLNhaTro.Properties.Resources.sot123;
            this.pictureBox5.Location = new System.Drawing.Point(574, 42);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(49, 51);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // dgvThemPhong
            // 
            this.dgvThemPhong.AllowUserToAddRows = false;
            this.dgvThemPhong.AllowUserToDeleteRows = false;
            this.dgvThemPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThemPhong.Location = new System.Drawing.Point(33, 127);
            this.dgvThemPhong.Name = "dgvThemPhong";
            this.dgvThemPhong.ReadOnly = true;
            this.dgvThemPhong.RowHeadersWidth = 51;
            this.dgvThemPhong.RowTemplate.Height = 24;
            this.dgvThemPhong.Size = new System.Drawing.Size(756, 395);
            this.dgvThemPhong.TabIndex = 14;
            this.dgvThemPhong.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThemPhong_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Click chuột 2 lần để chọn";
            // 
            // frmThemPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 534);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvThemPhong);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmThemPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThemPhong";
            this.Load += new System.EventHandler(this.frmThemPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvThemPhong;
        private System.Windows.Forms.Label label2;
    }
}