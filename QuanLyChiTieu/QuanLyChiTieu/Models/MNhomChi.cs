using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Models
{
    public class MNhomChi
    {
        private string id;
        private string tenNhomChi;

        public string Id { get => id; set => id = value; }
        public string TenNhomChi { get => tenNhomChi; set => tenNhomChi = value; }
    }
}
