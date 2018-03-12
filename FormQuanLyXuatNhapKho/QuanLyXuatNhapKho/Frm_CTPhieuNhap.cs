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
    public partial class Frm_CTPhieuNhap : Form
    {
        private string Trangthai = "LOAD";
        private String connecttionString = @"Data Source=DESKTOP-R9UI5U6\SQLEXPRESS;Initial Catalog=Quan_Ly_Xuat_Nhap_Kho1;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt = new DataTable();
        private DataTable dgvcapnhat = new DataTable();
        DataTable dgv;
        private string Ma = "";
        private string sql = "";
        public Frm_CTPhieuNhap()
        {
            InitializeComponent();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieunhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvPhieunhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //public Frm_CTPhieuNhap(string sSophieunhap, string sTrangthai)
        //{
        //    InitializeComponent();
        //    Ma = sSophieunhap;
        //    Trangthai = sTrangthai;
        //    dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //}

        private void Frm_CTPhieuNhap_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connecttionString);
            try
            {
                conn.Open();
                ClearTXT();
                TrangThaiTXT(false);
                TrangThaiButton(true);
                cbbNCC.DataSource = LoadComBoBox("SELECT * FROM tbl_NhaCungCap");
                cbbNCC.DisplayMember = "TenNCC";
                cbbNCC.ValueMember = "MaNCC";

                cbbNhomsp.DataSource = LoadComBoBox("SELECT * FROM tbl_NhomSanPham");
                cbbNhomsp.DisplayMember = "Tennhom";
                cbbNhomsp.ValueMember = "Manhom";

                cbbNguoilapphieu.DataSource = LoadComBoBox("SELECT * FROM tbl_NhanVienKho");
                cbbNguoilapphieu.DisplayMember = "TenNV";
                cbbNguoilapphieu.ValueMember = "MaNV";


                cbbMahanghoa.DataSource = LoadComBoBox("SELECT Mahanghoa FROM tbl_HangHoa ");
                cbbMahanghoa.DisplayMember = "Mahanghoa";
                cbbMahanghoa.ValueMember = "Mahanghoa";

                sql = "SELECT * FROM tbl_PhieuNhap";
                HienThi(sql, dgvPhieunhap);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Frm_CTPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
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

            btnCapnhatct.Enabled = !b;
        }
        private void ClearTXT()
        {
            txtSophieunhap.Text = "";
            cbbNguoilapphieu.SelectedIndex = -1;
            txtTongtien.Text = "";
            dtpNgaylapphieu.Text = "";
            txtTenhanghoa.Text = "";
            txtDongianhap.Text = "";
            txtSoluong.Text = "";
            txtThanhtien.Text = "";
            cbbNCC.SelectedIndex = -1;
            cbbNhomsp.SelectedIndex = -1;
            cbbMahanghoa.SelectedIndex = -1;



        }
        private void TrangThaiTXT(bool b)
        {
            cbbNguoilapphieu.Enabled = b;
            dtpNgaylapphieu.Enabled = b;
            cbbNCC.Enabled = b;
            cbbNhomsp.Enabled = b;
            cbbMahanghoa.Enabled = b;
            txtDongianhap.Enabled = b;
            txtSoluong.Enabled = b;

        }
        private void HienThi(string sql, DataGridView dgv)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv.DataSource = dt;
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
            count = dgvPhieunhap.Rows.Count; //lấy số dòng của dgv.
            int chuoiSo = 0;
            string ChuoiMa = Convert.ToString(dgvPhieunhap.Rows[count - 1].Cells[0].Value);
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

        private bool CheckTXT()
        {
            //bool kt = true;
            //if (txtManhom.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập mã nhóm !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    kt = false;
            //    txtManhom.Focus();
            //    txtManhom.SelectAll();
            //    return kt;
            //}
            //else if (txtTennhom.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập tên nhóm !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    kt = false;
            //    txtTennhom.Focus();
            //    txtTennhom.SelectAll();
            //    return kt;
            //}
            //else if (cbbKhohang.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập kho hàng !", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    kt = false;
            //    cbbKhohang.Focus();
            //    cbbKhohang.SelectAll();
            //    return kt;
            //}
            return true;
        }
        #endregion

        #region[Các hàm dùng cho datagridview]
        private DataTable TaoBang()
        {
            DataTable tableDGV = new DataTable();
            tableDGV.Columns.Add("Mahanghoa");
            tableDGV.Columns.Add("Tenhanghoa");
            tableDGV.Columns.Add("Dongianhap");
            tableDGV.Columns.Add("Soluong");
            tableDGV.Columns.Add("Thanhtien");

            return tableDGV;
        }
        private void HienthiDGV(string ma)
        {
            dgv = TaoBang();
            string sSophieunhap = "";
            string sMahanghoa = "";
            string sSanpham = "";
            double dDongianhap = 0;
            int iSoluong = 0;
            double dThanhtien = 0;
            string sql = "SELECT * FROM tbl_ChiTietPhieuNhap WHERE Sophieunhap = '" + ma + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtCTPhieunhap = new DataTable();
            da.Fill(dtCTPhieunhap);
            foreach (DataRow dr in dtCTPhieunhap.Rows)
            {
                sSophieunhap = dr[0].ToString();
                sMahanghoa = dr[1].ToString();
                dDongianhap = Convert.ToDouble(dr[2].ToString());
                iSoluong = Convert.ToInt32(dr[3].ToString());
                string sql1 = "SELECT * FROM tbl_HangHoa WHERE Mahanghoa = '" + sMahanghoa + "' ";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dtHanghoa = new DataTable();
                da1.Fill(dtHanghoa);
                if (dtHanghoa.Rows.Count > 0)
                {
                    sSanpham = dtHanghoa.Rows[0][1].ToString();
                }
                dThanhtien = dDongianhap * iSoluong;
                dgv.Rows.Add(sMahanghoa, sSanpham, dDongianhap, iSoluong, dThanhtien);
            }
            dgvData.DataSource = dgv;

        }
        private void HienthiThongtinChung(string ma)
        {
            string sql = "SELECT * FROM tbl_PhieuNhap WHERE Sophieunhap = '" + ma + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtPhieunhap = new DataTable();
            da.Fill(dtPhieunhap);
            foreach (DataRow dr in dtPhieunhap.Rows)
            {
                txtSophieunhap.Text = dr[0].ToString();
                dtpNgaylapphieu.Text = dr[1].ToString();
                string sql3 = "SELECT * FROM tbl_NhanVienKho WHERE MaNV = '" + dr[2].ToString() + "' ";
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataTable dtDulieu = new DataTable();
                da3.Fill(dtDulieu);
                if (dtDulieu.Rows.Count > 0)
                {
                    cbbNguoilapphieu.Text = dtDulieu.Rows[0][1].ToString();
                }
                txtTongtien.Text = dr[3].ToString();

                string sql1 = "SELECT * FROM tbl_NhomSanPham WHERE Manhom = '" + dr[4].ToString() + "' ";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                dtDulieu = new DataTable();
                da1.Fill(dtDulieu);
                if (dtDulieu.Rows.Count > 0)
                {
                    cbbNhomsp.Text = dtDulieu.Rows[0][1].ToString();


                }

                string sql2 = "SELECT * FROM tbl_NhaCungCap WHERE MaNCC = '" + dr[5].ToString() + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                dtDulieu = new DataTable();
                da2.Fill(dtDulieu);
                if (dtDulieu.Rows.Count > 0)
                {
                    cbbNCC.Text = dtDulieu.Rows[0][1].ToString();
                }
                // load cbb mahanhhoa.
                cbbMahanghoa.DataSource = LoadComBoBox("SELECT Mahanghoa FROM tbl_HangHoa WHERE Manhom = '"
                    + dr[4].ToString() + "' ");
                cbbMahanghoa.DisplayMember = "Mahanghoa";
                cbbMahanghoa.ValueMember = "Mahanghoa";
            }
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
        internal static DataGridViewComboBoxColumn CreateComboboxColumn(String ColumnName, String HeaderText, DataTable pTable, String ColumnNameDisplay)
        {
            DataGridViewComboBoxColumn objColumn = new DataGridViewComboBoxColumn();
            objColumn.Name = ColumnName;
            objColumn.HeaderText = HeaderText;
            objColumn.DataPropertyName = ColumnName;
            objColumn.DropDownWidth = 160;
            objColumn.Width = 100;
            objColumn.MaxDropDownItems = 10;
            objColumn.FlatStyle = FlatStyle.Standard;
            objColumn.DataSource = pTable;
            objColumn.DisplayMember = ColumnNameDisplay;
            return objColumn;
        }
        #endregion

        #region[Các BUTTON]
        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = "ADD";
            ClearTXT();
            TrangThaiTXT(true);
            TrangThaiButton(false);
            cbbNguoilapphieu.Focus();
            txtSophieunhap.Text = SinhMaTuDong("spn");
            dgvData.DataSource = null;
            dgvPhieunhap.Enabled = false;
            dgvData.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "EDIT";
            TrangThaiTXT(true);
            TrangThaiButton(false);
            dgvPhieunhap.Enabled = false;
            dgvData.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                //xóa dữ liệu ở bảng chi tiết phiếu nhập ứng vs số phiếu nhập hiện tại.
                cmd = new SqlCommand("DELETECTPhieuNhapTheoSPN", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                //xóa dữ liệu ở bảng phiếu nhập ứng vs số phiếu nhập hiện tại.
                cmd = new SqlCommand("DELETEPhieuNhap", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

                // load lại dữ liệu trong datagridview.
                btnKhoiphuc_Click(sender, e);
            }
        }

        private void btnCapnhatct_Click(object sender, EventArgs e)
        {
            double dTongtien = 0;
            string sMahanghoa = cbbMahanghoa.SelectedValue.ToString();
            string sTenhanghoa = txtTenhanghoa.Text;
            double dDongianhap =0;
            double.TryParse(txtDongianhap.Text, out dDongianhap);
            int iSoluong = 0;
            int.TryParse(txtSoluong.Text,out iSoluong);
            double dThanhtien = dDongianhap * iSoluong;
            for (int i = 0; i < dgv.Rows.Count; i++ )
            {
                if (sMahanghoa == dgv.Rows[i][0].ToString())
                {
                    dgv.Rows[i].Delete();
                }
            }
            if(iSoluong>0 && dDongianhap >0)
            {
                dgv.Rows.Add(sMahanghoa, sTenhanghoa, dDongianhap.ToString(), iSoluong.ToString(), dThanhtien.ToString());
                for (int i = 0; i <= dgvData.Rows.Count - 1; i++)
                {
                    dTongtien += Convert.ToDouble(dgvData.Rows[i].Cells[4].Value.ToString());
                }
                txtTongtien.Text = dTongtien.ToString();
            }


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sMa = "";
            if (Trangthai == "ADD")
            {
                if (CheckTXT())
                {
                    // thêm mới vào bảng phiếu nhập
                    sMa = txtSophieunhap.Text;
                    double dTongtien = 0;
                    double.TryParse(txtTongtien.Text.ToString(), out dTongtien);
                    cmd = new SqlCommand("ThemPhieuNhap", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                    cmd.Parameters.AddWithValue("@ngaylapphieu", dtpNgaylapphieu.Value);
                    cmd.Parameters.AddWithValue("@nguoilapphieu", cbbNguoilapphieu.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@mancc", cbbNCC.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@manhom", cbbNhomsp.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@tongtien", dTongtien);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    // Thêm mới vào chi tiết phiếu nhập.
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        double dDongianhap = 0;
                        double.TryParse(dgvData.Rows[i].Cells[2].Value.ToString(), out dDongianhap);
                        int iSoluong = 0;
                        int.TryParse(dgvData.Rows[i].Cells[3].Value.ToString(), out iSoluong);
                        cmd = new SqlCommand("ThemCTPhieuNhap", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                        cmd.Parameters.AddWithValue("@mahanghoa", dgvData.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@dongianhap", dDongianhap);
                        cmd.Parameters.AddWithValue("@soluong", iSoluong);
                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            // thêm không thành công xóa dữ liệu ở bảng chi tiết phiếu nhập ứng vs số phiếu nhập hiện tại.
                            cmd = new SqlCommand("DELETECTPhieuNhapTheoSPN", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                            cmd.ExecuteNonQuery();


                            // thêm không thành công xóa dữ liệu ở bảng phiếu nhập ứng vs số phiếu nhập hiện tại.
                            cmd = new SqlCommand("DELETEPhieuNhap", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
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
                    // update vào bảng phiếu nhập
                    sMa = txtSophieunhap.Text;
                    double dTongtien = 0;
                    double.TryParse(txtTongtien.Text.ToString(), out dTongtien);
                    cmd = new SqlCommand("EDITPhieuNhap", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                    cmd.Parameters.AddWithValue("@ngaylapphieu", dtpNgaylapphieu.Value);
                    cmd.Parameters.AddWithValue("@nguoilapphieu", cbbNguoilapphieu.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@mancc", cbbNCC.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@manhom", cbbNhomsp.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@tongtien", dTongtien);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    // xóa chi tiết chi tiết phiếu nhập ứng vs số xóa đơn hiện tại.
                    cmd = new SqlCommand("DELETECTPhieuNhapTheoSPN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        double dDongianhap = 0;
                        double.TryParse(dgvData.Rows[i].Cells[2].Value.ToString(), out dDongianhap);
                        int iSoluong = 0;
                        int.TryParse(dgvData.Rows[i].Cells[3].Value.ToString(), out iSoluong);
                        cmd = new SqlCommand("ThemCTPhieuNhap", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                        cmd.Parameters.AddWithValue("@mahanghoa", dgvData.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@dongianhap", dDongianhap);
                        cmd.Parameters.AddWithValue("@soluong", iSoluong);
                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            // thêm không thành công xóa dữ liệu ở bảng chi tiết phiếu nhập ứng vs số phiếu nhập hiện tại.
                            cmd = new SqlCommand("DELETECTPhieuNhapTheoSPN", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                            cmd.ExecuteNonQuery();


                            // thêm không thành công xóa dữ liệu ở bảng phiếu nhập ứng vs số phiếu nhập hiện tại.
                            cmd = new SqlCommand("DELETEPhieuNhap", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sophieunhap", txtSophieunhap.Text.ToString());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Lỗi " + ex, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            btnKhoiphuc_Click(sender, e);
            MessageBox.Show("Cập nhật dữ liệu thành công !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKhoiphuc_Click(object sender, EventArgs e)
        {
            TrangThaiTXT(false);
            TrangThaiButton(true);
            dgvData.Enabled = false;
            ClearTXT();
            sql = "SELECT * FROM tbl_PhieuNhap";
            HienThi(sql, dgvPhieunhap);
            dgvPhieunhap.Enabled = true;
            dgvData.Enabled = true;

        }
        #endregion

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count > 0 && dgvData.SelectedRows.Count > 0)
            {
                int Index = dgvData.CurrentCell.RowIndex;
                cbbMahanghoa.Text = dgvData.Rows[Index].Cells[0].Value.ToString();
                txtTenhanghoa.Text = dgvData.Rows[Index].Cells[1].Value.ToString();
                txtDongianhap.Text = dgvData.Rows[Index].Cells[2].Value.ToString();
                txtSoluong.Text = dgvData.Rows[Index].Cells[3].Value.ToString();
                txtThanhtien.Text = dgvData.Rows[Index].Cells[4].Value.ToString();
            }
            else
            {
                txtTenhanghoa.Text = "";
                txtDongianhap.Text = "";
                txtSoluong.Text = "";
                txtThanhtien.Text = "";
                cbbMahanghoa.SelectedIndex = -1;
            }
        }

        private void cbbNhomsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNhomsp.SelectedIndex > -1 && Trangthai != "LOAD")
            {
                string smahh = cbbNhomsp.SelectedValue.ToString();
                cbbMahanghoa.DataSource = LoadComBoBox("SELECT Mahanghoa FROM tbl_HangHoa WHERE Manhom = '"
                    + smahh + "' ");
                cbbMahanghoa.DisplayMember = "Mahanghoa";
                cbbMahanghoa.ValueMember = "Mahanghoa";
                cbbMahanghoa.SelectedIndex = -1;
                dgv = TaoBang();
                dgvData.DataSource = dgv;
            }
            else if(cbbNhomsp.SelectedIndex == -1)
            {
                cbbMahanghoa.DataSource = null;
                cbbMahanghoa.DisplayMember = "Mahanghoa";
                cbbMahanghoa.ValueMember = "Mahanghoa";
                dgv = TaoBang();
                dgvData.DataSource = dgv;
            }

        }

        private void cbbMahanghoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMahanghoa.SelectedIndex > -1 && Trangthai != "LOAD")
            {
                string smahh = cbbMahanghoa.SelectedValue.ToString();
                string sTenhanghoa = "";
                double dDongia = 0;
                string sql1 = "SELECT * FROM tbl_HangHoa WHERE Mahanghoa = '" + smahh + "' ";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dtHanghoa = new DataTable();
                da1.Fill(dtHanghoa);
                if (dtHanghoa.Rows.Count > 0)
                {
                    sTenhanghoa = dtHanghoa.Rows[0][1].ToString();
                    double.TryParse(dtHanghoa.Rows[0][3].ToString(), out dDongia);
                }
                txtTenhanghoa.Text = sTenhanghoa;
                txtDongianhap.Text = dDongia.ToString();
                txtSoluong.Text = "";
            }
            else if(cbbMahanghoa.SelectedIndex == -1)
            {
                txtTenhanghoa.Text = "";
                txtDongianhap.Text = "";
                txtSoluong.Text = "";
                txtThanhtien.Text = "";
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoluong.Text.Trim() != "" && txtDongianhap.Text.Trim() != "" && Trangthai != "LOAD")
            {
                int iSoluong = Convert.ToInt32(txtSoluong.Text);
                double dDongia = Convert.ToDouble(txtDongianhap.Text);
                txtThanhtien.Text = (iSoluong * dDongia).ToString();
            }
            else
            {
                txtThanhtien.Text = "";
            }

        }

        private void dgvPhieunhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieunhap.SelectedCells.Count > 0 && dgvPhieunhap.SelectedRows.Count > 0)
            {
                int Index = dgvPhieunhap.CurrentCell.RowIndex;
                txtSophieunhap.Text = dgvPhieunhap.Rows[Index].Cells[0].Value.ToString();
                string sCbbNhomsp = dgvPhieunhap.Rows[Index].Cells[1].Value.ToString();
                string sCbbNCC = dgvPhieunhap.Rows[Index].Cells[2].Value.ToString();
                string sCbbNguoilap = dgvPhieunhap.Rows[Index].Cells[3].Value.ToString();
                dtpNgaylapphieu.Text = dgvPhieunhap.Rows[Index].Cells[4].Value.ToString();
                txtTongtien.Text = dgvPhieunhap.Rows[Index].Cells[5].Value.ToString();

                string sqlCBB = "SELECT * FROM tbl_NhomSanPham WHERE Manhom= '" + sCbbNhomsp + "' ";
                cmd = new SqlCommand(sqlCBB, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cbbNhomsp.Text = dr["Tennhom"].ToString();
                }

                sqlCBB = "SELECT * FROM tbl_NhaCungCap WHERE MaNCC= '" + sCbbNCC + "' ";
                cmd = new SqlCommand(sqlCBB, conn);
                da1 = new SqlDataAdapter(cmd);
                dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cbbNCC.Text = dr["TenNCC"].ToString();
                }

                sqlCBB = "SELECT * FROM tbl_NhanVienKho WHERE MaNV= '" + sCbbNguoilap + "' ";
                cmd = new SqlCommand(sqlCBB, conn);
                da1 = new SqlDataAdapter(cmd);
                dtCBB = new DataTable();
                da1.Fill(dtCBB);
                foreach (DataRow dr in dtCBB.Rows)
                {
                    cbbNguoilapphieu.Text = dr["TenNV"].ToString();
                }
                HienthiDGV(txtSophieunhap.Text);
                dgvData_SelectionChanged(sender, e);
            }
            else
            {
                ClearTXT();
            }
        }




    }
}
