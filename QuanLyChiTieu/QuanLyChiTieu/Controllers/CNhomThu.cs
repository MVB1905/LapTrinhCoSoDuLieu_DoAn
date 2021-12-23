using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Controllers
{
    class CNhomThu
    {
        DA.DA da = new DA.DA();
        public List<Models.MNhomThu> SelectNhomThu()
        {
            String tenProcedure = "SelectNhomThu";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            DataTable tb = da.Read(tenProcedure, dsThamSo);
            List<Models.MNhomThu> ds = new List<Models.MNhomThu>();
            if (tb != null && tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    Models.MNhomThu m = new Models.MNhomThu();
                    m.Id = r["id"].ToString();
                    m.TenNhomThu = r["TenNhomThu"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }
    }
}
