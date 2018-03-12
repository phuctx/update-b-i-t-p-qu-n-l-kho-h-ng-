using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXuatNhapKho
{
    public partial class Frm_PhieuNhap : Form
    {
        private String connecttionString = @"Data Source=DESKTOP-R9UI5U6\SQLEXPRESS;Initial Catalog=Quan_Ly_Xuat_Nhap_Kho1;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private string sql = "";
        public Frm_PhieuNhap()
        {
            InitializeComponent();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Frm_PhieuNhap_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT * FROM tbl_PhieuNhap";
                HienThi(sql);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private void Frm_PhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        #region[Hàm dùng chung]
        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private string SinhMaTuDong(string ma)
        {
            string Matusinh = "";
            int count = 0;
            count = dgvData.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvData.Rows[count - 2].Cells[0].Value);
            chuoiSo = Convert.ToInt32(ChuoiMa.Replace(ma, ""));
            if (chuoiSo + 1 < 10)
            {
                Matusinh = ma + "00" + (chuoiSo + 1).ToString();
            }
            else if (chuoiSo + 1 < 100)
            {
                Matusinh = ma + "0" + (chuoiSo + 1).ToString();
            }

            return Matusinh;
        }
        #endregion

        #region[các BUTTON]
        private void tHÊMMỚIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sSophieunhap = SinhMaTuDong("spn");
            string sTrangthai = "ADD";
            //Frm_CTPhieuNhap frm = new Frm_CTPhieuNhap(sSophieunhap, sTrangthai);
            //frm.ShowDialog();
        }

        private void sỬAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Index = dgvData.CurrentCell.RowIndex;
            string sSophieunhap = dgvData.Rows[Index].Cells[0].Value.ToString();
            string sTrangthai = "EDIT";
            //Frm_CTPhieuNhap frm = new Frm_CTPhieuNhap(sSophieunhap, sTrangthai);
            //frm.ShowDialog();
        }

        private void xÓAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Index = dgvData.CurrentCell.RowIndex;

            if (Index >= 0)
            {
                string sSophieunhap = dgvData.Rows[Index].Cells[0].Value.ToString();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập: " + sSophieunhap, "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("DELETECTPhieuNhapTheoSPN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Sophieunhap", sSophieunhap);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    cmd = new SqlCommand("DELETEPhieuNhap", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Sophieunhap", sSophieunhap);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                    // load lại dữ liệu trong datagridview.
                    sql = "SELECT * FROM tbl_PhieuNhap";
                    HienThi(sql);
                }
            }
        }

        private void xEMTHÔNGTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Index = dgvData.CurrentCell.RowIndex;
            string sSophieunhap = dgvData.Rows[Index].Cells[0].Value.ToString();

            string sTrangthai = "LOAD";
            //Frm_CTPhieuNhap frm = new Frm_CTPhieuNhap(sSophieunhap, sTrangthai);
            //frm.ShowDialog();
        }
        #endregion

    }
}
