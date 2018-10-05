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
    public partial class frmHoaDon : Form
    {
        KetNoiDuLieu link;
        String manv;

        public frmHoaDon(KetNoiDuLieu link, String manv)
        {
            this.link = link;
            this.manv = manv;
            InitializeComponent();
            taiGridViewHangHoa();
            taiTreeView();
            taiAutoCompleteText();
            cmbTienKhachDua.SelectedIndex = 0;
        }

        public void taiGridViewHangHoa()
        {
            dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho as N'Tồn kho' from KhoHang","Hang hoa").Tables["Hang hoa"];
        }

        public void taiTreeView()
        {
            SqlDataReader rd = this.link.comManReader("select distinct LoaiHangHoa from KhoHang","LoaiHangHoa");
            while (rd.Read())
            {
                treeView1.Nodes[0].Nodes.Add(rd["LoaiHangHoa"].ToString());
            }
            rd.Close();
            treeView1.ExpandAll();
        }

        public void taiAutoCompleteText()
        {
            SqlDataReader rd = this.link.comManReader("select TenHangHoa from KhoHang", "TenHangHoa");
            while (rd.Read())
            {
                autoCompleteTextTenHangHoa.AutoCompleteCustomSource.Add(rd["TenHangHoa"].ToString());
            }
            rd.Close();
        }

        private void autoCompleteTextTenHangHoa_TextChanged(object sender, EventArgs e)
        {
            if (autoCompleteTextTenHangHoa.Text.Trim().Equals("") == true)
                taiGridViewHangHoa();
            else
                dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho as N'Tồn kho' from KhoHang where TenHangHoa like N'" + autoCompleteTextTenHangHoa.Text + "%'", "Hang hoa").Tables["Hang hoa"];
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Equals("Tất cả loại hàng hóa") == true)
                taiGridViewHangHoa();
            else
                dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho as N'Tồn kho' from KhoHang where LoaiHangHoa like N'" + e.Node.Text + "%'", "Loai hang hoa").Tables["Loai hang hoa"];
        }

        //thêm hàng vào giỏ
        private void btnThemHangHoaVaoGio_Click(object sender, EventArgs e)
        {
            int i = dataGridViewHangHoa.CurrentCell.RowIndex;

            int stt = lstGioHang.Items.Count + 1;
            string tenHangHoa = dataGridViewHangHoa.Rows[i].Cells["Tên hàng hóa"].Value.ToString();
            string giaBan = dataGridViewHangHoa.Rows[i].Cells["Giá bán"].Value.ToString();
            int soluong = (int)numericThem.Value;
            double thanhTien = soluong * Double.Parse(giaBan);

            lstGioHang.Items.Add(stt + "");
            lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(tenHangHoa);
            lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(giaBan);
            lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(soluong + "");
            lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(thanhTien + "");
        }

        private void dataGridViewHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;//số thứ tự dòng đang được chọn trong gridview

            //lấy các giá trị cần thiết để thêm vào listview, 1 item cần có stt, tenhanghoa, giaban, soluong, thanhtien
            int stt = lstGioHang.Items.Count;
            string tenHangHoa = dataGridViewHangHoa.Rows[i].Cells["Tên hàng hóa"].Value.ToString();
            string giaBan = dataGridViewHangHoa.Rows[i].Cells["Giá bán"].Value.ToString();
            int viTri = timViTriMonHangTrongGio(tenHangHoa);
            int timKiem = hangHoaNayCoTrongGioChua(tenHangHoa);
            int soluong = 1 + timKiem;
            double thanhTien = soluong * Double.Parse(giaBan);

            if (soluong == 1)
            {
                ListViewItem item = new ListViewItem(stt + "");
                string[] subItem = { tenHangHoa, giaBan, soluong + "", thanhTien + "" };
                item.SubItems.AddRange(subItem);
                lstGioHang.Items.Add(item);

            //lstGioHang.Items.Add(stt + "");
            //lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(tenHangHoa);
            //lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(giaBan);
            //lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(soluong + "");
            //lstGioHang.Items[lstGioHang.Items.Count - 1].SubItems.Add(thanhTien + "");
            }
            else
            {
                lstGioHang.Items[viTri].SubItems[3].Text = soluong + "";
                lstGioHang.Items[viTri].SubItems[4].Text = soluong * Double.Parse(giaBan) + "";
            }
            tinhTien();
            }


        public void tinhTien()
        { 
            double thanhTien = 0;
            foreach (ListViewItem item in lstGioHang.Items)
                thanhTien += Double.Parse(item.SubItems[4].Text);
            txtTienHang.Text = thanhTien + "";
            txtGiamGia.Text = thanhTien * Double.Parse(txtPhanTramGiamGia.Text)/100 + "";
            txtTongGiaTriGioHang.Text = thanhTien + thanhTien * Double.Parse(txtPhanTramGiamGia.Text)/100 + "";
            txtTienTraLai.Text = "" + (Double.Parse(cmbTienKhachDua.SelectedItem.ToString()) - Double.Parse(txtTongGiaTriGioHang.Text)); 
        }

        public int timViTriMonHangTrongGio(string tenHang)
        {
            int vt = 0;
            foreach (ListViewItem item in lstGioHang.Items)
                if (item.SubItems[1].Text.Equals(tenHang) == true)
                    return item.Index;
            return -1;
        }

        public int hangHoaNayCoTrongGioChua(string tenHang)
        {
            int n = lstGioHang.Items.Count;
            for (int i = 0; i < n; i++)
            {
                if (lstGioHang.Items[i].SubItems[1].Text.Equals(tenHang) == true)
                {
                    return int.Parse(lstGioHang.Items[i].SubItems[3].Text.ToString());
                }
            }
            return 0;
        }

        public string timTenNhanVien(string manv)
        {
            return link.commandScalar("select TenNhanVien from NhanVien where MaNhanVien = '" + manv + "'");
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            string comm = "select count(*) from HoaDon";
            int soLuongHoaDon = int.Parse(this.link.commandScalar(comm));
            txtMaHoaDon.Text = "HOADON_" + (soLuongHoaDon + 1);
            txtNhanVien.Text = timTenNhanVien(this.manv);
            loadComBoBoxKhachHang();
            dateTimeInput1.Value = DateTime.Now;
        }

        public void loadComBoBoxKhachHang() 
        {
            SqlDataReader SDR = this.link.comManReader("select TenKhachHang from KhachHang", "TenKhachHang");
            while (SDR.Read())
            {
                cbbKhachHang.Items.Add(SDR["TenKhachHang"].ToString());
            }
            cbbKhachHang.SelectedIndex = 0;
        }

        private void txtPhanTramGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
