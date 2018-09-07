using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTypeProduct f = new AddTypeProduct();
            f.ShowDialog();
        }

        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChageTypeProduct f = new ChageTypeProduct();
            f.ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewProduct f = new AddNewProduct();
            f.ShowDialog();
        }

        private void chageProduct(object sender, EventArgs e)
        {
            ChangeProduct f = new ChangeProduct();
            f.ShowDialog();
        }
    }
}
