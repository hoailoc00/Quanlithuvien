using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SachAccess : DatabaseAccess
    {
        public DataTable TaoBang(string sql)
        {
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public string ThemSach(Sach sach)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table_sach values(@masach,@tensach,@tentacgia,@namxuatban,@maloaisach,@soluong)";
            cmd.Connection = conn;
            cmd.Parameters.Add("@masach", SqlDbType.NVarChar).Value = sach.MaSach;
            cmd.Parameters.Add("@tensach", SqlDbType.NVarChar).Value = sach.TenSach;
            cmd.Parameters.Add("@tentacgia", SqlDbType.NVarChar).Value = sach.TenTacGia;
            cmd.Parameters.Add("@namxuatban", SqlDbType.Int).Value = sach.NamXuatBan;
            cmd.Parameters.Add("@maloaisach", SqlDbType.NVarChar).Value = sach.TheLoai;
            cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = sach.SoLuong;
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }
        public string XoaSach(Sach sach)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Table_sach where MaSach=@ma";
            cmd.Connection = conn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = sach.MaSach;
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }

        public string SuaSach(Sach sach)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Table_sach set TenSach=@ten,TenTacGia=@tentacgia,NamXuatBan=@namxuatban,TheLoai=@loaisach, SoLuong=@soluong where MaSach=@ma";
            cmd.Connection = conn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = sach.MaSach;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = sach.TenSach;
            cmd.Parameters.Add("@tentacgia", SqlDbType.NVarChar).Value = sach.TenTacGia;
            cmd.Parameters.Add("@namxuatban", SqlDbType.Int).Value = sach.NamXuatBan;
            cmd.Parameters.Add("@loaisach", SqlDbType.NVarChar).Value = sach.TheLoai;
            cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = sach.SoLuong;
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }

        public DataTable TimKiemSachTheoMa(Sach sach)
        {
            string sql = "select * from Table_sach where MaSach=N" + "'" + sach.MaSach + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public DataTable TimKiemSachTheoTen(Sach sach)
        {
            string sql = "select * from Table_sach where TenSach=N" + "'" + sach.TenSach + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public DataTable TimKiemSachTheoTenTacGia(Sach sach)
        {
            string sql = "select * from Table_sach where TenTacGia=N" + "'" + sach.TenTacGia + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public DataTable TimKiemSachTheoLoaiSach(Sach sach)
        {
            string sql = "select * from Table_sach where TheLoai=N" + "'" + sach.TheLoai + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
    }
}
