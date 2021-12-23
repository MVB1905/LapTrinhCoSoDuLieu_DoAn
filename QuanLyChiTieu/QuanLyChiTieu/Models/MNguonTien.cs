using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Models
{
    public class MNguonTien
    {
        private string id;
        private string tenNguonTien;
        private string soTien;

        public string Id { get => id; set => id = value; }
        public string TenNguonTien { get => tenNguonTien; set => tenNguonTien = value; }
        public string SoTien { get => soTien; set => soTien = value; }
    }
}
