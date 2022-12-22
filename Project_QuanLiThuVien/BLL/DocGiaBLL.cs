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
    public class DocGiaBLL
    {
        DocGiaAccess dgAccess = new DocGiaAccess();
        public DataTable TaoBang(string sql)
        {
            DataTable dt = dgAccess.TaoBang(sql);
            return dt;
        }
        public string ThemDocGia(DocGia docgia)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            if (docgia.MaDocGia == "")
            {
                return "required_madocgia";
            }
            if (docgia.TenDocGia == "")
            {
                return "required_tendocgia";
            }
            if (docgia.DiaChi == "")
            {
                return "required_diachi";
            }
            if (docgia.GioiTinh == "")
            {
                return "required_gioitinh";
            }
            SqlCommand cmd2 = new SqlCommand("select MaDocGia from Table_docgia", conn);
            conn.Open();
            SqlDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string sql = reader.GetString(0);
                    if (sql == docgia.MaDocGia)
                    {
                        return "already_exist";
                    }
                }
                reader.Close();
            }
            return dgAccess.ThemDocGia(docgia);
        }
        public string XoaDocGia(DocGia docgia)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            if (docgia.MaDocGia == "")
            {
                return "required_docgia";
            }
            SqlCommand cmd2 = new SqlCommand("select MaDocGia from Table_phieumuontra", conn);
            conn.Open();
            SqlDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string sql = reader.GetString(0);
                    if (sql == docgia.MaDocGia)
                    {
                        return "still_exist";
                    }
                }
                reader.Close();
            }
            return dgAccess.XoaDocGia(docgia);
        }
        public string SuaDocGia(DocGia docgia)
        {
            if (docgia.MaDocGia == "")
            {
                return "required_docgia";
            }
            return dgAccess.SuaDocGia(docgia);
        }
        public DataTable TimKiemDocGiaTheoMa(DocGia docgia)
        {
            return dgAccess.TimKiemDocGiaTheoMa(docgia);
        }
        public DataTable TimKiemDocGiaTheoTen(DocGia docgia)
        {
            return dgAccess.TimKiemDocGiaTheoTen(docgia);
        }
    }
}
