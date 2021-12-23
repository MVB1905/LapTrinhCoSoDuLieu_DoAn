
namespace QuanLyChiTieu
{
    partial class ThemKhoanChi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxLoaiChiTieu = new System.Windows.Forms.TextBox();
            this.btnChi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxLoaiChiTieu);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(303, 64);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập tên loại chi tiêu";
            // 
            // tbxLoaiChiTieu
            // 
            this.tbxLoaiChiTieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxLoaiChiTieu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLoaiChiTieu.Location = new System.Drawing.Point(19, 27);
            this.tbxLoaiChiTieu.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLoaiChiTieu.MaxLength = 10;
            this.tbxLoaiChiTieu.Name = "tbxLoaiChiTieu";
            this.tbxLoaiChiTieu.Size = new System.Drawing.Size(276, 25);
            this.tbxLoaiChiTieu.TabIndex = 0;
            // 
            // btnChi
            // 
            this.btnChi.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChi.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnChi.Location = new System.Drawing.Point(13, 97);
            this.btnChi.Margin = new System.Windows.Forms.Padding(4);
            this.btnChi.Name = "btnChi";
            this.btnChi.Size = new System.Drawing.Size(303, 55);
            this.btnChi.TabIndex = 87;
            this.btnChi.Text = "Thêm loại chi tiêu";
            this.btnChi.UseVisualStyleBackColor = false;
            this.btnChi.Click += new System.EventHandler(this.btnChi_Click);
            // 
            // ThemKhoanChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(334, 168);
            this.Controls.Add(this.btnChi);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThemKhoanChi";
            this.Text = "ThemKhoanChi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxLoaiChiTieu;
        private System.Windows.Forms.Button btnChi;
    }
}