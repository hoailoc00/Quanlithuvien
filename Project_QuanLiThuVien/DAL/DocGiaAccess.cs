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
    public class DocGiaAccess: DatabaseAccess
    {
        public DataTable TaoBang(string sql)
        {
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }

        public string ThemDocGia(DocGia docgia)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table_docgia values(@ma,@ten,@diachi,@sdt,@gioitinh,@ngaytao)";
            cmd.Connection = conn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = docgia.MaDocGia;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = docgia.TenDocGia;
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = docgia.DiaChi;
            cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = docgia.SDT;
            cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = docgia.GioiTinh;
            cmd.Parameters.Add("@ngaytao", SqlDbType.Date).Value = docgia.NgayTao;
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }
        public string XoaDocGia(DocGia docgia)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Table_docgia where MaDocGia=@ma";
            cmd.Connection = conn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = docgia.MaDocGia;
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }
        public string SuaDocGia(DocGia docgia)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Table_docgia set TenDocGia=@ten,DiaChi=@diachi,SDT=@sdt,GioiTinh=@gioitinh,NgayTao=@ngaytao where MaDocGia=@ma";
            cmd.Connection = conn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = docgia.MaDocGia;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = docgia.TenDocGia;
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = docgia.DiaChi;
            cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = docgia.SDT;
            cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = docgia.GioiTinh;
            cmd.Parameters.Add("@ngaytao", SqlDbType.Date).Value = docgia.NgayTao;
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return "success";
        }
        public DataTable TimKiemDocGiaTheoMa(DocGia docgia)
        {
            string sql = "select * from Table_docgia where MaDocGia=N" + "'" + docgia.MaDocGia + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
        public DataTable TimKiemDocGiaTheoTen(DocGia docgia)
        {
            string sql = "select * from Table_docgia where TenDocGia=N" + "'" + docgia.TenDocGia + "'";
            DataTable dataTable = TaoBangDTO(sql);
            return dataTable;
        }
    }
}
