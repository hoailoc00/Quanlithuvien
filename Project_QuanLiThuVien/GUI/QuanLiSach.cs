using BLL;
using DTO;
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
    public partial class QuanLiSach : Form
    {
        Sach sach = new Sach();
        SachBLL sachBLL = new SachBLL();
        public QuanLiSach()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu f = new TrangChu();
            f.Show();
        }

        private void QuanLiSach_Load(object sender, EventArgs e)
        {
            string s = "select * from Table_sach";
            DataTable dt = sachBLL.TaoBang(s);
            dgvSach.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            sach.MaSach = txtMasach.Text;
            sach.TenSach = txtTensach.Text;
            sach.TenTacGia = txtTentacgia.Text;
            sach.TheLoai = txtLoaisach.Text;
            if (txtNamxuatban.Text == "")
            {
                sach.NamXuatBan = 0;
            }
            else
            {
                sach.NamXuatBan = Convert.ToInt32(txtNamxuatban.Text.ToString());
            }
            if (txtSoluong.Text == "")
            {
                sach.SoLuong = 0;
            }
            else
            {
                sach.SoLuong = Convert.ToInt32(txtSoluong.Text.ToString());
            }
            SachBLL sachBLL = new SachBLL();
            string kq = sachBLL.ThemSach(sach);
            if (kq == "success")
            {
                MessageBox.Show("Đã thêm thành công!");
                QuanLiSach_Load(sender, e);
                txtMasach.Text = "";
                txtMasach.Focus();
                txtTensach.Text = "";
                txtLoaisach.Text = "";
                txtNamxuatban.Text = "";
                txtTentacgia.Text = "";
                txtSoluong.Text = "";
            }
            else
            {
                switch (kq)
                {

                    case "required_masach":
                        MessageBox.Show("Chưa nhập mã sách ! Vui lòng nhập lại !");
                        txtMasach.Focus();
                        break;
                    case "required_tensach":
                        MessageBox.Show("Chưa nhập tên sách ! Vui lòng nhập lại !");
                        txtTensach.Focus();
                        break;
                    case "required_tentacgia":
                        MessageBox.Show("Chưa nhập tên tác giả ! Vui lòng nhập lại !");
                        txtTentacgia.Focus();
                        break;
                    case "required_namxuatban":
                        MessageBox.Show("Chưa nhập năm xuất bản ! Vui lòng nhập lại !");
                        txtNamxuatban.Focus();
                        break;
                    case "required_loaisach":
                        MessageBox.Show("Chưa nhập loại sách ! Vui lòng nhập lại !");
                        txtLoaisach.Focus();
                        break;
                    case "required_soluong":
                        MessageBox.Show("Chưa nhập số lượng sách ! Vui lòng nhập lại !");
                        txtSoluong.Focus();
                        break;
                    case "already_exist":
                        MessageBox.Show("Đã tồn tại mã sách ! Vui lòng nhập lại !");
                        txtMasach.Text = "";
                        txtMasach.Focus();
                        txtTensach.Text = "";
                        txtTentacgia.Text = "";
                        txtNamxuatban.Text = "";
                        txtLoaisach.Text = "";
                        txtSoluong.Text = "";
                        break;
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            sach.MaSach = txtMasach.Text;
            sach.TenSach = txtTensach.Text;
            sach.TenTacGia = txtTentacgia.Text;
            if (txtNamxuatban.Text == "")
            {
                sach.NamXuatBan = 0;
            }
            sach.TheLoai = txtLoaisach.Text;
            if (txtSoluong.Text == "")
            {
                sach.SoLuong = 0;
            }
            SachBLL sachBLL = new SachBLL();
            string kq = sachBLL.XoaSach(sach);
            switch (kq)
            {
                case "success":
                    MessageBox.Show("Đã xóa thành công!");
                    QuanLiSach_Load(sender, e);
                    txtMasach.Text = "";
                    txtMasach.Focus();
                    txtTensach.Text = "";
                    txtTentacgia.Text = "";
                    txtNamxuatban.Text = "";
                    txtLoaisach.Text = "";
                    txtSoluong.Text = "";
                    break;
                case "required_masach":
                    MessageBox.Show("Chưa chọn sách để xóa! Vui lòng chọn sách");
                    break;
                case "still_exist":
                    MessageBox.Show("Vẫn còn phiếu mượn của sách này ! Vui lòng trả hết sách trước khi xóa !");
                    break;
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvSach.CurrentCell.Selected = true;
                txtMasach.Text = dgvSach.Rows[e.RowIndex].Cells["MaSach"].FormattedValue.ToString();
                txtTensach.Text = dgvSach.Rows[e.RowIndex].Cells["TenSach"].FormattedValue.ToString();
                txtTentacgia.Text = dgvSach.Rows[e.RowIndex].Cells["TenTacGia"].FormattedValue.ToString();
                txtNamxuatban.Text = dgvSach.Rows[e.RowIndex].Cells["NamXuatBan"].FormattedValue.ToString();
                txtLoaisach.Text = dgvSach.Rows[e.RowIndex].Cells["TheLoai"].FormattedValue.ToString();
                txtSoluong.Text = dgvSach.Rows[e.RowIndex].Cells["SoLuong"].FormattedValue.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            sach.MaSach = txtMasach.Text;
            sach.TenSach = txtTensach.Text;
            sach.TenTacGia = txtTentacgia.Text;
            sach.NamXuatBan = Convert.ToInt32(txtNamxuatban.Text.ToString());
            sach.SoLuong = Convert.ToInt32(txtSoluong.Text.ToString());
            sach.TheLoai = txtLoaisach.Text;
            string kq = sachBLL.SuaSach(sach);
            if (kq == "success")
            {
                MessageBox.Show("Đã sửa thành công!");
                QuanLiSach_Load(sender, e);
                txtMasach.Text = "";
                txtMasach.Focus();
                txtTensach.Text = "";
                txtTentacgia.Text = "";
                txtNamxuatban.Text = "";
                txtLoaisach.Text = "";
                txtSoluong.Text = "";
            }
            else
            {
                if (kq == "required_masach")
                    MessageBox.Show("Chưa chọn sách để sửa! Vui lòng chọn sách");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            sach.MaSach = txtMasach.Text;
            sach.TenSach = txtTensach.Text;
            sach.TenTacGia = txtTentacgia.Text;
            sach.TheLoai = txtLoaisach.Text;

            SachBLL sachBLL = new SachBLL();
            if (txtMasach.Text != "" && txtTensach.Text == "" && txtTentacgia.Text == "")
            {
                DataTable dtSach = sachBLL.TimKiemSachTheoMa(sach);
                if (dtSach.Rows.Count > 0)
                {
                    dgvSach.DataSource = dtSach;
                }
                else
                {
                    dgvSach.DataSource = null;
                    MessageBox.Show("Không tìm thấy sách! Vui lòng nhập lại");
                    txtMasach.Focus();
                }
            }
            else
            {
                if (txtMasach.Text == "" && txtTensach.Text != "")
                {
                    DataTable dtSach = sachBLL.TimKiemSachTheoTen(sach);
                    if (dtSach.Rows.Count > 0)
                    {
                        dgvSach.DataSource = dtSach;
                    }
                    else
                    {
                        dgvSach.DataSource = null;
                        MessageBox.Show("Không tìm thấy sách! Vui lòng nhập lại");
                        txtMasach.Focus();
                    }
                }
                else
                {
                    if (txtMasach.Text == "" && txtTensach.Text == "" && txtTentacgia.Text != "")
                    {
                        DataTable dtSach = sachBLL.TimKiemSachTheoTenTacGia(sach);
                        if (dtSach.Rows.Count > 0)
                        {
                            dgvSach.DataSource = dtSach;
                        }
                        else
                        {
                            dgvSach.DataSource = null;
                            MessageBox.Show("Không tìm thấy sách! Vui lòng nhập lại");
                            txtMasach.Focus();
                        }
                    }
                    else
                    {
                        if (txtMasach.Text == "" && txtTensach.Text == "" && txtTentacgia.Text == "" && txtLoaisach.Text != "")
                        {
                            DataTable dtSach = sachBLL.TimKiemSachTheoLoaiSach(sach);
                            if (dtSach.Rows.Count > 0)
                            {
                                dgvSach.DataSource = dtSach;
                            }
                            else
                            {
                                dgvSach.DataSource = null;
                                MessageBox.Show("Không tìm thấy sách! Vui lòng nhập lại");
                                txtMasach.Focus();
                            }
                        }

                        else
                        {
                            if (txtTensach.Text == "" && txtMasach.Text == "" && txtTentacgia.Text == "")
                            {
                                MessageBox.Show("Chưa nhập thông tin tìm kiếm! Vui lòng nhập lại!");
                                txtMasach.Focus();
                            }
                            else
                            {
                                if (txtMasach.Text != "" && txtTensach.Text != "" && txtTentacgia.Text == "")
                                {
                                    MessageBox.Show("Không được nhập cả mã và tên sách! Xin vui lòng nhập lại!");
                                    txtMasach.Text = "";
                                    txtMasach.Focus();
                                    txtTensach.Text = "";
                                }
                                else
                                {
                                    if (txtMasach.Text != "" && txtTensach.Text == "" && txtTentacgia.Text != "")
                                    {
                                        MessageBox.Show("Không được nhập cả mã sách và tên tác giả! Xin vui lòng nhập lại!");
                                        txtMasach.Text = "";
                                        txtMasach.Focus();
                                        txtTentacgia.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Không được nhập cả tên sách và tên tác giả! Xin vui lòng nhập lại!");
                                        txtTensach.Text = "";
                                        txtMasach.Focus();
                                        txtTentacgia.Text = "";
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_HienThiALL_Click(object sender, EventArgs e)
        {
            QuanLiSach_Load(sender, e);
        }

        private void btn_LamMoiThongTin_Click(object sender, EventArgs e)
        {
            txtMasach.Text = "";
            txtMasach.Focus();
            txtTensach.Text = "";
            txtTentacgia.Text = "";
            txtNamxuatban.Text = "";
            txtLoaisach.Text = "";
            txtSoluong.Text = "";
        }
    }
}
