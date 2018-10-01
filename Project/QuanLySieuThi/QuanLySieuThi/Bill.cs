using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class Bill : Form
    {
        //public List<HangHoa> list;

        public void KhoiTaoKhoHang()
        {
            int n = 100;
        }
        public Bill()
        {
            InitializeComponent();
            treeView1.Nodes[0].Expand();
            TaoList();
        }

        public void additem(int i) 
        {
            listView1.Items.Add(i.ToString());
            listView1.Items[i].SubItems.Add("Mã hàng :" + i);
            listView1.Items[i].SubItems.Add("Tên hàng" + i);
            listView1.Items[i].SubItems.Add("Giá bán :" + i);
            listView1.Items[i].SubItems.Add("" + i);
        }

        public void TaoList()
        {
            for (int i = 0; i < 100; i++)
                additem(i);
        }

        //button exit
        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit();    
        }

        //button chage password
        private void changePassword(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.ShowDialog();
        }

        //button logout
        private void Logout(object sender, EventArgs e)
        {
            this.Close();
            frmLogin f = new frmLogin("");
            f.Show();
        }

        private void Exit(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit();  
        }

        private void danhmucmathang(object sender, EventArgs e)
        {
            frmDanhMucMatHang f = new frmDanhMucMatHang();
            f.ShowDialog();
        }

        private void Moformthongtin(object sender, EventArgs e)
        {
            frmThongTinSieuThi f = new frmThongTinSieuThi();
            f.ShowDialog();
        }

        private void moformhoadon(object sender, EventArgs e)
        {
            frmThongKeHoaDon f = new frmThongKeHoaDon();
            f.ShowDialog();
        }

        private void moformthongkethuchi(object sender, EventArgs e)
        {
            frmThongKeThuChi f = new frmThongKeThuChi();
            f.ShowDialog();
        }

        private void moFormDanhMucKhachHang(object sender, EventArgs e)
        {
            frmDanhMucKhachHang f = new frmDanhMucKhachHang();
            f.Show();
        }

        private void moFormDanhMucNhanVien(object sender, EventArgs e)
        {
            frmDanhMucNhanVien f = new frmDanhMucNhanVien();
            f.Show();
        }
    }

}
