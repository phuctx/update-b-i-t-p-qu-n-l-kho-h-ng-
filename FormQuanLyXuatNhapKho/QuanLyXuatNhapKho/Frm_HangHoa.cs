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
    public partial class Frm_HangHoa : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-R9UI5U6\SQLEXPRESS;Initial Catalog=Quan_Ly_Xuat_Nhap_Kho1;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;
        private string sql = "";
        public Frm_HangHoa()
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
                sql = "SELECT * FROM tbl_HangHoa";
                HienThi(sql);
                cbbNhomsp.DataSource = LoadComBoBox("SELECT * FROM tbl_NhomSanPham");
                cbbNhomsp.DisplayMember = "Tennhom";
                cbbNhomsp.ValueMember = "Manhom";
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
            txtMahanghoa.Text = "";
            txtTenhanghoa.Text = "";
            txtDongia.Text = "";
            txtDonvitinh.Text = "";
            cbbNhomsp.SelectedIndex = -1;
        }
        private void TrangThaiTXT(bool b)
        {
            txtTenhanghoa.Enabled = b;
            txtDongia.Enabled = b;
            txtDonvitinh.Enabled = b;
            cbbNhomsp.Enabled = b;

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
            //if (txtMahanghoa.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập mã nhóm !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    kt = false;
            //    txtMahanghoa.Focus();
            //    txtMahanghoa.SelectAll();
            //    return kt;
            //}
            //else if (txtTenhanghoa.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập tên nhóm !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    kt = false;
            //    txtTenhanghoa.Focus();
            //    txtTenhanghoa.SelectAll();
            //    return kt;
            //}
            //else if (cbbNhomsp.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập kho hàng !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    kt = false;
            //    cbbNhomsp.Focus();
            //    cbbNhomsp.SelectAll();
            //    return kt;
            //}
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
            txtMahanghoa.Text = SinhMaTuDong("sp");
            txtTenhanghoa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvData.Enabled = false;
            txtTenhanghoa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETEHangHoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mahh", txtMahanghoa.Text);
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
                sql = "SELECT * FROM tbl_HangHoa";
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
                    sMa = txtMahanghoa.Text;
                    cmd = new SqlCommand("ThemHangHoa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mahh", txtMahanghoa.Text);
                    cmd.Parameters.AddWithValue("@tennhh", txtTenhanghoa.Text);
                    cmd.Parameters.AddWithValue("@dongia", Convert.ToDouble(txtDongia.Text));
                    cmd.Parameters.AddWithValue("@donvitinh", txtDonvitinh.Text);
                    cmd.Parameters.AddWithValue("@manhom", cbbNhomsp.SelectedValue.ToString());
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
                    cmd = new SqlCommand("EDITHangHoa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mahh", txtMahanghoa.Text);
                    cmd.Parameters.AddWithValue("@tennhh", txtTenhanghoa.Text);
                    cmd.Parameters.AddWithValue("@dongia", Convert.ToDouble(txtDongia.Text));
                    cmd.Parameters.AddWithValue("@donvitinh", txtDonvitinh.Text);
                    cmd.Parameters.AddWithValue("@manhom", cbbNhomsp.SelectedValue.ToString());
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
            sql = "SELECT * FROM tbl_HangHoa";
            HienThi(sql);
        }
        #endregion


        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count > 0 && dgvData.SelectedRows.Count > 0)
            {
                int Index = dgvData.CurrentCell.RowIndex;
                txtMahanghoa.Text = dgvData.Rows[Index].Cells[0].Value.ToString();
                txtTenhanghoa.Text = dgvData.Rows[Index].Cells[1].Value.ToString();
                txtDonvitinh.Text = dgvData.Rows[Index].Cells[2].Value.ToString();
                txtDongia.Text = dgvData.Rows[Index].Cells[3].Value.ToString();
                string macbbNhomsp = dgvData.Rows[Index].Cells[4].Value.ToString();
                string sqlCBB = "SELECT * FROM tbl_NhomSanPham WHERE Manhom= '" + macbbNhomsp + "' ";
                cmd = new SqlCommand(sqlCBB, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cbbNhomsp.Text = dr["Tennhom"].ToString();
                }

            }
            else
            {
                ClearTXT();
            }
        }

    }
}
