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
            taiTreeViewNhomMatHang();
        }

        public void taiGridViewHangHoa()
        {
            dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho  as N'Số lượng' from KhoHang", "Hang hoa").Tables["Hang hoa"];
        }

        public void taiTreeViewNhomMatHang()
        {
            if (treeViewLoaiMatHang.Nodes[0].Nodes.Count != 0)//xóa những nhóm mặt hàng hiện có trong treeview để cập nhật mới
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
                this.link.closeConnection();
            treeViewLoaiMatHang.ExpandAll();
        }

        private void treeViewLoaiMatHang_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Text.Equals("Tất cả loại hàng hóa") == true)
                taiGridViewHangHoa();
            else
                dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho  as N'Số lượng' from KhoHang, LoaiHangHoa where TenLoaiHangHoa like N'" + e.Node.Text + "' AND KhoHang.MaLoaiHangHoa = LoaiHangHoa.MaLoaiHangHoa ", "Loai hang hoa").Tables["Loai hang hoa"];
            if (link.state() == ConnectionState.Open)
                this.link.closeConnection();
        }
        
        // thao tác với loại thông tin loại mặt hàng

        private void btnThemLoaiMatHang_Click(object sender, EventArgs e)
        {
            frmThemNhomMatHang frm = new frmThemNhomMatHang(this.link);
            frm.ShowDialog();
            //sau khi thêm thì cập nhật lại
            treeViewLoaiMatHang.Nodes[0].Nodes.Clear();
            taiTreeViewNhomMatHang();
        }

        private void btnXoaLoaiMatHang_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.AdvTree.Node node = treeViewLoaiMatHang.SelectedNode;
                if (node == treeViewLoaiMatHang.Nodes[0])
                    //node đang chọn là node cha, ko dc phép xóa
                    return;
                if (node != null)
                {
                    string tenLoaiHangHoaCanXoa = node.Text;
                    //đưa bẳng LOẠI hàng hóa từ csdl lên bộ nhớ
                    string queryLoaiHangHoa = "select * from LoaiHangHoa";
                    SqlConnection sql = this.link.getSql();
                    DataSet dsLoaiHangHoa = new DataSet();
                    SqlDataAdapter daLoaiHangHoa = new SqlDataAdapter(queryLoaiHangHoa, sql);
                    daLoaiHangHoa.Fill(dsLoaiHangHoa, "LoaiHangHoa");
                    DataTable dtLoaiHangHoa = dsLoaiHangHoa.Tables["LoaiHangHoa"];
                    //xóa LOẠI hàng hóa đang dc chọn
                    int n = dtLoaiHangHoa.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {
                        if (dtLoaiHangHoa.Rows[i]["TenLoaiHangHoa"].ToString().Trim() == tenLoaiHangHoaCanXoa)
                        {
                            //xóa tất cả những hàng hóa thuộc LOẠI hàng hóa này
                            xoaHangHoa(dtLoaiHangHoa.Rows[i]["MaLoaiHangHoa"].ToString().Trim());
                            //xóa LOẠI hàng hóa này
                            MessageBox.Show("Đã xóa nhóm mặt hàng " + dtLoaiHangHoa.Rows[i]["TenLoaiHangHoa"].ToString().Trim(), "Xóa nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dtLoaiHangHoa.Rows[i].Delete();
                            break;
                        }
                    }
                    //cập nhật dữ liệu từ bộ nhớ xuống csdl
                    SqlCommandBuilder scb = new SqlCommandBuilder(daLoaiHangHoa);
                    scb.GetDeleteCommand();//chú ý : do xóa nên chọn getDeleteCommand()
                    daLoaiHangHoa.Update(dsLoaiHangHoa, "LoaiHangHoa");

                    taiGridViewHangHoa();
                    taiTreeViewNhomMatHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaHangHoa(string maLoaiHangHoa)
        {
            try
            {
                //đưa bảng kho hàng từ csdl lên bộ nhớ
                SqlConnection sql = this.link.getSql();
                string queryKhoHang = "select * from KhoHang";
                SqlDataAdapter daKhoHang = new SqlDataAdapter(queryKhoHang, sql);
                DataSet dsKhoHang = new DataSet();
                daKhoHang.Fill(dsKhoHang, "KhoHang");
                DataTable dtKhoHang = dsKhoHang.Tables["KhoHang"];

                //xóa những hàng hóa có mã loại hàng hóa này
                int n = dtKhoHang.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    if (dtKhoHang.Rows[i]["MaLoaiHangHoa"].ToString().Trim() == maLoaiHangHoa)
                    {
                        //xóa tất cả những chi tiết hóa đơn có mã loại hàng hóa này
                        xoaChiTietHoaDon(dtKhoHang.Rows[i]["TenHangHoa"].ToString().Trim());
                        MessageBox.Show("Hàng hóa : " + dtKhoHang.Rows[i]["TenHangHoa"].ToString().Trim() + " thuộc nhóm " + dtKhoHang.Rows[i]["MaLoaiHangHoa"].ToString().Trim() + " trong kho hàng đã bị xóa !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtKhoHang.Rows[i].Delete();
                    }
                }

                //cập nhật dữ liệu từ bộ nhớ xuống csdl
                SqlCommandBuilder scb = new SqlCommandBuilder(daKhoHang);
                scb.GetDeleteCommand();
                daKhoHang.Update(dsKhoHang, "KhoHang");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaChiTietHoaDon(string tenHangHoa)
        {
            try
            {
                //đưa bảng hóa đơn(chứa chi tiết hóa đơn cần xóa) lên bộ nhớ
                SqlConnection sql = this.link.getSql();
                string queryChiTietHoaDon = "select * from ChiTietHoaDon";
                SqlDataAdapter daChiTietHoaDOn = new SqlDataAdapter(queryChiTietHoaDon, sql);
                DataSet dsChiTietHoaDon = new DataSet();
                daChiTietHoaDOn.Fill(dsChiTietHoaDon, "ChiTietHoaDon");
                DataTable tbChiTietHoaDon = dsChiTietHoaDon.Tables["ChiTietHoaDon"];

                //tìm những hóa đơn có hàng hóa này
                List<string> nhungHoaDonCanXoa = new List<string>();//lưu mã hóa đơn của những hóa đơn cần xóa
                int n = tbChiTietHoaDon.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    if (tbChiTietHoaDon.Rows[i]["TenHangHoa"].ToString().Trim() == tenHangHoa)
                        nhungHoaDonCanXoa.Add(tbChiTietHoaDon.Rows[i]["MaHoaDon"].ToString().Trim());
                }

                //xóa những chi tiết tiết hóa đơn có mã hóa đơn của những hóa đơn cần xóa
                int soluongHoaDonCanXoa = nhungHoaDonCanXoa.Count;
                for (int i = 0; i < soluongHoaDonCanXoa; i++)
                {
                        for (int j = 0; j < n; j++)
                        {
                            if (tbChiTietHoaDon.Rows[j].RowState != DataRowState.Deleted)
                            {
                                if (tbChiTietHoaDon.Rows[j]["MaHoaDon"].ToString().Trim() == nhungHoaDonCanXoa[i])
                                {
                                    MessageBox.Show("Đã xóa chi tiết hóa đơn " + tbChiTietHoaDon.Rows[j]["MaHangHoa"].ToString().Trim() + " của hóa đơn" + tbChiTietHoaDon.Rows[j]["MaHoaDon"].ToString().Trim(), "XÓA CHI TIẾT HÓA ĐƠN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tbChiTietHoaDon.Rows[j].Delete();
                                }
                            }
                        }                   
                }
                //cập nhật dữ liệu chi tiết hóa đơn xuống csdl
                SqlCommandBuilder scb = new SqlCommandBuilder(daChiTietHoaDOn);
                scb.GetDeleteCommand();
                daChiTietHoaDOn.Update(dsChiTietHoaDon, "ChiTietHoaDon");
                //sau khi xóa chi tiết hóa đơn thì mới xóa hóa đơn
                //xóa những hóa đơn cần xóa
                xoaHoaDon(nhungHoaDonCanXoa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaHoaDon(List<string> nhungHoaDonCanXoa)
        {
            try
            {
                //xóa những hóa đơn cần xóa lưu trong list<string> nhungHoaDonCanXoa

                //load bảng hóa đơn dưới csdl lên bộ nhớ
                SqlConnection sql = this.link.getSql();
                string queryHoaDon = "select * from HoaDon";
                SqlDataAdapter daHoaDon = new SqlDataAdapter(queryHoaDon, sql);
                DataSet dsHoaDon = new DataSet();
                daHoaDon.Fill(dsHoaDon, "HoaDon");
                DataTable tbHoaDon = dsHoaDon.Tables["HoaDon"];

                int n = nhungHoaDonCanXoa.Count;
                //xóa hóa đơn
                for (int i = 0; i < n; i++)
                {
                    int N = tbHoaDon.Rows.Count;
                    for (int j = 0; j < N; j++)
                    {
                        if (tbHoaDon.Rows[i].RowState != DataRowState.Deleted)
                        {
                            if (nhungHoaDonCanXoa[i] == tbHoaDon.Rows[i]["MaHoaDon"].ToString().Trim())
                            {
                                MessageBox.Show("Đã xóa hóa đơn " + tbHoaDon.Rows[i]["MaHoaDon"].ToString().Trim(), "XÓA HÓA ĐƠN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbHoaDon.Rows[i].Delete();
                            }
                        }
                    }
                }

                //cập nhật bảng hóa đơn xuống csdl 
                SqlCommandBuilder scb = new SqlCommandBuilder(daHoaDon);
                scb.GetDeleteCommand();
                daHoaDon.Update(dsHoaDon, "HoaDon");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    taiTreeViewNhomMatHang();
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
                try
                {
                DataGridViewRow row = dataGridViewHangHoa.SelectedRows[0];
                string maHangHoa = row.Cells["MaHangHoa"].Value.ToString().Trim();

                SqlConnection sql = this.link.getSql();
                string queryKhoHang = "select * from KhoHang";
                SqlDataAdapter daKhoHang = new SqlDataAdapter(queryKhoHang, sql);
                DataSet dsKhoHang = new DataSet();
                daKhoHang.Fill(dsKhoHang, "KhoHang");
                DataTable dtKhoHang = dsKhoHang.Tables["KhoHang"];

                //xóa hàng hóa có mã hàng hóa này
                int n = dtKhoHang.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    if (dtKhoHang.Rows[i]["MaHangHoa"].ToString().Trim() == maHangHoa)
                    {
                        //xóa tất cả những chi tiết hóa đơn có mã loại hàng hóa này
                        xoaChiTietHoaDon(dtKhoHang.Rows[i]["TenHangHoa"].ToString().Trim());
                        MessageBox.Show("Hàng hóa : " + dtKhoHang.Rows[i]["TenHangHoa"].ToString().Trim() + " thuộc nhóm " + dtKhoHang.Rows[i]["MaLoaiHangHoa"].ToString().Trim() + " trong kho hàng đã bị xóa !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtKhoHang.Rows[i].Delete();
                        break;
                    }
                }

                //cập nhật dữ liệu từ bộ nhớ xuống csdl
                SqlCommandBuilder scb = new SqlCommandBuilder(daKhoHang);
                scb.GetDeleteCommand();
                daKhoHang.Update(dsKhoHang, "KhoHang");
                taiGridViewHangHoa();
                MessageBox.Show("Xóa hàng hóa thành công !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Xóa hàng hóa thất bại !", "XÓA HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
