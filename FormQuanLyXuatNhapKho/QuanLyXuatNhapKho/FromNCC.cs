using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyXuatNhapKho
{
    public partial class FromNCC : Form

    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-R9UI5U6\SQLEXPRESS;Initial Catalog=Quan_Ly_Xuat_Nhap_Kho1;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private string sql = "";
        public FromNCC()
        {
            InitializeComponent();
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FromNCC_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT * FROM tbl_NhaCungCap";
                HienThi(sql);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }


        }

        private void FromNCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        
        #region [ các hàm dùng chung cho tất cả các FORM]
        private void TrangThaiButton(bool b)
        {
            btnThem.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnKhoiphuc.Enabled = !b;
        }
        private void ClearTXT()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDT.Text = "";
        }
        private void TrangThaiTXT(bool b)
        {
            txtTenNCC.Enabled = b;
            txtDiaChi.Enabled = b;
            txtSoDT.Enabled = b;


        }
        private void HienThi(string sql)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNCC.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private bool KiemTraTrungDL(string sql)
        {
            bool bKiemtra = false;
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bKiemtra = true;
                }
                dt.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            return bKiemtra;
        }

        private string SinhMaTuDong(string ma)
        {
            string Matusinh = "";
            int count = 0;
            count = dgvNCC.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvNCC.Rows[count - 2].Cells[0].Value);
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
        #region [các BUTTON]

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvNCC.Enabled = false;
            txtMaNCC.Text = SinhMaTuDong("ncc");
            txtTenNCC.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvNCC.Enabled = false;
            txtTenNCC.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETENhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
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
                sql = "SELECT * FROM tbl_NhaCungCap";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMa = txtMaNCC.Text;
                //sql = "SELECT * FROM tbl_KhoHang WHERE Makho = '" + sMa + "'";
                //if (KiemTraTrungDL(sql))
                //{
                //    MessageBox.Show("Mã kho đã tồn tại !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtMaNCC.Focus();
                //    txtMaNCC.SelectAll();
                //    return;
                //}
                // lấy dữa liệu từ text để lưu vào csdl.
                cmd = new SqlCommand("ThemNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tenncc", txtTenNCC.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSoDT.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else if (Trangthai == "EDIT")
            {
                cmd = new SqlCommand("EDITNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tenncc", txtTenNCC.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSoDT.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            btnKhoiphuc_Click(sender, e);
        }

        private void btnKhoiphuc_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dgvNCC.Enabled = true;
            dgvNCC.CurrentCell = dgvNCC[0, 0];
            dgvNCC_SelectionChanged(sender, e);
            sql = "SELECT * FROM tbl_NhaCungCap";
            HienThi(sql);
        }
         #endregion

        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNCC.SelectedCells.Count > 0 && dgvNCC.SelectedRows.Count > 0)
            {
                int Index = dgvNCC.CurrentCell.RowIndex;
                txtMaNCC.Text =dgvNCC.Rows[Index].Cells[0].Value.ToString();
                txtTenNCC.Text = dgvNCC.Rows[Index].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNCC.Rows[Index].Cells[2].Value.ToString();
                txtSoDT.Text = dgvNCC.Rows[Index].Cells[3].Value.ToString();
            }
            else
            {
                ClearTXT();
            }
        }
    }
}

