using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Controllers
{
    class CKhoanThu
    {
        DA.DA da = new DA.DA();

        // Insert
        public int Insert(double SoTien, string idNhomThu, string idNguonTien, string Date, string Note)
        {
            String tenProcedure = "InsertKhoanThu";
            int ketQua = 0;
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("SoTien", SoTien));
            dsThamSo.Add(new SqlParameter("idNhomThu", idNhomThu));
            dsThamSo.Add(new SqlParameter("idNguonTien", idNguonTien));
            dsThamSo.Add(new SqlParameter("Date", Date));
            dsThamSo.Add(new SqlParameter("Note", Note));
            SqlParameter pkq = new SqlParameter("ketQua", ketQua);
            pkq.Direction = ParameterDirection.Output;
            dsThamSo.Add(pkq);
            da.Write(tenProcedure, dsThamSo);
            ketQua = int.Parse(pkq.Value.ToString());
            return ketQua;
        }
        public float SelectTongThu()
        {
            String tenProcedure = "SelectTongThu";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            DataTable tb = da.Read(tenProcedure, dsThamSo);
            if (tb != null && tb.Rows.Count > 0)
            {
                try
                {
                    float tongtien = float.Parse(tb.Rows[0]["TongTien"].ToString());
                    return tongtien;

                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        public float SelectTongThuByDate(string fr, string to)
        {
            String tenProcedure = "SelectTongThuByDate";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("datefr", fr));
            dsThamSo.Add(new SqlParameter("dateend", to));

            DataTable tb = da.Read(tenProcedure, dsThamSo);
            if (tb != null && tb.Rows.Count > 0)
            {
                try
                {
                    float tongtien = float.Parse(tb.Rows[0]["TongTien"].ToString());
                    return tongtien;

                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        public float SelectTongThuById(int id)
        {
            String tenProcedure = "SelectTongThuById";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("id", id));
            DataTable tb = da.Read(tenProcedure, dsThamSo);

            if (tb != null && tb.Rows.Count > 0)
            {
                try
                {
                    float tongtien = float.Parse(tb.Rows[0]["TongTien"].ToString());
                    return tongtien;

                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        public float SelectTongThuByIdAndDate(int id, string fr, string end)
        {
            String tenProcedure = "SelectTongThuByIdAndDate";
            List<SqlParameter> dsThamSo = new List<SqlParameter>();
            dsThamSo.Add(new SqlParameter("id", id));
            dsThamSo.Add(new SqlParameter("datefr", fr));
            dsThamSo.Add(new SqlParameter("dateend", end));
            DataTable tb = da.Read(tenProcedure, dsThamSo);

            if (tb != null && tb.Rows.Count > 0)
            {
                try
                {
                    float tongtien = float.Parse(tb.Rows[0]["TongTien"].ToString());
                    return tongtien;

                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
    }
}
