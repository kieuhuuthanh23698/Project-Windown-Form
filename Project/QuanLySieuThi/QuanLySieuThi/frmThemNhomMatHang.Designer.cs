namespace QuanLySieuThi
{
    partial class frmThemNhomMatHang
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNhomMatHang = new System.Windows.Forms.TextBox();
            this.txtMaNhomMatHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemNhomMatHang = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên nhóm mặt hàng";
            // 
            // txtTenNhomMatHang
            // 
            this.txtTenNhomMatHang.Location = new System.Drawing.Point(191, 99);
            this.txtTenNhomMatHang.Name = "txtTenNhomMatHang";
            this.txtTenNhomMatHang.Size = new System.Drawing.Size(245, 22);
            this.txtTenNhomMatHang.TabIndex = 2;
            this.txtTenNhomMatHang.TextChanged += new System.EventHandler(this.txtTenNhomMatHang_TextChanged);
            this.txtTenNhomMatHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNhomMatHang_KeyPress);
            // 
            // txtMaNhomMatHang
            // 
            this.txtMaNhomMatHang.Location = new System.Drawing.Point(191, 144);
            this.txtMaNhomMatHang.Name = "txtMaNhomMatHang";
            this.txtMaNhomMatHang.Size = new System.Drawing.Size(245, 22);
            this.txtMaNhomMatHang.TabIndex = 6;
            this.txtMaNhomMatHang.TextChanged += new System.EventHandler(this.txtMaNhomMatHang_TextChanged);
            this.txtMaNhomMatHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaNhomMatHang_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã nhóm mặt hàng";
            // 
            // btnThemNhomMatHang
            // 
            this.btnThemNhomMatHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThemNhomMatHang.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThemNhomMatHang.Location = new System.Drawing.Point(191, 199);
            this.btnThemNhomMatHang.Name = "btnThemNhomMatHang";
            this.btnThemNhomMatHang.Size = new System.Drawing.Size(75, 23);
            this.btnThemNhomMatHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThemNhomMatHang.TabIndex = 7;
            this.btnThemNhomMatHang.Text = "Thêm";
            this.btnThemNhomMatHang.Click += new System.EventHandler(this.btnThemNhomMatHang_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(313, 199);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::QuanLySieuThi.Properties.Resources.nhomMatHang;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmThemNhomMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 278);
            this.ControlBox = false;
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThemNhomMatHang);
            this.Controls.Add(this.txtMaNhomMatHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenNhomMatHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmThemNhomMatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHÓM MẶT HÀNG - THÊM MỚI";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNhomMatHang;
        private System.Windows.Forms.TextBox txtMaNhomMatHang;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnThemNhomMatHang;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.BalloonTip balloonTip1;
    }
}