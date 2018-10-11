namespace QuanLySieuThi
{
    partial class frmHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tất cả loại hàng hóa");
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGiamSoLuong = new DevComponents.DotNetBar.ButtonX();
            this.btnTangSoLuong = new DevComponents.DotNetBar.ButtonX();
            this.btnXoaHangTrongGio = new DevComponents.DotNetBar.ButtonX();
            this.numericGiam = new System.Windows.Forms.NumericUpDown();
            this.numericTang = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTienTraLai = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTienKhachDua = new System.Windows.Forms.ComboBox();
            this.txtTongGiaTriGioHang = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPhanTramGiamGia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTienHang = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstGioHang = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemHangHoaVaoGio = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.autoCompleteTextTenHangHoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewHangHoa = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaHangHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHangHoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.numericThem = new System.Windows.Forms.NumericUpDown();
            this.cbbKhachHang = new System.Windows.Forms.ComboBox();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGiam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTang)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGiamSoLuong);
            this.panel1.Controls.Add(this.btnTangSoLuong);
            this.panel1.Controls.Add(this.btnXoaHangTrongGio);
            this.panel1.Controls.Add(this.numericGiam);
            this.panel1.Controls.Add(this.numericTang);
            this.panel1.Location = new System.Drawing.Point(521, 278);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 130);
            this.panel1.TabIndex = 101;
            // 
            // btnGiamSoLuong
            // 
            this.btnGiamSoLuong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGiamSoLuong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGiamSoLuong.Location = new System.Drawing.Point(19, 98);
            this.btnGiamSoLuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGiamSoLuong.Name = "btnGiamSoLuong";
            this.btnGiamSoLuong.Size = new System.Drawing.Size(24, 18);
            this.btnGiamSoLuong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGiamSoLuong.TabIndex = 112;
            this.btnGiamSoLuong.Text = "-";
            this.btnGiamSoLuong.Click += new System.EventHandler(this.btnGiamSoLuong_Click);
            // 
            // btnTangSoLuong
            // 
            this.btnTangSoLuong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTangSoLuong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTangSoLuong.Location = new System.Drawing.Point(19, 62);
            this.btnTangSoLuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTangSoLuong.Name = "btnTangSoLuong";
            this.btnTangSoLuong.Size = new System.Drawing.Size(24, 18);
            this.btnTangSoLuong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTangSoLuong.TabIndex = 111;
            this.btnTangSoLuong.Text = "+";
            this.btnTangSoLuong.Click += new System.EventHandler(this.btnTangSoLuong_Click);
            // 
            // btnXoaHangTrongGio
            // 
            this.btnXoaHangTrongGio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoaHangTrongGio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoaHangTrongGio.Location = new System.Drawing.Point(19, 10);
            this.btnXoaHangTrongGio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoaHangTrongGio.Name = "btnXoaHangTrongGio";
            this.btnXoaHangTrongGio.Size = new System.Drawing.Size(81, 39);
            this.btnXoaHangTrongGio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoaHangTrongGio.TabIndex = 110;
            this.btnXoaHangTrongGio.Text = "Xóa";
            this.btnXoaHangTrongGio.Click += new System.EventHandler(this.btnXoaHangTrongGio_Click);
            // 
            // numericGiam
            // 
            this.numericGiam.Location = new System.Drawing.Point(53, 98);
            this.numericGiam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericGiam.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGiam.Name = "numericGiam";
            this.numericGiam.Size = new System.Drawing.Size(48, 20);
            this.numericGiam.TabIndex = 31;
            this.numericGiam.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericTang
            // 
            this.numericTang.Location = new System.Drawing.Point(53, 62);
            this.numericTang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericTang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTang.Name = "numericTang";
            this.numericTang.Size = new System.Drawing.Size(48, 20);
            this.numericTang.TabIndex = 30;
            this.numericTang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(674, 136);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 99;
            this.label14.Text = "KHÁCH HÀNG";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Aquamarine;
            this.groupBox1.Controls.Add(this.txtTienTraLai);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbTienKhachDua);
            this.groupBox1.Controls.Add(this.txtTongGiaTriGioHang);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPhanTramGiamGia);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtGiamGia);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTienHang);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(677, 478);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(481, 168);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TÍNH TIỀN";
            // 
            // txtTienTraLai
            // 
            this.txtTienTraLai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienTraLai.Location = new System.Drawing.Point(158, 131);
            this.txtTienTraLai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTienTraLai.Name = "txtTienTraLai";
            this.txtTienTraLai.ReadOnly = true;
            this.txtTienTraLai.Size = new System.Drawing.Size(267, 23);
            this.txtTienTraLai.TabIndex = 25;
            this.txtTienTraLai.Text = "0";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(38, 134);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "TIỀN TRẢ LẠI";
            // 
            // cmbTienKhachDua
            // 
            this.cmbTienKhachDua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTienKhachDua.FormattingEnabled = true;
            this.cmbTienKhachDua.Items.AddRange(new object[] {
            "500000",
            "200000",
            "100000",
            "50000",
            "20000",
            "10000"});
            this.cmbTienKhachDua.Location = new System.Drawing.Point(158, 74);
            this.cmbTienKhachDua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTienKhachDua.MaxLength = 9;
            this.cmbTienKhachDua.Name = "cmbTienKhachDua";
            this.cmbTienKhachDua.Size = new System.Drawing.Size(267, 25);
            this.cmbTienKhachDua.TabIndex = 23;
            this.cmbTienKhachDua.SelectedIndexChanged += new System.EventHandler(this.cmbTienKhachDua_SelectedIndexChanged);
            this.cmbTienKhachDua.TextChanged += new System.EventHandler(this.cmbTienKhachDua_TextChanged);
            this.cmbTienKhachDua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTienKhachDua_KeyPress);
            // 
            // txtTongGiaTriGioHang
            // 
            this.txtTongGiaTriGioHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongGiaTriGioHang.Location = new System.Drawing.Point(158, 102);
            this.txtTongGiaTriGioHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTongGiaTriGioHang.Name = "txtTongGiaTriGioHang";
            this.txtTongGiaTriGioHang.ReadOnly = true;
            this.txtTongGiaTriGioHang.Size = new System.Drawing.Size(267, 23);
            this.txtTongGiaTriGioHang.TabIndex = 22;
            this.txtTongGiaTriGioHang.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(37, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "TỔNG TIỀN";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(38, 79);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 19;
            this.label11.Text = "KHÁCH ĐƯA";
            // 
            // txtPhanTramGiamGia
            // 
            this.txtPhanTramGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhanTramGiamGia.Location = new System.Drawing.Point(362, 46);
            this.txtPhanTramGiamGia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPhanTramGiamGia.Name = "txtPhanTramGiamGia";
            this.txtPhanTramGiamGia.Size = new System.Drawing.Size(63, 23);
            this.txtPhanTramGiamGia.TabIndex = 16;
            this.txtPhanTramGiamGia.Text = "0";
            this.txtPhanTramGiamGia.TextChanged += new System.EventHandler(this.txtPhanTramGiamGia_TextChanged);
            this.txtPhanTramGiamGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhanTramGiamGia_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(330, 53);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "%";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiamGia.Location = new System.Drawing.Point(158, 46);
            this.txtGiamGia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.ReadOnly = true;
            this.txtGiamGia.Size = new System.Drawing.Size(168, 23);
            this.txtGiamGia.TabIndex = 14;
            this.txtGiamGia.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(38, 53);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "GIÃM GIÁ";
            // 
            // txtTienHang
            // 
            this.txtTienHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienHang.Location = new System.Drawing.Point(158, 19);
            this.txtTienHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTienHang.Name = "txtTienHang";
            this.txtTienHang.ReadOnly = true;
            this.txtTienHang.Size = new System.Drawing.Size(267, 23);
            this.txtTienHang.TabIndex = 12;
            this.txtTienHang.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(38, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "TIỀN HÀNG";
            // 
            // lstGioHang
            // 
            this.lstGioHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGioHang.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lstGioHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstGioHang.FullRowSelect = true;
            this.lstGioHang.GridLines = true;
            this.lstGioHang.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstGioHang.LabelWrap = false;
            this.lstGioHang.Location = new System.Drawing.Point(677, 177);
            this.lstGioHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstGioHang.Name = "lstGioHang";
            this.lstGioHang.ShowGroups = false;
            this.lstGioHang.Size = new System.Drawing.Size(482, 298);
            this.lstGioHang.TabIndex = 93;
            this.lstGioHang.UseCompatibleStateImageBehavior = false;
            this.lstGioHang.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TÊN HÀNG";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "GIÁ BÁN";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SỐ LƯỢNG";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "THÀNH TIỀN";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "MÃ HÀNG";
            this.columnHeader7.Width = 82;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(674, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "NHÂN VIÊN";
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(765, 48);
            this.txtMaHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(118, 20);
            this.txtMaHoaDon.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(674, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "SỐ HÓA ĐƠN";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(886, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "NGÀY";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(808, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 20);
            this.label3.TabIndex = 87;
            this.label3.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // btnThemHangHoaVaoGio
            // 
            this.btnThemHangHoaVaoGio.Location = new System.Drawing.Point(428, 9);
            this.btnThemHangHoaVaoGio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThemHangHoaVaoGio.Name = "btnThemHangHoaVaoGio";
            this.btnThemHangHoaVaoGio.Size = new System.Drawing.Size(60, 27);
            this.btnThemHangHoaVaoGio.TabIndex = 86;
            this.btnThemHangHoaVaoGio.Text = "Thêm";
            this.btnThemHangHoaVaoGio.UseVisualStyleBackColor = true;
            this.btnThemHangHoaVaoGio.Click += new System.EventHandler(this.btnThemHangHoaVaoGio_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(285, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 84;
            this.label2.Text = "Số lượng :";
            // 
            // autoCompleteTextTenHangHoa
            // 
            this.autoCompleteTextTenHangHoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.autoCompleteTextTenHangHoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.autoCompleteTextTenHangHoa.Location = new System.Drawing.Point(95, 14);
            this.autoCompleteTextTenHangHoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autoCompleteTextTenHangHoa.Name = "autoCompleteTextTenHangHoa";
            this.autoCompleteTextTenHangHoa.Size = new System.Drawing.Size(186, 20);
            this.autoCompleteTextTenHangHoa.TabIndex = 83;
            this.autoCompleteTextTenHangHoa.TextChanged += new System.EventHandler(this.autoCompleteTextTenHangHoa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Tìm kiếm";
            // 
            // dataGridViewHangHoa
            // 
            this.dataGridViewHangHoa.AllowUserToAddRows = false;
            this.dataGridViewHangHoa.AllowUserToDeleteRows = false;
            this.dataGridViewHangHoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHangHoa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewHangHoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHangHoa,
            this.TenHangHoa,
            this.GiaBan,
            this.DonVi,
            this.Column1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHangHoa.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHangHoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewHangHoa.Location = new System.Drawing.Point(27, 278);
            this.dataGridViewHangHoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewHangHoa.Name = "dataGridViewHangHoa";
            this.dataGridViewHangHoa.ReadOnly = true;
            this.dataGridViewHangHoa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewHangHoa.RowHeadersVisible = false;
            this.dataGridViewHangHoa.RowTemplate.Height = 24;
            this.dataGridViewHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHangHoa.Size = new System.Drawing.Size(461, 367);
            this.dataGridViewHangHoa.TabIndex = 102;
            this.dataGridViewHangHoa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHangHoa_CellDoubleClick);
            // 
            // MaHangHoa
            // 
            this.MaHangHoa.DataPropertyName = "Mã hàng hóa";
            this.MaHangHoa.FillWeight = 75F;
            this.MaHangHoa.HeaderText = "Mã hàng hóa";
            this.MaHangHoa.Name = "MaHangHoa";
            this.MaHangHoa.ReadOnly = true;
            this.MaHangHoa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TenHangHoa
            // 
            this.TenHangHoa.DataPropertyName = "Tên hàng hóa";
            this.TenHangHoa.FillWeight = 225F;
            this.TenHangHoa.HeaderText = "Tên hàng hóa";
            this.TenHangHoa.Name = "TenHangHoa";
            this.TenHangHoa.ReadOnly = true;
            this.TenHangHoa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "Giá bán";
            this.GiaBan.FillWeight = 50F;
            this.GiaBan.HeaderText = "GIá bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            this.GiaBan.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DonVi
            // 
            this.DonVi.DataPropertyName = "Đơn vị";
            this.DonVi.FillWeight = 50F;
            this.DonVi.HeaderText = "Đơn vị";
            this.DonVi.Name = "DonVi";
            this.DonVi.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Số lượng";
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Số lượng";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dateTimeInput1
            // 
            this.dateTimeInput1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(942, 48);
            this.dateTimeInput1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(214, 20);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 103;
            this.dateTimeInput1.Value = new System.DateTime(2018, 10, 1, 16, 20, 10, 0);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(27, 48);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Tất cả loại hàng hóa";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(462, 208);
            this.treeView1.TabIndex = 105;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // numericThem
            // 
            this.numericThem.Location = new System.Drawing.Point(351, 14);
            this.numericThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericThem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericThem.Name = "numericThem";
            this.numericThem.Size = new System.Drawing.Size(55, 20);
            this.numericThem.TabIndex = 106;
            this.numericThem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbbKhachHang
            // 
            this.cbbKhachHang.FormattingEnabled = true;
            this.cbbKhachHang.Location = new System.Drawing.Point(765, 134);
            this.cbbKhachHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbKhachHang.Name = "cbbKhachHang";
            this.cbbKhachHang.Size = new System.Drawing.Size(392, 21);
            this.cbbKhachHang.TabIndex = 108;
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Location = new System.Drawing.Point(765, 87);
            this.txtNhanVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.ReadOnly = true;
            this.txtNhanVien.Size = new System.Drawing.Size(392, 20);
            this.txtNhanVien.TabIndex = 109;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThanhToan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThanhToan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThanhToan.Image = global::QuanLySieuThi.Properties.Resources.shop_cart_icon;
            this.btnThanhToan.ImageFixedSize = new System.Drawing.Size(128, 128);
            this.btnThanhToan.Location = new System.Drawing.Point(521, 523);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnThanhToan.Size = new System.Drawing.Size(121, 122);
            this.btnThanhToan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThanhToan.TabIndex = 104;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::QuanLySieuThi.Properties.Resources.bg_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1109, 630);
            this.ControlBox = false;
            this.Controls.Add(this.txtNhanVien);
            this.Controls.Add(this.cbbKhachHang);
            this.Controls.Add(this.numericThem);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.dateTimeInput1);
            this.Controls.Add(this.dataGridViewHangHoa);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstGioHang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThemHangHoaVaoGio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.autoCompleteTextTenHangHoa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmHoaDon";
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericGiam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericGiam;
        private System.Windows.Forms.NumericUpDown numericTang;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTienKhachDua;
        private System.Windows.Forms.TextBox txtTongGiaTriGioHang;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPhanTramGiamGia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTienHang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lstGioHang;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThemHangHoaVaoGio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox autoCompleteTextTenHangHoa;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewHangHoa;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.ButtonX btnThanhToan;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.NumericUpDown numericThem;
        private System.Windows.Forms.TextBox txtTienTraLai;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox cbbKhachHang;
        private System.Windows.Forms.TextBox txtNhanVien;
        private DevComponents.DotNetBar.ButtonX btnGiamSoLuong;
        private DevComponents.DotNetBar.ButtonX btnTangSoLuong;
        private DevComponents.DotNetBar.ButtonX btnXoaHangTrongGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;




    }
}