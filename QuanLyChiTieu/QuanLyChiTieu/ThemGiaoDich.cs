using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class ThemGiaoDich : Form
    {
        Controllers.CNhomThu cNhomThu = new Controllers.CNhomThu();
        Controllers.CNhomChi cNhomChi = new Controllers.CNhomChi();
        Controllers.CNguonTien cNguonTien = new Controllers.CNguonTien();
        Controllers.CKhoanChi cKhoanChi = new Controllers.CKhoanChi();
        Controllers.CKhoanThu cKhoanThu = new Controllers.CKhoanThu();

        public ThemGiaoDich()
        {
            InitializeComponent();
        }

        private void tbxChiSoTien_Leave(object sender, EventArgs e)
        {
            string[] t = tbxChiTien.Text.Split('đ');
            if (checkisFloat(t[0]))
            {
                if (!string.IsNullOrEmpty(t[0]))
                {
                    double tien = double.Parse(t[0]);
                    tbxChiTien.Text = tien.ToString("N0", CultureInfo.InvariantCulture) + "đ";
                }
            }
        }

        private void tbxThuTien_Leave(object sender, EventArgs e)
        {
            string[] t = tbxThuTien.Text.Split('đ');
            if (checkisFloat(t[0]))
            {
                if (!string.IsNullOrEmpty(t[0]))
                {
                    double tien = double.Parse(t[0]);
                    tbxThuTien.Text = tien.ToString("N0", CultureInfo.InvariantCulture) + "đ";

                }
            }
        }

        private void tbxDoiTien_Leave(object sender, EventArgs e)
        {
            string[] t = tbxDoiTien.Text.Split('đ');
            if(checkisFloat(t[0]))
            {
                if (!string.IsNullOrEmpty(t[0]))
                {
                    double tien = double.Parse(t[0]);
                    tbxDoiTien.Text = tien.ToString("N0", CultureInfo.InvariantCulture) + "đ";
                }
            }    

        }

        private void ThemGiaoDich_Load(object sender, EventArgs e)
        {
            LoadListCombobox();
        }
        private void LoadListCombobox()
        {
            // Load Nhóm thu
            List<Models.MNhomThu> ds = cNhomThu.SelectNhomThu();
            if (ds != null && ds.Count > 0)
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("ID", typeof(String));
                tb.Columns.Add("Name", typeof(String));
                foreach (Models.MNhomThu m in ds)
                {
                    tbxLoaiThu.Items.Add(m.Id + " | " + m.TenNhomThu);
                }    

            }
            // Load Nhóm chi
            List<Models.MNhomChi> ds_nhomchi = cNhomChi.SelectNhomChi();
            if (ds_nhomchi != null && ds_nhomchi.Count > 0)
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("ID", typeof(String));
                tb.Columns.Add("Name", typeof(String));
                foreach (Models.MNhomChi m in ds_nhomchi)
                {
                    tbxLoaiChi.Items.Add(m.Id + " | " + m.TenNhomChi);
                }

            }
            // Load Nhóm chi
            List<Models.MNguonTien> ds_nguontien = cNguonTien.SelectNguonTien();
            if (ds_nguontien != null && ds_nguontien.Count > 0)
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("ID", typeof(String));
                tb.Columns.Add("Name", typeof(String));
                foreach (Models.MNguonTien m in ds_nguontien)
                {

                    tbxNguonChi.Items.Add(m.Id + " | " + m.TenNguonTien);
                    tbxNguonThu.Items.Add(m.Id + " | " + m.TenNguonTien);
                    tbxDoiDi.Items.Add(m.Id + " | " + m.TenNguonTien);
                    tbxDoiDen.Items.Add(m.Id + " | " + m.TenNguonTien);
                }

            }
        }

        private void btnChi_Click(object sender, EventArgs e)
        {
            if(ValidateChi())
            {
                double SoTien = double.Parse((tbxChiTien.Text.Split('đ'))[0]);
                string idNhomChi = tbxLoaiChi.Text.Split('|')[0];
                string idNguonTien = tbxNguonChi.Text.Split('|')[0];
                string Date = DateChange(timeChi.Text);
                string Note = tbxGhiChuChi.Text;

                var kq = cKhoanChi.Insert(SoTien, idNhomChi, idNguonTien, Date, Note);
                if (kq > 0)
                {
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý, vui lòng thử lại!");
                }
            }    
        }
        
        private void btnThu_Click(object sender, EventArgs e)
        {
            if(ValidateThu())
            {
                double SoTien = double.Parse((tbxThuTien.Text.Split('đ'))[0]);
                string idNhomThu = tbxLoaiThu.Text.Split('|')[0];
                string idNguonTien = tbxNguonThu.Text.Split('|')[0];
                string Date = DateChange(timeThu.Text);
                string Note = tbxGhiChuThu.Text;
                var kq = cKhoanThu.Insert(SoTien, idNhomThu, idNguonTien, Date, Note);
                if (kq > 0)
                {
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý, vui lòng thử lại!");
                }
            }    
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            double SoTien = double.Parse((tbxDoiTien.Text.Split('đ'))[0]);
            string idfrom = tbxDoiDi.Text.Split('|')[0];
            string idto = tbxDoiDen.Text.Split('|')[0];
            string Date = DateChange(timeDoi.Text);
            string Note = tbxGhiChuDoi.Text;

            cNguonTien.UpdateChuyenTien(idfrom, idto, SoTien, Date, Note);
        }
        string DateChange(string ngaythang)
        {
            string[] tmp = ngaythang.Split('/');
            return tmp[2] + '/' + tmp[1] + '/' + tmp[0];
        }

        public bool ValidateChi()
        {

            if (string.IsNullOrEmpty(tbxChiTien.Text))
            {
                MessageBox.Show("Hệ thống: Thông báo!", "Vui lòng nhập số tiền chi!");
                tbxChiTien.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tbxLoaiChi.Text))
            {
                MessageBox.Show("Hệ thống: Thông báo!", "Vui lòng chọn loại chi!");
                tbxLoaiChi.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tbxNguonChi.Text))
            {
                MessageBox.Show("Hệ thống: Thông báo!", "Vui lòng chọn nguồn tiền!");
                tbxNguonChi.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateThu()
        {

            if (string.IsNullOrEmpty(tbxThuTien.Text))
            {
                MessageBox.Show("Hệ thống: Thông báo!", "Vui lòng nhập số tiền thu!");
                tbxThuTien.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tbxLoaiThu.Text))
            {
                MessageBox.Show("Hệ thống: Thông báo!", "Vui lòng chọn loại thu!");
                tbxLoaiThu.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tbxNguonThu.Text))
            {
                MessageBox.Show("Hệ thống: Thông báo!", "Vui lòng chọn nguồn tiền!");
                tbxNguonThu.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checkisFloat(string str)
        {
            float f;

            if (float.TryParse(str, out f))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Hệ thống: Cảnh báo lỗi!", "Vui lòng nhập tiền là số!");
                tbxChiTien.Text = "";
                tbxThuTien.Text = "";
                tbxDoiTien.Text = "";
                return false;
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemKhoanChi c = new ThemKhoanChi();
            c.Show();
        }
    }
}
