using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Models
{
    public class MKhoanChi
    {
        private string id;
        private string soTien;
        private string idNhomChi;
        private string idNguonTien;
        private string date;
        private string node;

        public string Id { get => id; set => id = value; }
        public string SoTien { get => soTien; set => soTien = value; }
        public string IdNhomChi { get => idNhomChi; set => idNhomChi = value; }
        public string IdNguonTien { get => idNguonTien; set => idNguonTien = value; }
        public string Date { get => date; set => date = value; }
        public string Node { get => node; set => node = value; }
    }
}
