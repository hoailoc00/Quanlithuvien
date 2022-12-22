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
    public partial class QuanLiMuonTra : Form
    {
        PhieuMuon phieumuon = new PhieuMuon();
        PhieuMuonBLL pmBLL = new PhieuMuonBLL();
        public QuanLiMuonTra()
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
            PhieuMuon phieumuon = new PhieuMuon();
            phieumuon.MaPhieuMuon = txtMaPhieuMuon.Text;
            phieumuon.MaDocGia = txtDocGia.Text;
            phieumuon.MaSach = txtMaSach.Text;
            phieumuon.NgayMuon = dateTimePickerMuon.Value;
            phieumuon.NgayTra = dateTimePickerTra.Value;
            PhieuMuonBLL pmBLL = new PhieuMuonBLL();
            string kq = pmBLL.ThemPhieuMuon(phieumuon);
            if (kq == "success")
            {
                MessageBox.Show("Đã mượn thành công!");
                QuanLiMuonTra_Load(sender, e);
                txtMaPhieuMuon.Text = "";
                txtMaPhieuMuon.Focus();
                txtDocGia.Text = "";
                txtMaSach.Text = "";
                dateTimePickerMuon.Text = default;
                dateTimePickerTra.Text = default;
            }
            else
            {
                switch (kq)
                {
                    case "required_maphieumuon" :
                        MessageBox.Show("Chưa nhập mã phiếu mượn ! Vui lòng nhập lại !");
                        txtMaPhieuMuon.Focus();
                        break;
                    case "required_madocgia":
                        MessageBox.Show("Chưa nhập mã độc giả ! Vui lòng nhập lại !");
                        txtDocGia.Focus();
                        break;
                    case "required_masach":
                        MessageBox.Show("Chưa nhập mã sách ! Vui lòng nhập lại !");
                        txtMaSach.Focus();
                        break;
                    case "already_exist":
                        MessageBox.Show("Mã phiếu đã tồn tại ! Vui lòng nhập lại !");
                        txtMaPhieuMuon.Text = "";
                        txtMaPhieuMuon.Focus();
                        txtDocGia.Text = "";
                        txtMaSach.Text = "";
                        break;
                    case "MaDocGia_not_exist":
                        MessageBox.Show("Mã độc giả không tồn tại ! Vui lòng nhập lại !");
                        txtDocGia.Text = "";
                        txtDocGia.Focus();
                        break;
                    case "MaSach_not_exist":
                        MessageBox.Show("Mã sách không tồn tại ! Vui lòng nhập lại !");
                        txtMaSach.Text = "";
                        txtMaSach.Focus();
                        break;
                    case "khong_con_sach":
                        MessageBox.Show("Sách muốn mượn hiện không còn ! Vui lòng nhập lại !");
                        txtMaSach.Text = "";
                        txtMaSach.Focus();
                        break;
                    case "invailid_day":
                        MessageBox.Show("Ngày trả sách không hợp lệ ! Vui lòng nhập lại !");
                        break;
                }
            }

        }

        private void QuanLiMuonTra_Load(object sender, EventArgs e)
        {
            string s = "Select a.MaPhieuMuon, b.TenDocGia, c.TenSach, a.NgayMuon, a.NgayTra " +
                "From Table_phieumuontra as a, Table_docgia as b, Table_sach as c " +
                "where a.MaDocGia = b.MaDocGia and a.MaSach = c.MaSach";
            DataTable dt = pmBLL.TaoBang(s);
            dgvPhieuMuon.DataSource = dt;
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            PhieuMuon phieumuon = new PhieuMuon();
            phieumuon.MaPhieuMuon = txtMaPhieuMuon.Text;
            phieumuon.NgayMuon = dateTimePickerMuon.Value;
            phieumuon.NgayTra = dateTimePickerTra.Value;
            PhieuMuonBLL pmBLL = new PhieuMuonBLL();
            string kq = pmBLL.GiaHan(phieumuon);
            switch (kq)
            {
                case "success":
                    MessageBox.Show("Đã gia hạn thành công!");
                    QuanLiMuonTra_Load(sender, e);
                    txtMaPhieuMuon.Text = "";
                    txtMaPhieuMuon.Focus();
                    txtDocGia.Text = "";
                    txtMaSach.Text = "";
                    dateTimePickerMuon.Text = default;
                    dateTimePickerTra.Text = default;
                    break;
                case "out_date":
                    MessageBox.Show("Ngày gia hạn không hợp lệ ! Vui lòng nhập lại !");
                    break;
                case "required_phieu":
                    MessageBox.Show("Chưa chọn phiếu để gia hạn ! Vui lòng chọn lại phiếu !");
                    break;
            }
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuMuon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvPhieuMuon.CurrentCell.Selected = true;
                txtMaPhieuMuon.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells["MaPhieuMuon"].FormattedValue.ToString();
                dateTimePickerMuon.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells["NgayMuon"].FormattedValue.ToString();
                dateTimePickerTra.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells["NgayTra"].FormattedValue.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            QuanLiMuonTra_Load(sender, e);
            txtMaPhieuMuon.Text = "";
            txtMaPhieuMuon.Focus();
            txtDocGia.Text = "";
            txtMaSach.Text = "";
            dateTimePickerMuon.Text = default;
            dateTimePickerTra.Text = default;
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            PhieuMuon phieumuon = new PhieuMuon();
            phieumuon.MaPhieuMuon = txtMaPhieuMuon.Text;
            phieumuon.NgayMuon = dateTimePickerMuon.Value;
            phieumuon.NgayTra = dateTimePickerTra.Value;
            PhieuMuonBLL pmBLL = new PhieuMuonBLL();
            string kq = pmBLL.TraSach(phieumuon);
            switch (kq)
            {
                case "success":
                    MessageBox.Show("Đã trả thành công!");
                    QuanLiMuonTra_Load(sender, e);
                    txtMaPhieuMuon.Text = "";
                    txtMaPhieuMuon.Focus();
                    txtDocGia.Text = "";
                    txtMaSach.Text = "";
                    dateTimePickerMuon.Text = default;
                    dateTimePickerTra.Text = default;
                    break;
                case "required_phieu":
                    MessageBox.Show("Chưa chọn phiếu để trả ! Vui lòng chọn lại phiếu !");
                    break;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PhieuMuon phieumuon = new PhieuMuon();
            phieumuon.MaPhieuMuon = txtMaPhieuMuon.Text;
            phieumuon.MaDocGia = txtDocGia.Text;
            phieumuon.MaSach = txtMaSach.Text;
            phieumuon.NgayMuon = dateTimePickerMuon.Value;
            phieumuon.NgayTra = dateTimePickerTra.Value;
            PhieuMuonBLL pmBLL = new PhieuMuonBLL();
            if (txtMaPhieuMuon.Text != "")
            {
                DataTable dtPhieuMuon = pmBLL.TimKiemTheoMaPhieu(phieumuon);
                dgvPhieuMuon.DataSource = dtPhieuMuon;
            }
            else
            {
                if (txtMaPhieuMuon.Text == "" && txtDocGia.Text != "")
                {
                    DataTable dtPhieuMuon = pmBLL.TimKiemTheoMaDocGia(phieumuon);
                    dgvPhieuMuon.DataSource = dtPhieuMuon;
                }
                else
                {
                    if (txtMaPhieuMuon.Text == "" && txtDocGia.Text == "" && txtMaSach.Text != "")
                    {
                        DataTable dtPhieuMuon = pmBLL.TimKiemTheoMaSach(phieumuon);
                        dgvPhieuMuon.DataSource = dtPhieuMuon;
                    }
                    else
                    {
                        MessageBox.Show("Tìm kiếm không hợp lệ ! Xin vui lòng nhập lại!");
                        txtMaPhieuMuon.Text = "";
                        txtMaPhieuMuon.Focus();
                        txtDocGia.Text = "";
                        txtMaSach.Text = "";
                    }
                }
            }
        }
    }
}
