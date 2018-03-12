using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXuatNhapKho
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_HuongdanSD frm = new Frm_HuongdanSD();
            frm.ShowDialog();
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_KhoHang frm = new Frm_KhoHang();
            frm.ShowDialog();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_NCC frm = new Frm_NCC();
            frm.ShowDialog();
        }

        private void đổiHìnhNềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(openFile.FileName);
            }
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_NhomSanPham frm = new Frm_NhomSanPham();
            frm.ShowDialog();
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CTPhieuNhap frm = new Frm_CTPhieuNhap();
            frm.ShowDialog();
        }

        private void phiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CTPhieuXuat frm = new Frm_CTPhieuXuat();
            frm.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_KhachHang frm = new Frm_KhachHang();
            frm.ShowDialog();
        }

        private void nhânViênKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_NhanVienKho frm = new Frm_NhanVienKho();
            frm.ShowDialog();
        }

        private void nhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_HangHoa frm = new Frm_HangHoa();
            frm.ShowDialog();
        }
    }
}
