using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmDoiMatKhau : Form
    {
        string manv;
        KetNoiDuLieu link;

        public frmDoiMatKhau(string manv,KetNoiDuLieu link)
        {
            this.manv = manv;
            this.link = link;
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text != "" && txtMatKhauMoi.Text != "" && txtMatKhauMoiNhapLai.Text != "")
            {
                if (txtMatKhauMoi.Text == txtMatKhauMoiNhapLai.Text)
                {
                    string chuoiQuery = "select Passwords from NhanVien where MaNhanVien = '" + this.manv + "'";
                    string matKhauNV = this.link.comMandScalar(chuoiQuery).Trim();
                    if (txtMatKhauCu.Text == matKhauNV)
                    {
                        string chuoiUpdate = "update NhanVien set Passwords = '" + txtMatKhauMoi.Text + "' where MaNhanVien = '" + this.manv + "'";
                        int kqUpdate = this.link.query(chuoiUpdate);
                        if (kqUpdate != 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công !");
                            this.Close();
                        }
                        else
                            MessageBox.Show("Đổi mật khẩu thất bại !");
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ nhập sai !");
                        txtMatKhauCu.Text = "";
                        txtMatKhauCu.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới và nhập lại không giống nhau !");
                    txtMatKhauMoi.Text = "";
                    txtMatKhauMoiNhapLai.Text = "";
                    txtMatKhauMoi.Focus();
                }
            }
            else
            {
                if (txtMatKhauCu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu cũ !");
                }
                if (txtMatKhauMoi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới !");
                }
                if (txtMatKhauMoiNhapLai.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới nhập lại !");
                }
                txtMatKhauCu.Text = "";
                txtMatKhauMoi.Text = "";
                txtMatKhauMoiNhapLai.Text = "";
                txtMatKhauCu.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
