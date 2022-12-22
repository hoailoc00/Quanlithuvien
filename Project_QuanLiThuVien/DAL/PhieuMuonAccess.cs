using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace DAL
{
    public class PhieuMuonAccess : DatabaseAccess
    {
        public DataTable TaoBang(string sql)
        {
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public string ThemPhieuMuon(PhieuMuon phieumuon)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table_phieumuontra values(@maphieu,@madg,@masach,@ngaymuon,@ngaytra)";
            cmd.Connection = conn;
            cmd.Parameters.Add("@maphieu", SqlDbType.NVarChar).Value = phieumuon.MaPhieuMuon;
            cmd.Parameters.Add("@madg", SqlDbType.NVarChar).Value = phieumuon.MaDocGia;
            cmd.Parameters.Add("@masach", SqlDbType.NVarChar).Value = phieumuon.MaSach;
            cmd.Parameters.Add("@ngaymuon", SqlDbType.Date).Value = phieumuon.NgayMuon;
            cmd.Parameters.Add("@ngaytra", SqlDbType.Date).Value = phieumuon.NgayTra;
            int kq = cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update Table_sach set SoLuong=@soluong where MaSach=@masach";
            cmd2.Connection = conn;
            cmd2.Parameters.Add("@masach", SqlDbType.NVarChar).Value = phieumuon.MaSach;
            SqlCommand cmd3 = new SqlCommand("Select SoLuong from Table_sach where MaSach=@masach", conn);
            cmd3.Parameters.Add("@masach",SqlDbType.NVarChar).Value = phieumuon.MaSach;
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                int soluongsach = reader.GetInt32(0);
                soluongsach -= 1;
                cmd2.Parameters.Add("@soluong", SqlDbType.Int).Value = soluongsach;
            }
            reader.Close();
            int kq2 = cmd2.ExecuteNonQuery();
            conn.Close();
            return "success";
        }
        public string GiaHan(PhieuMuon phieumuon)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Table_phieumuontra set NgayTra=@ngaytra where MaPhieuMuon=@maphieu";
            cmd.Connection = conn;
            cmd.Parameters.Add("@maphieu", SqlDbType.NVarChar).Value = phieumuon.MaPhieuMuon;
            cmd.Parameters.Add("@ngaytra", SqlDbType.Date).Value = phieumuon.NgayTra;
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }
        public string TraSach(PhieuMuon phieumuon)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Table_phieumuontra where MaPhieuMuon=@maphieu";
            cmd.Connection = conn;
            cmd.Parameters.Add("@maphieu", SqlDbType.NVarChar).Value = phieumuon.MaPhieuMuon;
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update Table_sach set SoLuong=@soluong where MaSach=@masach";
            cmd2.Connection = conn;
            SqlCommand cmd4 = new SqlCommand("select MaSach from Table_phieumuontra where MaPhieuMuon=@maphieu", conn);
            cmd4.Parameters.Add("@maphieu", SqlDbType.NVarChar).Value = phieumuon.MaPhieuMuon;
            SqlDataReader reader2 = cmd4.ExecuteReader();
            reader2.Read();
            string masach = reader2.GetString(0);
            cmd2.Parameters.Add("@masach", SqlDbType.NVarChar).Value = masach;
            SqlCommand cmd3 = new SqlCommand("Select SoLuong from Table_sach where MaSach=@masach", conn);
            reader2.Close();
            cmd3.Parameters.Add("@masach", SqlDbType.NVarChar).Value = masach;
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                int soluongsach = reader.GetInt32(0);
                soluongsach += 1;
                cmd2.Parameters.Add("@soluong", SqlDbType.Int).Value = soluongsach;
            }
            reader.Close();
            int kq2 = cmd2.ExecuteNonQuery();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }
        public DataTable TimKiemTheoMaPhieu(PhieuMuon phieumuon)
        {
            string sql = "Select a.MaPhieuMuon, b.TenDocGia, c.TenSach, a.NgayMuon, a.NgayTra " +
                "From Table_phieumuontra as a, Table_docgia as b, Table_sach as c " +
                "where a.MaDocGia = b.MaDocGia and a.MaSach = c.MaSach and a.MaPhieuMuon=N"+"'"+ phieumuon.MaPhieuMuon+"'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public DataTable TimKiemTheoMaDocGia(PhieuMuon phieumuon)
        {
            string sql = "Select a.MaPhieuMuon, b.TenDocGia, c.TenSach, a.NgayMuon, a.NgayTra " +
                "From Table_phieumuontra as a, Table_docgia as b, Table_sach as c " +
                "where a.MaDocGia = b.MaDocGia and a.MaSach = c.MaSach and a.MaDocGia=N" + "'" + phieumuon.MaDocGia + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public DataTable TimKiemTheoMaSach(PhieuMuon phieumuon)
        {
            string sql = "Select a.MaPhieuMuon, b.TenDocGia, c.TenSach, a.NgayMuon, a.NgayTra " +
                "From Table_phieumuontra as a, Table_docgia as b, Table_sach as c " +
                "where a.MaDocGia = b.MaDocGia and a.MaSach = c.MaSach and a.MaSach=N" + "'" + phieumuon.MaSach + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
    }
}
