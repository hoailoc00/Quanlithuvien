using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_quản_lý_thư_viện_2
{
    public partial class ManHinhChinh : Form
    {
        public ManHinhChinh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyTacGia QLTG = new QuanLyTacGia();
            this.Hide();
            QLTG.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuanLyDocGia QLDG = new QuanLyDocGia();
            this.Hide();
            QLDG.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
;       }

        private void button4_Click(object sender, EventArgs e)
        {
            QuanLySach QLS = new QuanLySach();
            this.Hide();
            QLS.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuanLyMuonTra MT = new QuanLyMuonTra();
            this.Hide();
            MT.Show();
        }
    } 
}
