using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class HoaDon : Form
    {
        public List<HangHoa> list;

        public void KhoiTaoKhoHang()
        {
            int n = 100;
        }
        public HoaDon()
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
            Application.Exit();
        }

        private void HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                e.Cancel = false;
        }
    }

    class HangHoa
    {
        public String maHang { get; set; }
        public String tenHang { get; set; }
        public String giaBan { get; set; }
        public String tonKho { get; set; }
    }
}
