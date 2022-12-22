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
    public class PhieuMuonBLL
    {
        PhieuMuonAccess pmAccess = new PhieuMuonAccess();
        public DataTable TaoBang(string sql)
        {
            DataTable dt = pmAccess.TaoBang(sql);
            return dt;
        }
        public string ThemPhieuMuon(PhieuMuon phieumuon)
        {
            if(phieumuon.NgayTra <= phieumuon.NgayMuon)
            {
                return "invailid_day";
            }
            SqlConnection conn = SqlConnectionData.Connect();
            if (phieumuon.MaPhieuMuon == "")
            {
                return "required_maphieumuon";
            }
            if (phieumuon.MaDocGia == "")
            {
                return "required_madocgia";
            }
            if (phieumuon.MaSach == "")
            {
                return "required_masach";
            }
            SqlCommand cmd = new SqlCommand("select MaPhieuMuon from Table_phieumuontra", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string sql = reader.GetString(0);
                    if (sql == phieumuon.MaPhieuMuon)
                    {
                        return "already_exist";
                    }
                }
                reader.Close();
            }
            SqlCommand cmd2 = new SqlCommand("select MaDocGia from Table_docgia", conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            bool hasMaTaGia = false;
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    string sql = reader2.GetString(0);
                    if(sql == phieumuon.MaDocGia)
                    {
                        hasMaTaGia = true;
                    }
                }
                if(hasMaTaGia== false)
                {
                    return "MaDocGia_not_exist";
                }
                reader2.Close();
            }
            SqlCommand cmd3 = new SqlCommand("select MaSach from Table_sach", conn);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            bool hasMaSach = false;
            if (reader3.HasRows)
            {
                while (reader3.Read())
                {
                    string sql = reader3.GetString(0);
                    if (sql == phieumuon.MaSach)
                    {
                        hasMaSach = true;
                    }
                }
                if (hasMaSach == false)
                {
                    return "MaSach_not_exist";
                }
                reader3.Close();
            }
            SqlCommand cmd4 = new SqlCommand("select SoLuong from Table_sach where MaSach=@masach",conn);
            cmd4.Parameters.Add("@masach", SqlDbType.NVarChar).Value = phieumuon.MaSach;
            SqlDataReader reader4 = cmd4.ExecuteReader();
            bool hasSach = true;
            while (reader4.Read())
            {
                 int soluongsach = reader4.GetInt32(0);
                 if(soluongsach == 0)
                 {
                    hasSach = false;
                 }
            }
            if(hasSach == false)
            {
                return "khong_con_sach";
            }
            return pmAccess.ThemPhieuMuon(phieumuon);
        }
        public string GiaHan(PhieuMuon phieumuon)
        {
            if(phieumuon.MaPhieuMuon == "")
            {
                return "required_phieu";
            }
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select NgayTra from Table_phieumuontra where MaPhieuMuon=N'" + phieumuon.MaPhieuMuon+"'",conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DateTime ngaytra = reader.GetDateTime(0);
                    if(phieumuon.NgayTra <= ngaytra)
                    {
                        return "out_date";
                    }
                }
            }
            conn.Close();
            return pmAccess.GiaHan(phieumuon);
        }
        public string TraSach(PhieuMuon phieumuon)
        {
            if (phieumuon.MaPhieuMuon == "")
            {
                return "required_phieu";
            }
            return pmAccess.TraSach(phieumuon);
        }
        public DataTable TimKiemTheoMaPhieu(PhieuMuon phieumuon)
        {
            return pmAccess.TimKiemTheoMaPhieu(phieumuon);
        }
        public DataTable TimKiemTheoMaDocGia(PhieuMuon phieumuon)
        {
            return pmAccess.TimKiemTheoMaDocGia(phieumuon);
        }
        public DataTable TimKiemTheoMaSach(PhieuMuon phieumuon)
        {
            return pmAccess.TimKiemTheoMaSach(phieumuon);
        }
    }
}
