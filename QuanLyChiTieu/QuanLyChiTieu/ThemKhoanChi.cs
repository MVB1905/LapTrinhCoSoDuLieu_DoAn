using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class ThemKhoanChi : Form
    {
        public ThemKhoanChi()
        {
            InitializeComponent();
        }

        private void btnChi_Click(object sender, EventArgs e)
        {
            Controllers.CNhomChi cNhomChi = new Controllers.CNhomChi();
            int a = cNhomChi.Insert(tbxLoaiChiTieu.Text);
            if (a == -1)
            {
                MessageBox.Show("Đã tồn tại loại chi tiêu này!", "Hệ thống: Thông báo");
            }
            else
                MessageBox.Show("Đã thêm nhóm chi tiêu thành công!", "Hệ thống: Thông báo");
        }
    }
}
