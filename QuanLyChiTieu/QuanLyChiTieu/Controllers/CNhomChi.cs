using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Controllers
{
    class CNhomChi
    {
        DA.DA da = new DA.DA();
        public List<Models.MNhomChi> SelectNhomChi()
        {
            String tenProcedure = "SelectNhomChi";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            DataTable tb = da.Read(tenProcedure, dsThamSo);
            List<Models.MNhomChi> ds = new List<Models.MNhomChi>();
            if (tb != null && tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    Models.MNhomChi m = new Models.MNhomChi();
                    m.Id = r["id"].ToString();
                    m.TenNhomChi = r["TenNhomChi"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }
        public int Insert(string tennhomchi)
        {
            String tenProcedure = "InsertNhomChi";
            int ketQua = 0;
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("tennhomchi", tennhomchi));
            SqlParameter pkq = new SqlParameter("ketQua", ketQua);
            pkq.Direction = ParameterDirection.Output;
            dsThamSo.Add(pkq);
            da.Write(tenProcedure, dsThamSo);
            ketQua = int.Parse(pkq.Value.ToString());
            return ketQua;
        }
    }
}
