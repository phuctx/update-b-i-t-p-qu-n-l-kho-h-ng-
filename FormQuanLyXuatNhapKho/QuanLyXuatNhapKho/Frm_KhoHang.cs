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

//trỏ đến đòng i
//dgvData.CurrentCell = dgvData[0, i];
//dataGV_SelectionChanged(sender, e);
//dgvData.Rows[i].Selected = true;



namespace QuanLyXuatNhapKho
{
    public partial class Frm_KhoHang : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-R9UI5U6\SQLEXPRESS;Initial Catalog=Quan_Ly_Xuat_Nhap_Kho1;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private string sql = "";
        public Frm_KhoHang()
        {
            InitializeComponent();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Frm_KhoHang_Load(object sender, EventArgs e)
        {
            TrangThaiButton(true);
            TrangThaiTXT(false);
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                sql = "SELECT * FROM tbl_KhoHang";
                HienThi(sql);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            // xóa lựa chọn dòng trong datagridview.
            //dgvData.ClearSelection();


        }


        private void Frm_KhoHang_FormClosing(object sender, FormClosingEventArgs e)
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
            txtMakho.Text = "";
            txtTenkho.Text = "";
        }
        private void TrangThaiTXT(bool b)
        {
            txtTenkho.Enabled = b;
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
            string Matusinh ="";
            int count = 0;
            count = dgvData.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvData.Rows[count - 2].Cells[0].Value);
            chuoiSo = Convert.ToInt32(ChuoiMa.Replace(ma, ""));
            if (chuoiSo + 1 < 10)
            {
                Matusinh = ma + "00" + (chuoiSo+1).ToString();
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
            dgvData.Enabled = false;
            txtMakho.Text = SinhMaTuDong("mk");
            txtTenkho.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            txtTenkho.Enabled = true;
            TrangThaiButton(false);
            dgvData.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                cmd = new SqlCommand("DELETEKhoHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makho", txtMakho.Text);
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
                sql = "SELECT Makho AS 'Mã kho', Tenkho AS Tên Kho FROM tbl_KhoHang";
                HienThi(sql);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMakho = "";
            if (Trangthai == "ADD")
            {
                // Kiểm tra xem mã đã có chưa trước khi thêm.
                sMakho = txtMakho.Text;
                sql = "SELECT * FROM tbl_KhoHang WHERE Makho = '" + sMakho +"'";
                if (KiemTraTrungDL(sql))
                {
                    MessageBox.Show("Mã kho đã tồn tại !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMakho.Focus();
                    txtMakho.SelectAll();
                    return;
                }
                // lấy dữa liệu từ text để lưu vào csdl.
                cmd = new SqlCommand("ThemKhoHang",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makho", txtMakho.Text);
                cmd.Parameters.AddWithValue("@tenkho", txtTenkho.Text);
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
                cmd = new SqlCommand("EDITKhoHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@makho", txtMakho.Text);
                cmd.Parameters.AddWithValue("@tenkho", txtTenkho.Text);
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
            //TrangThaiTXT(false);
            //TrangThaiButton(true);
            //dgvData.Enabled = true;
            //cmd = new SqlCommand("SELECT Makho AS 'Mã kho', Tenkho AS Tên Kho FROM tbl_KhoHang", conn);
            //da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            ////DataRowView drv = (DataRowView)dgvData.;
            //dgvData.DataSource = dt;

        }

        private void btnKhoiphuc_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dgvData.Enabled = true;
            dgvData.CurrentCell = dgvData[0, 0];
            //dgvData.Rows[0].Selected = true;
            dataGV_SelectionChanged(sender, e);
            sql = "SELECT Makho AS 'Mã kho', Tenkho AS 'Tên Kho' FROM tbl_KhoHang";
            HienThi(sql);

        }
        #endregion

        private void dataGV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count > 0 && dgvData.SelectedRows.Count > 0)
            {
                int Index = dgvData.CurrentCell.RowIndex;
                txtMakho.Text = dgvData.Rows[Index].Cells[0].Value.ToString();
                txtTenkho.Text = dgvData.Rows[Index].Cells[1].Value.ToString();
            }
            else
            {
                txtMakho.Text = "";
                txtTenkho.Text = "";
            }

        }


    }
}
