using QuanLyChiTieu.Models;
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
    public partial class FormMain : Form
    {
        Controllers.CNguonTien cNguonTien = new Controllers.CNguonTien();
        Controllers.CLichSu cLichSu = new Controllers.CLichSu();
        Controllers.CKhoanChi cKhoanChi = new Controllers.CKhoanChi();
        Controllers.CKhoanThu cKhoanThu = new Controllers.CKhoanThu();
        public FormMain()
        {
            InitializeComponent();
        }

        // Functions go here -------->
        string DateToDDmmYYYY(string ngaythang)
        {
            string[] tmp = ngaythang.Split('/');
            return tmp[1] + '/' + tmp[0] + '/' + tmp[2];
        }
        string DateChange(string ngaythang)
        {
            string[] tmp = ngaythang.Split('/');
            return tmp[2] + '/' + tmp[1] + '/' + tmp[0];
        }
        public void RefreshNguonTIen()
        {
            // Load Nhóm thu
            List<Models.MNguonTien> ds = cNguonTien.SelectNguonTien();
            if (ds != null && ds.Count > 0)
            {
                float tongtien = 0;
                float formMoney = 0;
                foreach (Models.MNguonTien m in ds)
                {
                    if (m.Id == "1")
                    {
                        float currentMoney = float.Parse(m.SoTien);
                        if (checkisFloat(lbTienNganHang.Text.Split('đ')[0]))
                        {
                            formMoney = float.Parse(lbTienNganHang.Text.Split('đ')[0]);
                        }
                        if (currentMoney != formMoney)
                        {
                            lbTienNganHang.Text = currentMoney.ToString("N0", CultureInfo.InvariantCulture) + "đ";
                            RefreshLichSuGanDay();
                        }
                    }
                    else if (m.Id == "2")
                    {
                        float currentMoney = float.Parse(m.SoTien);
                        if (checkisFloat(lbTienMat.Text.Split('đ')[0]))
                        {
                            formMoney = float.Parse(lbTienMat.Text.Split('đ')[0]);
                        }
                        if (currentMoney != formMoney)
                        {
                            lbTienMat.Text = float.Parse(m.SoTien).ToString("N0", CultureInfo.InvariantCulture) + "đ";
                            RefreshLichSuGanDay();
                        }
                    }
                    tongtien += float.Parse(m.SoTien);
                }
                if (checkisFloat(lbTongTien.Text.Split('đ')[0]))
                {
                    formMoney = float.Parse(lbTongTien.Text.Split('đ')[0]);
                }
                if (tongtien != formMoney)
                {
                    lbTongTien.Text = tongtien.ToString("N0", CultureInfo.InvariantCulture) + "đ";
                    RefreshLichSuGanDay();
                }
            }
        }
        public void RefreshLichSuGanDay()
        {
            List<Models.MLichSu> ds = cLichSu.SelectLichSuGanDay();
            if (ds != null && ds.Count > 0)
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("TT", typeof(int));
                tb.Columns.Add("ID", typeof(string));
                tb.Columns.Add("Date", typeof(string));
                tb.Columns.Add("LoaiChiTieu", typeof(String));
                tb.Columns.Add("TenChiTieu", typeof(String));
                tb.Columns.Add("SoTien", typeof(String));
                int tt = 0;
                foreach (MLichSu m in ds)
                {
                    tt++;
                    if (!(tt > 20))
                    {
                        DataRow r = tb.NewRow();
                        r["TT"] = tt;
                        r["ID"] = m.Id;
                        r["Date"] = DateToDDmmYYYY(m.Date.Split(' ')[0]);
                        r["LoaiChiTieu"] = m.LoaiChiTieu;
                        r["TenChiTieu"] = m.TenChiTieu;
                        r["SoTien"] = float.Parse(m.SoTien).ToString("N0", CultureInfo.InvariantCulture) + "đ";
                        tb.Rows.Add(r);
                    }
                    else
                    {
                        break;
                    }
                }
                dgv.DataSource = tb;
                dgv.Columns["ID"].Visible = false;
                dgv.Columns["TT"].Visible = false;
                dgv.Columns[0].HeaderText = "STT";
                dgv.Columns[2].HeaderText = "Ngày";
                dgv.Columns[2].Width = 93;
                dgv.Columns[3].HeaderText = "Nhóm";
                dgv.Columns[3].Width = 117;
                dgv.Columns[4].HeaderText = "Loại chi tiêu";
                dgv.Columns[4].Width = 114;
                dgv.Columns[5].HeaderText = "Số tiền";
            }
            else
                dgv.DataSource = null;
        }
        public void RefreshLichSu(string tenproceduce)
        {
            List<Models.MLichSu> ds = cLichSu.SelectLichSu(tenproceduce);
            if (ds != null && ds.Count > 0)
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("TT", typeof(int));
                tb.Columns.Add("ID", typeof(string));
                tb.Columns.Add("Date", typeof(string));
                tb.Columns.Add("LoaiChiTieu", typeof(String));
                tb.Columns.Add("TenChiTieu", typeof(String));
                tb.Columns.Add("SoTien", typeof(String));
                int tt = 0;
                foreach (MLichSu m in ds)
                {
                    tt++;
                    DataRow r = tb.NewRow();
                    r["TT"] = tt;
                    r["ID"] = m.Id;
                    r["Date"] = DateToDDmmYYYY(m.Date.Split(' ')[0]);
                    r["LoaiChiTieu"] = m.LoaiChiTieu;
                    r["TenChiTieu"] = m.TenChiTieu;
                    r["SoTien"] = float.Parse(m.SoTien).ToString("N0", CultureInfo.InvariantCulture) + "đ";
                    tb.Rows.Add(r);
                }
                dgvLichSu.DataSource = tb;
                dgvLichSu.Columns["ID"].Visible = false;
                dgvLichSu.Columns["TT"].Visible = false;
                dgvLichSu.Columns[0].HeaderText = "STT";
                dgvLichSu.Columns[2].HeaderText = "Ngày";
                dgvLichSu.Columns[2].Width = 93;
                dgvLichSu.Columns[3].HeaderText = "Nhóm";
                dgvLichSu.Columns[3].Width = 117;
                dgvLichSu.Columns[4].HeaderText = "Loại chi tiêu";
                dgvLichSu.Columns[4].Width = 114;
                dgvLichSu.Columns[5].HeaderText = "Số tiền";
            }
            else
                dgvLichSu.DataSource = null;
        }
        public void RefreshLichSuByDate(string date)
        {
            List<Models.MLichSu> ds = cLichSu.SelectLichSuByDate(date);
            if (ds != null && ds.Count > 0)
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("TT", typeof(int));
                tb.Columns.Add("ID", typeof(string));
                tb.Columns.Add("Date", typeof(string));
                tb.Columns.Add("LoaiChiTieu", typeof(String));
                tb.Columns.Add("TenChiTieu", typeof(String));
                tb.Columns.Add("SoTien", typeof(String));
                int tt = 0;
                foreach (MLichSu m in ds)
                {
                    tt++;
                    DataRow r = tb.NewRow();
                    r["TT"] = tt;
                    r["ID"] = m.Id;
                    r["Date"] = DateToDDmmYYYY(m.Date.Split(' ')[0]);
                    r["LoaiChiTieu"] = m.LoaiChiTieu;
                    r["TenChiTieu"] = m.TenChiTieu;
                    r["SoTien"] = float.Parse(m.SoTien).ToString("N0", CultureInfo.InvariantCulture) + "đ";
                    tb.Rows.Add(r);
                }
                dgvLichSu.DataSource = tb;
                dgvLichSu.Columns["ID"].Visible = false;
                dgvLichSu.Columns["TT"].Visible = false;
                dgvLichSu.Columns[0].HeaderText = "STT";
                dgvLichSu.Columns[2].HeaderText = "Ngày";
                dgvLichSu.Columns[2].Width = 93;
                dgvLichSu.Columns[3].HeaderText = "Nhóm";
                dgvLichSu.Columns[3].Width = 117;
                dgvLichSu.Columns[4].HeaderText = "Loại chi tiêu";
                dgvLichSu.Columns[4].Width = 114;
                dgvLichSu.Columns[5].HeaderText = "Số tiền";
            }
            else
                dgvLichSu.DataSource = null;
        }
        public void RefreshChart()
        {
            float tongchi = cKhoanChi.SelectTongChi();
            float tongthu = cKhoanThu.SelectTongThu();

            // Tổng Thu Chi Pie
            tongthuchi.Series.RemoveAt(0);
            tongthuchi.Series.Add("TongThuChiPie");
            tongthuchi.Series["TongThuChiPie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //
            tongthuchi.Series["TongThuChiPie"].Points.AddXY("Tổng thu", tongthu);
            tongthuchi.Series["TongThuChiPie"].Points.AddXY("Tổng chi", tongchi);
            tongthuchi.Series["TongThuChiPie"].IsValueShownAsLabel = true;


            // Chi Tiêu Pie
            chitieu.Series.RemoveAt(0);
            chitieu.Series.Add("ChiTieuPie");
            chitieu.Series["ChiTieuPie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //
            float chitieu1 = cKhoanChi.SelectTongChiById(1);
            float chitieu2 = cKhoanChi.SelectTongChiById(2);
            float chitieu3 = cKhoanChi.SelectTongChiById(3);
            float chitieu4 = cKhoanChi.SelectTongChiById(4);
            float chitieu5 = cKhoanChi.SelectTongChiById(5);
            float chitieu6 = cKhoanChi.SelectTongChiById(6);
            float chitieu7 = cKhoanChi.SelectTongChiById(7);
            float chitieu8 = cKhoanChi.SelectTongChiById(8);
            float chitieu9 = cKhoanChi.SelectTongChiById(9);
            float chitieu10 = cKhoanChi.SelectTongChiById(10);
            float chitieu11 = cKhoanChi.SelectTongChiById(11);
            float chitieu12 = cKhoanChi.SelectTongChiById(12);
            float chitieu13 = cKhoanChi.SelectTongChiById(13);
            float chitieu14 = cKhoanChi.SelectTongChiById(14);


            //
            if (chitieu1 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Ăn uống", chitieu1);
            }
            if (chitieu2 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Sinh hoạt", chitieu2);

            }
            if (chitieu3 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Đi lại", chitieu3);
            }
            if (chitieu4 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Giải trí", chitieu4);
            }
            if (chitieu5 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Sức khỏe", chitieu5);
            }
            if (chitieu6 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Tích lũy", chitieu6);
            }
            if (chitieu7 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Nhà cửa", chitieu7);
            }
            if (chitieu8 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Con cái", chitieu8);
            }
            if (chitieu9 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Học tập", chitieu9);
            }
            if (chitieu10 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Xã giao", chitieu10);
            }
            if (chitieu11 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Kinh doanh", chitieu11);
            }
            if (chitieu12 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Cho vay", chitieu12);
            }
            if (chitieu13 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Trả nợ", chitieu13);
            }
            if (chitieu14 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Từ thiện", chitieu14);
            }
            chitieu.Series["ChiTieuPie"].IsValueShownAsLabel = true;


            // Thu nhập Pie
            thunhap.Series.RemoveAt(0);
            thunhap.Series.Add("ThuNhapPie");
            thunhap.Series["ThuNhapPie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //
            float thunhap1 = cKhoanThu.SelectTongThuById(1);
            float thunhap2 = cKhoanThu.SelectTongThuById(2);
            float thunhap3 = cKhoanThu.SelectTongThuById(3);
            float thunhap4 = cKhoanThu.SelectTongThuById(4);
            float thunhap5 = cKhoanThu.SelectTongThuById(5);
            float thunhap6 = cKhoanThu.SelectTongThuById(6);
            float thunhap7 = cKhoanThu.SelectTongThuById(7);
            //

            if (thunhap1 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Lương", thunhap1);
            }
            if (thunhap2 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Thưởng", thunhap2);

            }
            if (thunhap3 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Đi vay", thunhap3);
            }
            if (thunhap4 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Đầu tư", thunhap4);
            }
            if (thunhap5 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Kinh doanh", thunhap5);
            }
            if (thunhap6 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Thu hồi nợ", thunhap6);
            }
            if (thunhap7 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Mừng tặng", thunhap7);
            }


            thunhap.Series["ThuNhapPie"].IsValueShownAsLabel = true;
        }
        public void RefreshChartByDate()
        {
            string datefr = DateChange(fr.Text);
            string dateend = DateChange(to.Text);

            float tongchi = cKhoanChi.SelectTongChiByDate(datefr, dateend);
            float tongthu = cKhoanThu.SelectTongThuByDate(datefr, dateend);

            // Tổng Thu Chi Pie
            tongthuchi.Series.RemoveAt(0);
            tongthuchi.Series.Add("TongThuChiPie");
            tongthuchi.Series["TongThuChiPie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //
            tongthuchi.Series["TongThuChiPie"].Points.AddXY("Tổng thu", tongthu);
            tongthuchi.Series["TongThuChiPie"].Points.AddXY("Tổng chi", tongchi);
            tongthuchi.Series["TongThuChiPie"].IsValueShownAsLabel = true;


            // Chi Tiêu Pie
            chitieu.Series.RemoveAt(0);
            chitieu.Series.Add("ChiTieuPie");
            chitieu.Series["ChiTieuPie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //
            float chitieu1 = cKhoanChi.SelectTongChiByIdAndDate(1, datefr, dateend);
            float chitieu2 = cKhoanChi.SelectTongChiByIdAndDate(2, datefr, dateend);
            float chitieu3 = cKhoanChi.SelectTongChiByIdAndDate(3, datefr, dateend);
            float chitieu4 = cKhoanChi.SelectTongChiByIdAndDate(4, datefr, dateend);
            float chitieu5 = cKhoanChi.SelectTongChiByIdAndDate(5, datefr, dateend);
            float chitieu6 = cKhoanChi.SelectTongChiByIdAndDate(6, datefr, dateend);
            float chitieu7 = cKhoanChi.SelectTongChiByIdAndDate(7, datefr, dateend);
            float chitieu8 = cKhoanChi.SelectTongChiByIdAndDate(8, datefr, dateend);
            float chitieu9 = cKhoanChi.SelectTongChiByIdAndDate(9, datefr, dateend);
            float chitieu10 = cKhoanChi.SelectTongChiByIdAndDate(10, datefr, dateend);
            float chitieu11 = cKhoanChi.SelectTongChiByIdAndDate(11, datefr, dateend);
            float chitieu12 = cKhoanChi.SelectTongChiByIdAndDate(12, datefr, dateend);
            float chitieu13 = cKhoanChi.SelectTongChiByIdAndDate(13, datefr, dateend);
            float chitieu14 = cKhoanChi.SelectTongChiByIdAndDate(14, datefr, dateend);


            //
            if (chitieu1 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Ăn uống", chitieu1);
            }
            if (chitieu2 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Sinh hoạt", chitieu2);

            }
            if (chitieu3 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Đi lại", chitieu3);
            }
            if (chitieu4 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Giải trí", chitieu4);
            }
            if (chitieu5 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Sức khỏe", chitieu5);
            }
            if (chitieu6 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Tích lũy", chitieu6);
            }
            if (chitieu7 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Nhà cửa", chitieu7);
            }
            if (chitieu8 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Con cái", chitieu8);
            }
            if (chitieu9 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Học tập", chitieu9);
            }
            if (chitieu10 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Xã giao", chitieu10);
            }
            if (chitieu11 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Kinh doanh", chitieu11);
            }
            if (chitieu12 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Cho vay", chitieu12);
            }
            if (chitieu13 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Trả nợ", chitieu13);
            }
            if (chitieu14 != 0)
            {
                chitieu.Series["ChiTieuPie"].Points.AddXY("Từ thiện", chitieu14);
            }
            chitieu.Series["ChiTieuPie"].IsValueShownAsLabel = true;


            // Thu nhập Pie
            thunhap.Series.RemoveAt(0);
            thunhap.Series.Add("ThuNhapPie");
            thunhap.Series["ThuNhapPie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //
            float thunhap1 = cKhoanThu.SelectTongThuByIdAndDate(1, datefr, dateend);
            float thunhap2 = cKhoanThu.SelectTongThuByIdAndDate(2, datefr, dateend);
            float thunhap3 = cKhoanThu.SelectTongThuByIdAndDate(3, datefr, dateend);
            float thunhap4 = cKhoanThu.SelectTongThuByIdAndDate(4, datefr, dateend);
            float thunhap5 = cKhoanThu.SelectTongThuByIdAndDate(5, datefr, dateend);
            float thunhap6 = cKhoanThu.SelectTongThuByIdAndDate(6, datefr, dateend);
            float thunhap7 = cKhoanThu.SelectTongThuByIdAndDate(7, datefr, dateend);
            //

            if (thunhap1 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Lương", thunhap1);
            }
            if (thunhap2 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Thưởng", thunhap2);

            }
            if (thunhap3 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Đi vay", thunhap3);
            }
            if (thunhap4 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Đầu tư", thunhap4);
            }
            if (thunhap5 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Kinh doanh", thunhap5);
            }
            if (thunhap6 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Thu hồi nợ", thunhap6);
            }
            if (thunhap7 != 0)
            {
                thunhap.Series["ThuNhapPie"].Points.AddXY("Mừng tặng", thunhap7);
            }


            thunhap.Series["ThuNhapPie"].IsValueShownAsLabel = true;
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
                return false;
            }
        }
        public void PopupModalDetail(string id)
        {
            List<Models.MLichSu> ds = cLichSu.SelectLichSuById(id);
            string msg = "Mã: " + ds[0].Id + Environment.NewLine +
                "Loại chi tiêu: " + ds[0].LoaiChiTieu + Environment.NewLine +
                "Tên chi tiêu: " + ds[0].TenChiTieu + Environment.NewLine +
                "Ngày phát sinh thu chi: " + DateToDDmmYYYY(ds[0].Date) + Environment.NewLine +
                "Ghi chú: " + ds[0].Note;

            MessageBox.Show(msg, "Hệ thống: Xem chi tiết thu chi");
        }

        // Auto Function go here
        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshNguonTIen();
            RefreshLichSuGanDay();
            //RefreshLichSu("SelectLichSu");
            //tbxLoaiThuChi.SelectedIndex = 0;
            RefreshChart();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemGiaoDich f = new ThemGiaoDich();
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RefreshNguonTIen();
            RefreshLichSuGanDay();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshNguonTIen();
        }
        private void tbxLoaiThuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbxLoaiThuChi.SelectedIndex == 0)
                RefreshLichSu("SelectLichSu");
            if (tbxLoaiThuChi.SelectedIndex == 1)
                RefreshLichSu("SelectLichSuByChi");
            else if (tbxLoaiThuChi.SelectedIndex == 2)
                RefreshLichSu("SelectLichSuByThu");
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            RefreshLichSu("SelectLichSu");
            RefreshLichSuGanDay();
            tbxLoaiThuChi.SelectedIndex = 0;
            tbxLocTheo.SelectedIndex = 0;
            RefreshChart();
        }
        private void tbxLocTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbxLocTheo.SelectedIndex == 0)
            {
                string date = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
                RefreshLichSuByDate(date);
            } 
            else if (tbxLocTheo.SelectedIndex == 1)
            {
                string date = DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd");
                RefreshLichSuByDate(date);
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgv.SelectedRows[0].Cells[1].Value.ToString();
            PopupModalDetail(id);
        }
        private void dgvLichSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvLichSu.SelectedRows[0].Cells[1].Value.ToString();
            PopupModalDetail(id);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshChartByDate();
        }

        private void fr_ValueChanged(object sender, EventArgs e)
        {
            RefreshChartByDate();
        }
    }
}