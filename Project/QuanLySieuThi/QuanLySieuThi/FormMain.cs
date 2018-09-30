using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            hoaDon f = new hoaDon();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            dockContainerItem1.Control.Controls.Add(f);
            f.Show();
        }

        private void logout(object sender, EventArgs e)
        {
            this.Close();
            Login frmLogin = new Login("");
            frmLogin.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changePass(object sender, EventArgs e)
        {
            ChangePassword frmChangePass = new ChangePassword();
            frmChangePass.ShowDialog();
        }

        private void danhMucMatHang(object sender, EventArgs e)
        {
        }
    }
}
