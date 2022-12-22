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
using System.Data;
using System.Data.SqlClient;


namespace GUI
{
    public partial class QuanLiDocGia : Form
    {
        DocGia docgia = new DocGia();
        DocGiaBLL dgBLL = new DocGiaBLL();
        public QuanLiDocGia()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu f = new TrangChu();
            f.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DocGia docgia = new DocGia();
            docgia.MaDocGia = txtMaDocGia.Text;
            docgia.TenDocGia = txtHoTen.Text;
            docgia.DiaChi = txtDiaChi.Text;
            docgia.SDT = txtSDT.Text;
            docgia.GioiTinh = comboBoxGioiTinh.Text;
            docgia.NgayTao = dTimeTaoThe.Value;
            DocGiaBLL dgBLL = new DocGiaBLL();
            string kq = dgBLL.ThemDocGia(docgia);
            if (kq == "success")
            {
                MessageBox.Show("Đã thêm thành công!");
                QuanLiDocGia_Load(sender, e);
                txtMaDocGia.Text = "";
                txtMaDocGia.Focus();
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                comboBoxGioiTinh.SelectedIndex = 0;
            }
            else
            {
                if (kq == "required_madocgia")
                {
                    MessageBox.Show("Chưa nhập mã độc giả ! Vui lòng nhập lại !");
                    txtMaDocGia.Focus();
                }
                if (kq == "required_tendocgia")
                {
                    MessageBox.Show("Chưa nhập họ tên ! Vui lòng nhập lại !");
                    txtHoTen.Focus();
                }
                if (kq == "required_diachi")
                {
                    MessageBox.Show("Chưa nhập địa chỉ ! Vui lòng nhập lại !");
                    txtDiaChi.Focus();
                }
                if (kq == "required_gioitinh")
                {
                    MessageBox.Show("Chưa chọn giới tính ! Vui lòng chọn lại !");
                }
                if (kq == "already_exist")
                {
                    MessageBox.Show("Đã tồn tại mã độc giả ! Vui lòng nhập lại !");
                    txtMaDocGia.Text = "";
                    txtMaDocGia.Focus();
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    txtSDT.Text = "";
                    comboBoxGioiTinh.SelectedIndex = 0;
                }
            }
        }

        private void QuanLiDocGia_Load(object sender, EventArgs e)
        {
            string s = "select * from Table_docgia";
            DataTable dt = dgBLL.TaoBang(s);
            dgvDocGia.DataSource = dt;
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocGia.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvDocGia.CurrentCell.Selected = true;
                txtMaDocGia.Text = dgvDocGia.Rows[e.RowIndex].Cells["MaDocGia"].FormattedValue.ToString();
                txtHoTen.Text = dgvDocGia.Rows[e.RowIndex].Cells["TenDocGia"].FormattedValue.ToString();
                txtDiaChi.Text = dgvDocGia.Rows[e.RowIndex].Cells["DiaChi"].FormattedValue.ToString();
                txtSDT.Text = dgvDocGia.Rows[e.RowIndex].Cells["SDT"].FormattedValue.ToString();
                comboBoxGioiTinh.Text = dgvDocGia.Rows[e.RowIndex].Cells["GioiTinh"].FormattedValue.ToString();
                dTimeTaoThe.Text = dgvDocGia.Rows[e.RowIndex].Cells["NgayTao"].FormattedValue.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DocGia docgia = new DocGia();
            docgia.MaDocGia = txtMaDocGia.Text;
            docgia.TenDocGia = txtHoTen.Text;
            docgia.DiaChi = txtDiaChi.Text;
            docgia.SDT = txtSDT.Text;
            docgia.GioiTinh = comboBoxGioiTinh.Text;
            docgia.NgayTao = dTimeTaoThe.Value;
            DocGiaBLL dgBLL = new DocGiaBLL();
            string kq = dgBLL.XoaDocGia(docgia);
            switch (kq)
            {
                case "success":
                    MessageBox.Show("Đã xóa thành công!");
                    QuanLiDocGia_Load(sender, e);
                    txtMaDocGia.Text = "";
                    txtMaDocGia.Focus();
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    txtSDT.Text = "";
                    comboBoxGioiTinh.SelectedIndex = 0;
                    break;
                case "required_docgia":
                    MessageBox.Show("Chưa chọn độc giả để xóa ! Vui lòng chọn độc giả !");
                    break;
                case "still_exist":
                    MessageBox.Show("Vẫn còn phiếu mượn của độc giả này ! Vui lòng trả hết sách trước khi xóa !");
                    break;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DocGia docgia = new DocGia();
            docgia.MaDocGia = txtMaDocGia.Text;
            docgia.TenDocGia = txtHoTen.Text;
            docgia.DiaChi = txtDiaChi.Text;
            docgia.SDT = txtSDT.Text;
            docgia.GioiTinh = comboBoxGioiTinh.Text;
            docgia.NgayTao = dTimeTaoThe.Value;
            DocGiaBLL dgBLL = new DocGiaBLL();
            string kq = dgBLL.SuaDocGia(docgia);
            switch (kq)
            {
                case "success":
                    MessageBox.Show("Đã sửa thành công!");
                    QuanLiDocGia_Load(sender, e);
                    txtMaDocGia.Text = "";
                    txtMaDocGia.Focus();
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    txtSDT.Text = "";
                    comboBoxGioiTinh.SelectedIndex = 0;
                    break;
                case "required_docgia":
                    MessageBox.Show("Chưa chọn độc giả để sửa ! Vui lòng chọn độc giả !");
                    break;
            }
        }

        private void btn_getAll_Click(object sender, EventArgs e)
        {
            QuanLiDocGia_Load(sender, e);
            txtMaDocGia.Text = "";
            txtMaDocGia.Focus();
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            comboBoxGioiTinh.Text = "";
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            DocGia docgia = new DocGia();
            docgia.MaDocGia = txtMaDocGia.Text;
            docgia.TenDocGia = txtHoTen.Text;
            docgia.DiaChi = txtDiaChi.Text;
            docgia.SDT = txtSDT.Text;
            docgia.GioiTinh = comboBoxGioiTinh.Text;
            docgia.NgayTao = dTimeTaoThe.Value;
            DocGiaBLL dgBLL = new DocGiaBLL();
            if (txtMaDocGia.Text != "" && txtHoTen.Text == "")
            {
                DataTable dtDocGia = dgBLL.TimKiemDocGiaTheoMa(docgia);
                dgvDocGia.DataSource = dtDocGia;
            }
            else
            {
                if (txtMaDocGia.Text == "" && txtHoTen.Text != "")
                {
                    DataTable dtDocGia = dgBLL.TimKiemDocGiaTheoTen(docgia);
                    dgvDocGia.DataSource = dtDocGia;
                }
                else
                {
                    if (txtHoTen.Text == "" && txtMaDocGia.Text == "")
                    {
                        MessageBox.Show("Chưa nhập thông tin tìm kiếm! Vui lòng nhập lại!");
                        txtMaDocGia.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Không được nhập cả mã và tên tác giả! Xin vui lòng nhập lại!");
                        txtMaDocGia.Text = "";
                        txtMaDocGia.Focus();
                        txtHoTen.Text = "";
                    }
                }
            }
        }
    }
}
