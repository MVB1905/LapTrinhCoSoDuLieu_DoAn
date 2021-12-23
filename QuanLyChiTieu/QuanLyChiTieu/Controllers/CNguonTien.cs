using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Controllers
{
    class CNguonTien
    {
        DA.DA da = new DA.DA();
        public List<Models.MNguonTien> SelectNguonTien()
        {
            String tenProcedure = "SelectNguonTien";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            DataTable tb = da.Read(tenProcedure, dsThamSo);
            List<Models.MNguonTien> ds = new List<Models.MNguonTien>();
            if (tb != null && tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    Models.MNguonTien m = new Models.MNguonTien();
                    m.Id = r["id"].ToString();
                    m.TenNguonTien = r["TenNguonTien"].ToString();
                    m.SoTien = r["SoTien"].ToString(); ;
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }
        public void UpdateChuyenTien(string idfrom, string idto, double SoTien, string date, string note)
        {
            String tenProcedure = "UpdateChuyenTien";
            int ketQua = 0;
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("idfrom", idfrom));
            dsThamSo.Add(new SqlParameter("idto", idto));
            dsThamSo.Add(new SqlParameter("SoTien", SoTien));
            dsThamSo.Add(new SqlParameter("Date", date));
            dsThamSo.Add(new SqlParameter("Note", note));
            SqlParameter pkq = new SqlParameter("ketqua", ketQua);
            pkq.Direction = ParameterDirection.Output;
            dsThamSo.Add(pkq);
            da.Write(tenProcedure, dsThamSo);
        }
    }
}
