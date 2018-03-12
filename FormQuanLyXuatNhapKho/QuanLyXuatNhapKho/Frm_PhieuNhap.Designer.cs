namespace QuanLyXuatNhapKho
{
    partial class Frm_PhieuNhap
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tHÊMMỚIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sỬAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xÓAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xEMTHÔNGTINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 40);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(671, 384);
            this.dgvData.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tHÊMMỚIToolStripMenuItem,
            this.sỬAToolStripMenuItem,
            this.xÓAToolStripMenuItem,
            this.xEMTHÔNGTINToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tHÊMMỚIToolStripMenuItem
            // 
            this.tHÊMMỚIToolStripMenuItem.Name = "tHÊMMỚIToolStripMenuItem";
            this.tHÊMMỚIToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.tHÊMMỚIToolStripMenuItem.Text = "THÊM MỚI";
            this.tHÊMMỚIToolStripMenuItem.Click += new System.EventHandler(this.tHÊMMỚIToolStripMenuItem_Click);
            // 
            // sỬAToolStripMenuItem
            // 
            this.sỬAToolStripMenuItem.Name = "sỬAToolStripMenuItem";
            this.sỬAToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.sỬAToolStripMenuItem.Text = "SỬA";
            this.sỬAToolStripMenuItem.Click += new System.EventHandler(this.sỬAToolStripMenuItem_Click);
            // 
            // xÓAToolStripMenuItem
            // 
            this.xÓAToolStripMenuItem.Name = "xÓAToolStripMenuItem";
            this.xÓAToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.xÓAToolStripMenuItem.Text = "XÓA";
            this.xÓAToolStripMenuItem.Click += new System.EventHandler(this.xÓAToolStripMenuItem_Click);
            // 
            // xEMTHÔNGTINToolStripMenuItem
            // 
            this.xEMTHÔNGTINToolStripMenuItem.Name = "xEMTHÔNGTINToolStripMenuItem";
            this.xEMTHÔNGTINToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.xEMTHÔNGTINToolStripMenuItem.Text = "XEM THÔNG TIN";
            this.xEMTHÔNGTINToolStripMenuItem.Click += new System.EventHandler(this.xEMTHÔNGTINToolStripMenuItem_Click);
            // 
            // Frm_PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 427);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Frm_PhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHIẾU NHẬP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_PhieuNhap_FormClosing);
            this.Load += new System.EventHandler(this.Frm_PhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ToolStripMenuItem tHÊMMỚIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sỬAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xÓAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xEMTHÔNGTINToolStripMenuItem;
    }
}