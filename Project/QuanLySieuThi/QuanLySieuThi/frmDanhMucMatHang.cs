using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmDanhMucMatHang : Form
    {
        public frmDanhMucMatHang()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemNhomMatHang f = new frmThemNhomMatHang();
            f.ShowDialog();
        }

        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiTenNhomMatHang f = new frmDoiTenNhomMatHang();
            f.ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSanPham f = new frmThemSanPham();
            f.ShowDialog();
        }

        private void chageProduct(object sender, EventArgs e)
        {
            ChangeProduct f = new ChangeProduct();
            f.ShowDialog();
        }
    }
}
