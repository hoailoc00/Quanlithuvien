using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class SachBLL
    {
        SachAccess sachAccess = new SachAccess();
        public DataTable TaoBang(string sql)
        {
            DataTable dt = sachAccess.TaoBang(sql);
            return dt;
        }
        public string ThemSach(Sach sach)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            if (sach.MaSach == "")
            {
                return "required_masach";
            }
            if (sach.TenSach == "")
            {
                return "required_tensach";
            }
            if (sach.TenTacGia == "")
            {
                return "required_tentacgia";
            }
            if (sach.NamXuatBan == 0)
            {
                return "required_namxuatban";
            }
            if (sach.TheLoai == "")
            {
                return "required_loaisach";
            }
            if (sach.SoLuong == 0)
            {
                return "required_soluong";
            }
            SqlCommand cmd2 = new SqlCommand("select MaSach from Table_sach", conn);
            conn.Open();
            SqlDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string sql = reader.GetString(0);
                    if (sql == sach.MaSach)
                    {
                        return "already_exist";
                    }
                }
                reader.Close();
            }
            return sachAccess.ThemSach(sach);
        }
        public string XoaSach(Sach sach)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            if (sach.MaSach == "")
            {
                return "required_masach";
            }
            SqlCommand cmd2 = new SqlCommand("select MaSach from Table_phieumuontra", conn);
            conn.Open();
            SqlDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string sql = reader.GetString(0);
                    if (sql == sach.MaSach)
                    {
                        return "still_exist";
                    }
                }
                reader.Close();
            }
            return sachAccess.XoaSach(sach);
        }
        public string SuaSach(Sach sach)
        {
            if (sach.MaSach == "")
            {
                return "required_masach";
            }
            return sachAccess.SuaSach(sach);
        }
        public DataTable TimKiemSachTheoMa(Sach sach)
        {
            return sachAccess.TimKiemSachTheoMa(sach);
        }
        public DataTable TimKiemSachTheoTen(Sach sach)
        {
            return sachAccess.TimKiemSachTheoTen(sach);
        }
        public DataTable TimKiemSachTheoTenTacGia(Sach sach)
        {
            return sachAccess.TimKiemSachTheoTenTacGia(sach);
        }
        public DataTable TimKiemSachTheoLoaiSach(Sach sach)
        {
            return sachAccess.TimKiemSachTheoLoaiSach(sach);
        }
    }
}
