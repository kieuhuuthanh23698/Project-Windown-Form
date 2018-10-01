using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class KetNoi : Form
    {
        //Data Source=LAPTOP-CQ1BQQH5\SQLEXPRESS;Initial Catalog=QL_SIEUTHI;Persist Security Info=True;User ID=sa
        //string chuoiKetNoi = "";
        //SqlConnection sql;
        public KetNoi()
        {
            InitializeComponent();
            txtDataSource.Focus();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (txtDataSource.Text != "" && txtID.Text != "" && txtIni.Text != "" && txtPass.Text != "")
            {
                this.errorProvider1.Clear();
                //tạo chuỗi kết nối
                string chuoiKetNoi = @"Data Source=" + txtDataSource.Text + ";Initial Catalog=" + txtIni.Text + ";User ID=" + txtID.Text + ";Password=" + txtPass.Text;
                //sql = new SqlConnection(chuoiKetNoi);
                //sql.Open();
                KetNoiDuLieu link = new KetNoiDuLieu(chuoiKetNoi);
                if (link.state() == System.Data.ConnectionState.Open)
                {
                    //đưa kết nối vào form login
                    Login frmlogin = new Login(link);
                    this.Hide();
                    frmlogin.Show();
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại !", "CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                if (txtDataSource.Text == "")
                    this.errorProvider1.SetError(txtDataSource, "Bạn không được để trống tên server của database !");
                if (txtID.Text == "")
                    this.errorProvider1.SetError(txtID,"Không được để trống !");
                if (txtIni.Text == "")
                    this.errorProvider1.SetError(txtIni,"Không được để trống username đăng nhập vào server !");
                if (txtPass.Text == "")
                    this.errorProvider1.SetError(txtPass, "Không được để trống mật khẩu đăng nhập vào server !");
            }
        }

        private void txtDataSource_Leave(object sender, EventArgs e)
        {
            if (txtDataSource.Text == "")
                this.errorProvider1.SetError(txtDataSource, "Bạn không được để trống tên server của database !");
            else
                this.errorProvider1.Clear();
        }

        private void txtIni_Leave(object sender, EventArgs e)
        {
            if (txtIni.Text == "")
                this.errorProvider1.SetError(txtIni, "Không được để trống tên database !");
            else
                this.errorProvider1.Clear();
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                this.errorProvider1.SetError(txtID, "Không được để trống username đăng nhập vào server !");
            else
                this.errorProvider1.Clear();
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
                this.errorProvider1.SetError(txtPass, "Không được để trống mật khẩu đăng nhập vào server !");
            else
                this.errorProvider1.Clear();
        }
    }
}
