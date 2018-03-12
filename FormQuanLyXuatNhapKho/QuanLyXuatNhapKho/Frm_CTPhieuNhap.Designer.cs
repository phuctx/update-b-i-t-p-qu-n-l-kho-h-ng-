namespace QuanLyXuatNhapKho
{
    partial class Frm_CTPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbbNguoilapphieu = new System.Windows.Forms.ComboBox();
            this.cbbNCC = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbNhomsp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgaylapphieu = new System.Windows.Forms.DateTimePicker();
            this.txtSophieunhap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnKhoiphuc = new System.Windows.Forms.Button();
            this.btnCapnhatct = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtThanhtien = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.txtTenhanghoa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbMahanghoa = new System.Windows.Forms.ComboBox();
            this.txtDongianhap = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvPhieunhap = new System.Windows.Forms.DataGridView();
            this.colSophieunhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaylp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguoilp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.colMahang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenhanghoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDongianhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieunhap)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbbNguoilapphieu);
            this.groupBox5.Controls.Add(this.cbbNCC);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.cbbNhomsp);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.dtpNgaylapphieu);
            this.groupBox5.Controls.Add(this.txtSophieunhap);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtTongtien);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(348, 186);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông tin chung";
            // 
            // cbbNguoilapphieu
            // 
            this.cbbNguoilapphieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNguoilapphieu.FormattingEnabled = true;
            this.cbbNguoilapphieu.Location = new System.Drawing.Point(136, 102);
            this.cbbNguoilapphieu.Name = "cbbNguoilapphieu";
            this.cbbNguoilapphieu.Size = new System.Drawing.Size(168, 21);
            this.cbbNguoilapphieu.TabIndex = 21;
            // 
            // cbbNCC
            // 
            this.cbbNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNCC.FormattingEnabled = true;
            this.cbbNCC.Location = new System.Drawing.Point(136, 53);
            this.cbbNCC.Name = "cbbNCC";
            this.cbbNCC.Size = new System.Drawing.Size(168, 21);
            this.cbbNCC.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mã nhóm";
            // 
            // cbbNhomsp
            // 
            this.cbbNhomsp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNhomsp.FormattingEnabled = true;
            this.cbbNhomsp.Location = new System.Drawing.Point(136, 78);
            this.cbbNhomsp.Name = "cbbNhomsp";
            this.cbbNhomsp.Size = new System.Drawing.Size(168, 21);
            this.cbbNhomsp.TabIndex = 13;
            this.cbbNhomsp.SelectedIndexChanged += new System.EventHandler(this.cbbNhomsp_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ngày lập phiếu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "Mã NCC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số phiếu nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tổng tiền";
            // 
            // dtpNgaylapphieu
            // 
            this.dtpNgaylapphieu.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaylapphieu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaylapphieu.Location = new System.Drawing.Point(136, 129);
            this.dtpNgaylapphieu.Name = "dtpNgaylapphieu";
            this.dtpNgaylapphieu.Size = new System.Drawing.Size(168, 20);
            this.dtpNgaylapphieu.TabIndex = 18;
            // 
            // txtSophieunhap
            // 
            this.txtSophieunhap.Enabled = false;
            this.txtSophieunhap.Location = new System.Drawing.Point(136, 29);
            this.txtSophieunhap.Name = "txtSophieunhap";
            this.txtSophieunhap.Size = new System.Drawing.Size(168, 20);
            this.txtSophieunhap.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Người lập phiếu";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Enabled = false;
            this.txtTongtien.Location = new System.Drawing.Point(136, 155);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(168, 20);
            this.txtTongtien.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btnKhoiphuc);
            this.groupBox3.Controls.Add(this.btnCapnhatct);
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.txtThanhtien);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtSoluong);
            this.groupBox3.Controls.Add(this.txtTenhanghoa);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbbMahanghoa);
            this.groupBox3.Controls.Add(this.txtDongianhap);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(355, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(618, 186);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chi tiết";
            // 
            // btnKhoiphuc
            // 
            this.btnKhoiphuc.Location = new System.Drawing.Point(431, 144);
            this.btnKhoiphuc.Name = "btnKhoiphuc";
            this.btnKhoiphuc.Size = new System.Drawing.Size(75, 23);
            this.btnKhoiphuc.TabIndex = 4;
            this.btnKhoiphuc.Text = "Khôi phục";
            this.btnKhoiphuc.UseVisualStyleBackColor = true;
            this.btnKhoiphuc.Click += new System.EventHandler(this.btnKhoiphuc_Click);
            // 
            // btnCapnhatct
            // 
            this.btnCapnhatct.Location = new System.Drawing.Point(332, 85);
            this.btnCapnhatct.Name = "btnCapnhatct";
            this.btnCapnhatct.Size = new System.Drawing.Size(101, 23);
            this.btnCapnhatct.TabIndex = 28;
            this.btnCapnhatct.Text = "Cập nhật chi tiết";
            this.btnCapnhatct.UseVisualStyleBackColor = true;
            this.btnCapnhatct.Click += new System.EventHandler(this.btnCapnhatct_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(350, 144);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu lại";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(31, 144);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(254, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "Thành tiền";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(112, 144);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtThanhtien
            // 
            this.txtThanhtien.Enabled = false;
            this.txtThanhtien.Location = new System.Drawing.Point(332, 57);
            this.txtThanhtien.Name = "txtThanhtien";
            this.txtThanhtien.Size = new System.Drawing.Size(174, 20);
            this.txtThanhtien.TabIndex = 27;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(193, 144);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "Số lượng";
            // 
            // txtSoluong
            // 
            this.txtSoluong.Enabled = false;
            this.txtSoluong.Location = new System.Drawing.Point(110, 84);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(123, 20);
            this.txtSoluong.TabIndex = 25;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged);
            // 
            // txtTenhanghoa
            // 
            this.txtTenhanghoa.Enabled = false;
            this.txtTenhanghoa.Location = new System.Drawing.Point(332, 30);
            this.txtTenhanghoa.Name = "txtTenhanghoa";
            this.txtTenhanghoa.Size = new System.Drawing.Size(173, 20);
            this.txtTenhanghoa.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 19);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã hàng hóa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 19);
            this.label7.TabIndex = 21;
            this.label7.Text = "Đơn giá nhập";
            // 
            // cbbMahanghoa
            // 
            this.cbbMahanghoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMahanghoa.FormattingEnabled = true;
            this.cbbMahanghoa.Location = new System.Drawing.Point(110, 29);
            this.cbbMahanghoa.Name = "cbbMahanghoa";
            this.cbbMahanghoa.Size = new System.Drawing.Size(123, 21);
            this.cbbMahanghoa.TabIndex = 22;
            this.cbbMahanghoa.SelectedIndexChanged += new System.EventHandler(this.cbbMahanghoa_SelectedIndexChanged);
            // 
            // txtDongianhap
            // 
            this.txtDongianhap.Enabled = false;
            this.txtDongianhap.Location = new System.Drawing.Point(110, 57);
            this.txtDongianhap.Name = "txtDongianhap";
            this.txtDongianhap.Size = new System.Drawing.Size(123, 20);
            this.txtDongianhap.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(976, 374);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(970, 355);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvPhieunhap);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(348, 355);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Thông tin phiếu nhập";
            // 
            // dgvPhieunhap
            // 
            this.dgvPhieunhap.AllowUserToAddRows = false;
            this.dgvPhieunhap.AllowUserToDeleteRows = false;
            this.dgvPhieunhap.AllowUserToOrderColumns = true;
            this.dgvPhieunhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieunhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSophieunhap,
            this.colManhom,
            this.colMaNCC,
            this.colNgaylp,
            this.colNguoilp,
            this.colTongtien});
            this.dgvPhieunhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieunhap.Location = new System.Drawing.Point(3, 16);
            this.dgvPhieunhap.Name = "dgvPhieunhap";
            this.dgvPhieunhap.ReadOnly = true;
            this.dgvPhieunhap.Size = new System.Drawing.Size(342, 336);
            this.dgvPhieunhap.TabIndex = 0;
            this.dgvPhieunhap.SelectionChanged += new System.EventHandler(this.dgvPhieunhap_SelectionChanged);
            // 
            // colSophieunhap
            // 
            this.colSophieunhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSophieunhap.DataPropertyName = "Sophieunhap";
            this.colSophieunhap.FillWeight = 120F;
            this.colSophieunhap.HeaderText = "Số phiếu nhập";
            this.colSophieunhap.Name = "colSophieunhap";
            this.colSophieunhap.ReadOnly = true;
            this.colSophieunhap.Width = 115;
            // 
            // colManhom
            // 
            this.colManhom.DataPropertyName = "Manhom";
            this.colManhom.HeaderText = "Mã nhóm";
            this.colManhom.Name = "colManhom";
            this.colManhom.ReadOnly = true;
            // 
            // colMaNCC
            // 
            this.colMaNCC.DataPropertyName = "MaNCC";
            this.colMaNCC.HeaderText = "Mã NCC";
            this.colMaNCC.Name = "colMaNCC";
            this.colMaNCC.ReadOnly = true;
            // 
            // colNgaylp
            // 
            this.colNgaylp.DataPropertyName = "Ngaylapphieu";
            this.colNgaylp.HeaderText = "Ngày lập phiếu";
            this.colNgaylp.Name = "colNgaylp";
            this.colNgaylp.ReadOnly = true;
            this.colNgaylp.Width = 115;
            // 
            // colNguoilp
            // 
            this.colNguoilp.DataPropertyName = "Nguoilapphieu";
            this.colNguoilp.HeaderText = "Người lập phiếu";
            this.colNguoilp.Name = "colNguoilp";
            this.colNguoilp.ReadOnly = true;
            this.colNguoilp.Width = 115;
            // 
            // colTongtien
            // 
            this.colTongtien.DataPropertyName = "Tongtien";
            this.colTongtien.HeaderText = "Tổng tiền";
            this.colTongtien.Name = "colTongtien";
            this.colTongtien.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvData);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(618, 355);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chi tiết phiếu nhập";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMahang,
            this.ColTenhanghoa,
            this.ColDongianhap,
            this.ColSoluong,
            this.ColThanhtien});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 16);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(612, 336);
            this.dgvData.TabIndex = 2;
            // 
            // colMahang
            // 
            this.colMahang.DataPropertyName = "Mahanghoa";
            this.colMahang.HeaderText = "Mã hàng hóa";
            this.colMahang.Name = "colMahang";
            this.colMahang.ReadOnly = true;
            // 
            // ColTenhanghoa
            // 
            this.ColTenhanghoa.DataPropertyName = "Tenhanghoa";
            this.ColTenhanghoa.HeaderText = "Tên hàng hóa";
            this.ColTenhanghoa.Name = "ColTenhanghoa";
            this.ColTenhanghoa.ReadOnly = true;
            this.ColTenhanghoa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTenhanghoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDongianhap
            // 
            this.ColDongianhap.DataPropertyName = "Dongianhap";
            this.ColDongianhap.HeaderText = "Đơn giá nhập";
            this.ColDongianhap.Name = "ColDongianhap";
            this.ColDongianhap.ReadOnly = true;
            // 
            // ColSoluong
            // 
            this.ColSoluong.DataPropertyName = "Soluong";
            this.ColSoluong.HeaderText = "Số lượng";
            this.ColSoluong.Name = "ColSoluong";
            this.ColSoluong.ReadOnly = true;
            // 
            // ColThanhtien
            // 
            this.ColThanhtien.DataPropertyName = "Thanhtien";
            this.ColThanhtien.HeaderText = "Thành tiền";
            this.ColThanhtien.Name = "ColThanhtien";
            this.ColThanhtien.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(239, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 19);
            this.label11.TabIndex = 29;
            this.label11.Text = "Tên hàng hóa";
            // 
            // Frm_CTPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 579);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Frm_CTPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHIẾU NHẬP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_CTPhieuNhap_FormClosing);
            this.Load += new System.EventHandler(this.Frm_CTPhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieunhap)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKhoiphuc;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbbNhomsp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSophieunhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgaylapphieu;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbNCC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtThanhtien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.TextBox txtTenhanghoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbMahanghoa;
        private System.Windows.Forms.TextBox txtDongianhap;
        private System.Windows.Forms.ComboBox cbbNguoilapphieu;
        private System.Windows.Forms.Button btnCapnhatct;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMahang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenhanghoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDongianhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSoluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThanhtien;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvPhieunhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSophieunhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaylp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguoilp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongtien;
        private System.Windows.Forms.Label label11;
    }
}