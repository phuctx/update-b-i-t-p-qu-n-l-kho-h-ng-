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
    public partial class Frm_NhomSanPham : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-R9UI5U6\SQLEXPRESS;Initial Catalog=Quan_Ly_Xuat_Nhap_Kho1;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public Frm_NhomSanPham()
        {
            InitializeComponent();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Frm_NCC_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT Manhom AS 'Mã nhóm', Tennhom AS 'Tên nhóm', Makho AS 'Mã kho' FROM tbl_NhomSanPham";
                HienThi(sql);
                cbbKhohang.DataSource = LoadComBoBox("SELECT * FROM tbl_KhoHang");
                cbbKhohang.DisplayMember = "Tenkho";
                cbbKhohang.ValueMember = "Makho";
                dgvData_SelectionChanged(sender, e);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            // xóa lựa chọn dòng trong datagridview.
            //dgvData.ClearSelection();
        }

        private void Frm_NCC_FormClosing(object sender, FormClosingEventArgs e)
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
            txtManhom.Text = "";
            txtTennhom.Text = "";
            cbbKhohang.SelectedIndex = -1;
        }
        private void TrangThaiTXT(bool b)
        {
            txtTennhom.Enabled = b;
            cbbKhohang.Enabled = b;

        }
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
            count = dgvData.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvData.Rows[count - 2].Cells[0].Value);
            string a = ChuoiMa.Replace(ma, "");
                //chuoiSo = Convert.ToInt32(ChuoiMa.Replace(ma, ""));
            chuoiSo = Convert.ToInt32(a);
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

        private bool CheckTXT()
        {
            bool kt = true;
            if (txtManhom.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã nhóm !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                kt = false;
                txtManhom.Focus();
                txtManhom.SelectAll();
                return kt;
            }
            else if (txtTennhom.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên nhóm !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                kt = false;
                txtTennhom.Focus();
                txtTennhom.SelectAll();
                return kt;
            }
            else if (cbbKhohang.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập kho hàng !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                kt = false;
                cbbKhohang.Focus();
                cbbKhohang.SelectAll();
                return kt;
            }
            return kt;
        }
        #endregion

        #region[xử lý các COMBOBOX...]
        private DataTable LoadComBoBox(string sqlCBB)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(sqlCBB, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
        #endregion

        #region [các BUTTON]

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvData.Enabled = false;
            txtManhom.Text = SinhMaTuDong("nsp");
            txtTennhom.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvData.Enabled = false;
            txtTennhom.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETENhonSanPham", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@manhom", txtManhom.Text);
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
                sql = "SELECT * FROM tbl_NhomSanPham";
                HienThi(sql);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                if (CheckTXT())
                {
                    sMa = txtManhom.Text;
                    cmd = new SqlCommand("ThemNhonSanPham", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manhom", txtManhom.Text);
                    cmd.Parameters.AddWithValue("@tennhom", txtTennhom.Text);
                    cmd.Parameters.AddWithValue("@makho", cbbKhohang.SelectedValue.ToString());
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
                else
                {
                    return;
                }
            }
            else if (Trangthai == "EDIT")
            {
                if (CheckTXT())
                {
                    cmd = new SqlCommand("EDITNhonSanPham", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manhom", txtManhom.Text);
                    cmd.Parameters.AddWithValue("@tennhom", txtTennhom.Text);
                    cmd.Parameters.AddWithValue("@makho", cbbKhohang.SelectedValue.ToString());
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
                else
                {
                    return;
                }
            }
            btnKhoiphuc_Click(sender, e);
        }

        private void btnKhoiphuc_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dgvData.Enabled = true;
            dgvData.CurrentCell = dgvData[0, 0];
            dgvData_SelectionChanged(sender, e);
            sql = "SELECT * FROM tbl_NhomSanPham";
            HienThi(sql);
        }
        #endregion


        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count > 0 && dgvData.SelectedRows.Count > 0)
            {
                int Index = dgvData.CurrentCell.RowIndex;
                txtManhom.Text = dgvData.Rows[Index].Cells[0].Value.ToString();
                txtTennhom.Text = dgvData.Rows[Index].Cells[1].Value.ToString();
                string macbbKhohang = dgvData.Rows[Index].Cells[2].Value.ToString();
                string sqlCBB = "SELECT * FROM tbl_KhoHang WHERE Makho= '" + macbbKhohang + "' ";
                cmd = new SqlCommand(sqlCBB, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cbbKhohang.Text = dr["Tenkho"].ToString();
                }

            }
            else
            {
                ClearTXT();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            sql = "SELECT Manhom AS 'Mã nhóm', Tennhom AS 'Tên nhóm', Makho AS 'Mã kho' FROM tbl_NhomSanPham  WHERE Makho = '" + txtTimkiem.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvData.DataSource = dt;

        }

        private void ckbLuachon_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbLuachon.Checked == true)
            {
                btnTimkiem.Enabled = true;
                txtTimkiem.Enabled = true;
            }
            else
            {
                btnTimkiem.Enabled = false;
                txtTimkiem.Enabled = false;
            }
        }


    }
}
