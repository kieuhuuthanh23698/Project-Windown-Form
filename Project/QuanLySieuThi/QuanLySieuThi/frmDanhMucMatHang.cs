using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmDanhMucMatHang : Form
    {
        KetNoiDuLieu link;
        string manv;
        ImageList im = new ImageList();

        public frmDanhMucMatHang(KetNoiDuLieu link, string manv)
        {
            this.link = link;
            this.manv = manv;
            im.Images.Add(QuanLySieuThi.Properties.Resources.father_node);
            im.Images.Add(QuanLySieuThi.Properties.Resources.child_node);
            InitializeComponent();
            taiGridViewHangHoa();
            taiTreeView();
        }

        public void taiGridViewHangHoa()
        {
            dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho  as N'Số lượng' from KhoHang", "Hang hoa").Tables["Hang hoa"];
        }

        public void taiTreeView()
        {
            if (treeViewLoaiMatHang.Nodes[0].Nodes.Count != 0)
                treeViewLoaiMatHang.Nodes[0].Nodes.Clear();
            treeViewLoaiMatHang.ImageList = im;
            SqlDataReader rd = this.link.comManReader("select TenLoaiHangHoa from LoaiHangHoa", "LoaiHangHoa");
            treeViewLoaiMatHang.Nodes[0].ImageIndex = 0;
            int i = 0;
            while (rd.Read())
            {
                
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(rd["TenLoaiHangHoa"].ToString());
                treeViewLoaiMatHang.Nodes[0].Nodes.Add(node);
                treeViewLoaiMatHang.Nodes[0].Nodes[i].ImageIndex = 1;
                i++;
            }

            rd.Close();

            if (this.link.state() == ConnectionState.Open)
                this.link.sql.Close();
            treeViewLoaiMatHang.ExpandAll();
        }

        private void treeViewLoaiMatHang_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Text.Equals("Tất cả loại hàng hóa") == true)
                taiGridViewHangHoa();
            else
                dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho  as N'Số lượng' from KhoHang where LoaiHangHoa like N'" + e.Node.Text + "%'", "Loai hang hoa").Tables["Loai hang hoa"];
            if (link.state() == ConnectionState.Open)
                this.link.sql.Close();
        }
        
        // thao tác với loại thông tin loại mặt hàng

        private void btnThemLoaiMatHang_Click(object sender, EventArgs e)
        {
            frmThemNhomMatHang frm = new frmThemNhomMatHang(this.link);
            frm.ShowDialog();
            //sau khi thêm thì cập nhật lại
            treeViewLoaiMatHang.Nodes[0].Nodes.Clear();
            taiTreeView();
        }

        private void btnXoaLoaiMatHang_Click(object sender, EventArgs e)
        {
            //xóa một nhóm mặt hàng :
            //xóa tất cả các hóa đơn, chi tiết hóa đơn có loại hàng hóa này => không thể làm như vậy
            //xóa tất cả các mặt hàng của nhóm đó  => update số lượng của các mặt hàng thuộc nhóm đó = 0
            DevComponents.AdvTree.Node node = treeViewLoaiMatHang.SelectedNode;
            if (node == treeViewLoaiMatHang.Nodes[0])
                //node đang chọn là node cha, ko dc phép xóa
                return;
            if (node != null)
            {
                string tenNhomMatHangCanXoa = node.Text;
               // MessageBox.Show(tenNhomMatHangCanXoa);
                string command = "update KhoHang set SoluongTrongKho = 0 where LoaiHangHoa = N'" + tenNhomMatHangCanXoa + "'";
                int i = this.link.insert(command);
                if (i != 0)
                    MessageBox.Show("Xóa thành công !\nSố lượng hàng hóa của tất cả các mặt hàng thuộc nhóm " + tenNhomMatHangCanXoa + " đã = 0.", "Xóa nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa thất bại !", "Xóa nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            taiGridViewHangHoa();
        }

        private void btnSuaLoaiMatHang_Click(object sender, EventArgs e)
        {
            //loại hàng hóa ở bảng loại hàng hóa và bảng kho hàng
            if (treeViewLoaiMatHang.SelectedNode != null)
            {
                if (treeViewLoaiMatHang.SelectedNode != treeViewLoaiMatHang.Nodes[0])
                {
                    string ten = treeViewLoaiMatHang.SelectedNode.Text;
                    frmDoiTenNhomMatHang frm = new frmDoiTenNhomMatHang(ten, this.link);
                    frm.ShowDialog();
                    taiTreeView();
                    taiGridViewHangHoa();
                }
            }
        }

        // thao tác với hàng hóa

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            frmThemSanPham frm = new frmThemSanPham(this.link);
            frm.ShowDialog();
            taiGridViewHangHoa();
        }

        private void btnXoaMatHang_Click(object sender, EventArgs e)
        {
            //cho số lượng hàng hóa đó = 0
            if (dataGridViewHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewHangHoa.SelectedRows[0];
                string maHangHoa = row.Cells["MaHangHoa"].Value.ToString().Trim();
                int i = this.link.insert("update KhoHang set SoluongTrongKho = 0 where MaHangHoa = '" + maHangHoa + "'");
                if (i != 0)
                    MessageBox.Show("Xóa hàng hóa thành công !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa hàng hóa thất bại !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                taiGridViewHangHoa();
            }
        }

        private void btnSuaMatHang_Click(object sender, EventArgs e)
        {
            if (dataGridViewHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewHangHoa.SelectedRows[0];
                frmSuaHangHoa frm = new frmSuaHangHoa(this.link, row);
                frm.ShowDialog();
                taiGridViewHangHoa();
            }
        }

        private void btnThemHangVaoKho_Click(object sender, EventArgs e)
        {
            //sửa lại số lượng trong kho hàng
            if (dataGridViewHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewHangHoa.SelectedRows[0];
                frmNhapHangHoaVaoKho frm = new frmNhapHangHoaVaoKho(this.link, row);
                frm.ShowDialog();
                taiGridViewHangHoa();
            }
        }

    }
}
