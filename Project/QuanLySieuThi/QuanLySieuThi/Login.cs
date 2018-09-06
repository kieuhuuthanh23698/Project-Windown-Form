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
        public Login()
        {
            InitializeComponent();
        }

        //button login
        private void button1_Click(object sender, EventArgs e)
        {
            Bill hoaDon = new Bill();
            hoaDon.Show();
            this.Hide();
        }

        //button exit
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit();            
        }
    }
}
