using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess tkAccess = new TaiKhoanAccess();
        public string CheckLogin(TaiKhoan taikhoan)
        {
            if (taikhoan.TenTK == "")
            {
                return "require_taikhoan";
            }

            if (taikhoan.MatKhau == "")
            {
                return "require_matkhau";
            }

            string info= tkAccess.CheckLogin(taikhoan);
            return info;
        }
    }
}
