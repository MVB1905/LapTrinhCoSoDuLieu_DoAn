using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Models
{
    public class MLichSu
    {
        private string id;
        private string soTien;
        private string loaiChiTieu;
        private string date;
        private string note;
        private string tenChiTieu;

        public string Id { get => id; set => id = value; }
        public string SoTien { get => soTien; set => soTien = value; }
        public string LoaiChiTieu { get => loaiChiTieu; set => loaiChiTieu = value; }
        public string Date { get => date; set => date = value; }
        public string Note { get => note; set => note = value; }
        public string TenChiTieu { get => tenChiTieu; set => tenChiTieu = value; }
    }
}
