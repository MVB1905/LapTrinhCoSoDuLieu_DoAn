using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Models
{
    public class MNhomThu
    {
        private string id;
        private string tenNhomThu;

        public string Id { get => id; set => id = value; }
        public string TenNhomThu { get => tenNhomThu; set => tenNhomThu = value; }
    }
}
