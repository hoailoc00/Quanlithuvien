using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=LAPTOP-TPASVC8C\SQLEXPRESS;Initial Catalog=ProjectQuanLiThuVien;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            return conn;
        }
    }
    public class DatabaseAccess
    {
        public DataTable TaoBangDTO(string sql)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            return dt;
        }
        public static string CheckLoginDTO(TaiKhoan taikhoan)
        {
            string user = null;
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_taikhoan where TenTK=@user and MatKhau=@pass";
            cmd.Connection = conn;
            cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = taikhoan.TenTK;
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = taikhoan.MatKhau;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                return "Tài khoản hoặc mật khẩu không chính xác !!!";
            }
            return user;
        }
    }
}
