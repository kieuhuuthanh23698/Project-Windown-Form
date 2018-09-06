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


        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
            Login f = new Login();
            f.Show();
        }

        private void HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có muốn thoát không 1 ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (result == DialogResult.Yes)
            //    e.Cancel = false;
            //else
            //    e.Cancel = true;
        }


        private void changePassword(object sender, EventArgs e)
        {
            ChangePassword f = new ChangePassword();
            f.ShowDialog();
        }

        private void Logout(object sender, EventArgs e)
        {
            this.Close();
            Login f = new Login();
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
