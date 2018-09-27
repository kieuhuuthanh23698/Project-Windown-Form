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
            ChangePassword f = new ChangePassword();
            f.ShowDialog();
        }

        //button logout
        private void Logout(object sender, EventArgs e)
        {
            this.Close();
            Login f = new Login("");
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
            Products f = new Products();
            f.ShowDialog();
        }

        private void Moformthongtin(object sender, EventArgs e)
        {
            thongtinsieuthics f = new thongtinsieuthics();
            f.ShowDialog();
        }

        private void moformhoadon(object sender, EventArgs e)
        {
            thongkehoadon f = new thongkehoadon();
            f.ShowDialog();
        }

        private void moformthongkethuchi(object sender, EventArgs e)
        {
            thongkethuchi f = new thongkethuchi();
            f.ShowDialog();
        }

        private void moFormDanhMucKhachHang(object sender, EventArgs e)
        {
            KhachHang f = new KhachHang();
            f.Show();
        }

        private void moFormDanhMucNhanVien(object sender, EventArgs e)
        {
            NhanVien f = new NhanVien();
            f.Show();
        }
    }

    //class HangHoa
    //{
    //    public String maHang { get; set; }
    //    public String tenHang { get; set; }
    //    public String giaBan { get; set; }
    //    public String tonKho { get; set; }
    //}
}
