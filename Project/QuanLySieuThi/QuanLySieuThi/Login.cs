using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class Login : Form
    {
        string chuoiKetNoi;


        public Login()
        {
            InitializeComponent();
        }

        public Login(string chuoiKetNoi)
        {
            InitializeComponent();
            this.chuoiKetNoi = chuoiKetNoi;
            MessageBox.Show(chuoiKetNoi);
            txtTenDangNhap.Focus();
        }    

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Bill hoaDon = new Bill();
            hoaDon.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit(); 
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
                this.errorProvider1.SetError(txtTenDangNhap, "Bạn không được để trống tên đăng nhập !");
            else
                this.errorProvider1.Clear();
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
                this.errorProvider1.SetError(txtMatKhau, "Bạn không được để trống tên đăng nhập !");
            else
                this.errorProvider1.Clear();
        }
    }
}
