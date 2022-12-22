using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            this.Hide();
            f.Show();
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiDocGia f = new QuanLiDocGia();
            f.Show();
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiMuonTra f = new QuanLiMuonTra();
            f.Show();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiSach f = new QuanLiSach();
            f.Show();
        }
    }
}
