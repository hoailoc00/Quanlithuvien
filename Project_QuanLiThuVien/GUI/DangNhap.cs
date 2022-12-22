using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class DangNhap : Form
    {
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            taikhoan.TenTK = txtTaiKhoan.Text;
            taikhoan.MatKhau = txtMatKhau.Text;
            string getuser = tkBLL.CheckLogin(taikhoan);

            switch (getuser)
            {
                case "require_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống !");
                    txtTaiKhoan.Focus();
                    return;

                case "require_matkhau":
                    MessageBox.Show("Mật khẩu không được để trống !");
                    txtMatKhau.Focus();
                    return;

                case "Tài khoản hoặc mật khẩu không chính xác !!!":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác !!!");
                    return;
            }

            MessageBox.Show("Đăng nhập thành công !");
            this.Hide();
            Form f = new TrangChu();
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
