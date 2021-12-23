using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Controllers
{
    class CLichSu
    {
        DA.DA da = new DA.DA();
        public List<Models.MLichSu> SelectLichSuGanDay()
        {
            String tenProcedure = "SelectLichSu";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            DataTable tb = da.Read(tenProcedure, dsThamSo);
            List<Models.MLichSu> ds = new List<Models.MLichSu>();
            if (tb != null && tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    Models.MLichSu m = new Models.MLichSu();
                    m.Id = r["id"].ToString();
                    m.SoTien = r["SoTien"].ToString();
                    m.LoaiChiTieu = r["LoaiChiTieu"].ToString();
                    m.Date = r["Date"].ToString();
                    m.Note = r["Note"].ToString();
                    m.TenChiTieu = r["TenChiTieu"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }
        public List<Models.MLichSu> SelectLichSu(string tenProceduce)
        {
            String tenProcedure = tenProceduce;
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            DataTable tb = da.Read(tenProcedure, dsThamSo);
            List<Models.MLichSu> ds = new List<Models.MLichSu>();
            if (tb != null && tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    Models.MLichSu m = new Models.MLichSu();
                    m.Id = r["id"].ToString();
                    m.SoTien = r["SoTien"].ToString();
                    m.LoaiChiTieu = r["LoaiChiTieu"].ToString();
                    m.Date = r["Date"].ToString();
                    m.Note = r["Note"].ToString();
                    m.TenChiTieu = r["TenChiTieu"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }
        public List<Models.MLichSu> SelectLichSuByDate(string date)
        {
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("date", date));
            DataTable tb = da.Read("SelectLichSuByDate", dsThamSo);
            List<Models.MLichSu> ds = new List<Models.MLichSu>();
            if (tb != null && tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    Models.MLichSu m = new Models.MLichSu();
                    m.Id = r["id"].ToString();
                    m.SoTien = r["SoTien"].ToString();
                    m.LoaiChiTieu = r["LoaiChiTieu"].ToString();
                    m.Date = r["Date"].ToString();
                    m.Note = r["Note"].ToString();
                    m.TenChiTieu = r["TenChiTieu"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }

        public List<Models.MLichSu> SelectLichSuById(string id)
        {
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("id", id));
            DataTable tb = da.Read("SelectLichSuById", dsThamSo);
            List<Models.MLichSu> ds = new List<Models.MLichSu>();
            if (tb != null && tb.Rows.Count > 0)
            {
                foreach (DataRow r in tb.Rows)
                {
                    Models.MLichSu m = new Models.MLichSu();
                    m.Id = r["id"].ToString();
                    m.SoTien = r["SoTien"].ToString();
                    m.LoaiChiTieu = r["LoaiChiTieu"].ToString();
                    m.Date = r["Date"].ToString();
                    m.Note = r["Note"].ToString();
                    m.TenChiTieu = r["TenChiTieu"].ToString();
                    ds.Add(m);
                }
                return ds;
            }
            else
                return null;
        }
    }
}
