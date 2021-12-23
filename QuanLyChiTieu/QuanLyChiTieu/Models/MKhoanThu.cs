using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Models
{
    public class MKhoanThu
    {
        private string id;
        private string soTien;
        private string idNhomThu;
        private string idNguonTien;
        private string date;
        private string note;

        public string Id { get => id; set => id = value; }
        public string SoTien { get => soTien; set => soTien = value; }
        public string IdNhomThu { get => idNhomThu; set => idNhomThu = value; }
        public string IdNguonTien { get => idNguonTien; set => idNguonTien = value; }
        public string Date { get => date; set => date = value; }
        public string Note { get => note; set => note = value; }
    }
}
