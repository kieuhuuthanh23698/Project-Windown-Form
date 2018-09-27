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
        string chuoiKetNoi = "";
        SqlConnection sql;
        public KetNoi()
        {
            InitializeComponent();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            chuoiKetNoi = @"Data Source=" + txtDataSource.Text + ";Initial Catalog=" + txtIni.Text + ";User ID=" + txtID.Text + ";Password=" + txtPass.Text;
            sql = new SqlConnection(chuoiKetNoi);
            sql.Open();
            if (sql.State == System.Data.ConnectionState.Open)
                MessageBox.Show("da mo");
            Login frmlogin = new Login(chuoiKetNoi);
            this.Close();
            frmlogin.Show();
        }
    }
}
