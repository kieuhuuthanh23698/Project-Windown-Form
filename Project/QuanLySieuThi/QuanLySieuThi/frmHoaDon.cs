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
            ImageList im = new ImageList();
            im.Images.Add(QuanLySieuThi.Properties.Resources.father_node);
            im.Images.Add(QuanLySieuThi.Properties.Resources.child_node);
            treeView1.ImageList = im;
        }

        public void taiGridViewHangHoa()
        {
             dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoLuongTrongKho as N'Số lượng' from KhoHang where SoluongTrongKho > 0","Hang hoa").Tables["Hang hoa"];            
        }

        public void taiTreeView()
        {
            SqlDataReader rd = this.link.comManReader("select TenLoaiHangHoa from LoaiHangHoa", "LoaiHangHoa");
            treeView1.Nodes[0].ImageIndex = 0;
            int i = 0;
            while (rd.Read())
            {
                treeView1.Nodes[0].Nodes.Add(rd["TenLoaiHangHoa"].ToString());
                treeView1.Nodes[0].Nodes[i].ImageIndex = 1;
                i++;
            }

            rd.Close();

            if (this.link.state() == ConnectionState.Open)
                this.link.sql.Close();
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

            if (this.link.state() == ConnectionState.Open)
                this.link.sql.Close();
        }

        private void autoCompleteTextTenHangHoa_TextChanged(object sender, EventArgs e)
        {
            if (autoCompleteTextTenHangHoa.Text.Trim().Equals("") == true)
                taiGridViewHangHoa();
            else
                dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị'from KhoHang where TenHangHoa like N'" + autoCompleteTextTenHangHoa.Text + "%'", "Hang hoa").Tables["Hang hoa"];
            if (link.state() == ConnectionState.Open)
                this.link.sql.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Equals("Tất cả loại hàng hóa") == true)
                taiGridViewHangHoa();
            else
                dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho  as N'Số lượng' from KhoHang where SoluongTrongKho > 0 AND LoaiHangHoa like N'" + e.Node.Text + "%'", "Loai hang hoa").Tables["Loai hang hoa"];
            if (link.state() == ConnectionState.Open)
                this.link.sql.Close();
        }

        public void capNhatKhoHangKhiThem(string tenHangHoa, int soluongThem)
        {
            int soLuongHangHoaNayTrongKho = int.Parse(this.link.commandScalar("select SoluongTrongKho from KhoHang where TenHangHoa = N'" + tenHangHoa + "'"));
            int i = 0;
            if (soluongThem >= soLuongHangHoaNayTrongKho)
                i = this.link.insert("update KhoHang set SoluongTrongKho = 0 where TenHangHoa = N'" + tenHangHoa + "'");
            else
            { //so luong thêm < số lượng hàng hóa này trong kho
                int capNhatSoLuongHangHoa = soLuongHangHoaNayTrongKho - soluongThem;
                i = this.link.insert("update KhoHang set SoluongTrongKho = " + capNhatSoLuongHangHoa + " where TenHangHoa = N'" + tenHangHoa + "'");
            }
        }

        private void btnThemHangHoaVaoGio_Click(object sender, EventArgs e)
        {
            int i = dataGridViewHangHoa.CurrentCell.RowIndex;
            if (i > -1)
            {
                int stt = lstGioHang.Items.Count;
                string tenHangHoa = dataGridViewHangHoa.Rows[i].Cells["TenHangHoa"].Value.ToString();
                string giaBan = dataGridViewHangHoa.Rows[i].Cells["GiaBan"].Value.ToString();
                //nếu mà numberic lờn hơn hoặc bằng số lượng kho kho thì chỉ có thể thêm đúng số lượng còn trong kho và sau khi thêm thì update số lượng về = 0
                //còn nếu bé hơn thì thêm và cập nhật lại số lượng hàng hóa đó còn trong kho với giá trị mới = số lượng trong kho - số lượng thêm
                int viTri = timViTriMonHangTrongGio(tenHangHoa);
                int timKiem = hangHoaNayCoTrongGioChua(tenHangHoa);//trả về số lượng hàng hóa nếu có trong giỏ
                int soLuongHangHoaNayTrongKho = int.Parse(this.link.commandScalar("select SoluongTrongKho from KhoHang where TenHangHoa = N'" + tenHangHoa + "'"));
                int soluong;
                if ((int)Int64.Parse(numericThem.Value.ToString()) >= soLuongHangHoaNayTrongKho)
                    soluong = soLuongHangHoaNayTrongKho + timKiem;
                else
                    soluong = (int)Int64.Parse(numericThem.Value.ToString()) + timKiem;
                double thanhTien = soluong * Double.Parse(giaBan);

                if (timKiem == 0)
                {
                    ListViewItem item = new ListViewItem(stt + "");
                    string[] subItem = { tenHangHoa, giaBan, soluong + "", thanhTien + "" };
                    item.SubItems.AddRange(subItem);
                    lstGioHang.Items.Add(item);
                }
                else
                {
                    lstGioHang.Items[viTri].SubItems[3].Text = soluong + "";
                    lstGioHang.Items[viTri].SubItems[4].Text = soluong * Double.Parse(giaBan) + "";
                }
                capNhatKhoHangKhiThem(tenHangHoa, (int)Int64.Parse(numericThem.Value.ToString()));
                numericThem.Value = 1;
                tinhTien();
                taiGridViewHangHoa();
            }
        }

        private void dataGridViewHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i > -1)
            {
                int stt = lstGioHang.Items.Count;
                string tenHangHoa = dataGridViewHangHoa.Rows[i].Cells["TenHangHoa"].Value.ToString();
                string giaBan = dataGridViewHangHoa.Rows[i].Cells["GiaBan"].Value.ToString();
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
                }
                else
                {
                    lstGioHang.Items[viTri].SubItems[3].Text = soluong + "";
                    lstGioHang.Items[viTri].SubItems[4].Text = soluong * Double.Parse(giaBan) + "";
                }
                capNhatKhoHangKhiThem(tenHangHoa, 1);
                taiGridViewHangHoa();
                tinhTien();
            }
            }

        public void tinhTien()
        { 
            //tính thành tiền
            double thanhTien = 0;
            foreach (ListViewItem item in lstGioHang.Items)
                thanhTien += Double.Parse(item.SubItems[4].Text);
            txtTienHang.Text = thanhTien + "";
            //giảm giá
            if (txtPhanTramGiamGia.Text != "")
                {
                    int phantram = (int)Int64.Parse(txtPhanTramGiamGia.Text);
                    txtGiamGia.Text = Double.Parse(txtTienHang.Text) * phantram / 100 + "";
                }
            txtTongGiaTriGioHang.Text = (Double.Parse(txtTienHang.Text) - Double.Parse(txtGiamGia.Text)) + "";
            if (cmbTienKhachDua.Text != "")
            {
                txtTienTraLai.Text = (Int64.Parse(cmbTienKhachDua.Text) - Double.Parse(txtTongGiaTriGioHang.Text)) + "";
            }
        }

        public int timViTriMonHangTrongGio(string tenHang)
        {
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
                    return (int)Int64.Parse(lstGioHang.Items[i].SubItems[3].Text.ToString());
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
            int soLuongHoaDon = (int)Int64.Parse(this.link.commandScalar(comm));
            txtMaHoaDon.Text = "HOADON_" + (soLuongHoaDon + 1);
            txtNhanVien.Text = timTenNhanVien(this.manv);
            loadComBoBoxKhachHang();
            dateTimeInput1.Value = DateTime.Now;
            txtGio.Text = dateTimeInput1.Value.ToShortTimeString();
            /////////
            lstGioHang.Items.Clear();
            txtTienHang.Text = "0";
            txtGiamGia.Text = "0";
            txtPhanTramGiamGia.Text = "0";
            txtTongGiaTriGioHang.Text = "0";
            txtTienTraLai.Text = "0";
        }

        public void loadComBoBoxKhachHang() 
        {
            SqlDataReader SDR = this.link.comManReader("select TenKhachHang from KhachHang", "TenKhachHang");
            
            while (SDR.Read())
            {
                cbbKhachHang.Items.Add(SDR["TenKhachHang"].ToString());
            }

            SDR.Close();

            if (this.link.state() == ConnectionState.Open)
                this.link.sql.Close();
            cbbKhachHang.SelectedIndex = 0;
        }

        private void txtPhanTramGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void cmbTienKhachDua_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mỗi lần số tiền khách đưa thay đổi thì tính tiền lại
            tinhTien();
        }

        private void txtPhanTramGiamGia_TextChanged(object sender, EventArgs e)
        {
            //đảm bảo giá trị trị phần trm8 luôn nhỏ hơn 100
            if (txtPhanTramGiamGia.Text.Length > 2)
            {
                string s = txtPhanTramGiamGia.Text;
                txtPhanTramGiamGia.Text = s.Substring(0, 2);
            }
            tinhTien();
        }

        private void cmbTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            tinhTien();
        }

        private void cmbTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void btnXoaHangTrongGio_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lstGioHang.SelectedItems)
            {
                string tenHangHoa = i.SubItems[1].Text;
                int soLuongHangHoaNayTrongKho = int.Parse(this.link.commandScalar("select SoluongTrongKho from KhoHang where TenHangHoa = N'" + tenHangHoa + "'"));
                int soLuongNew = soLuongHangHoaNayTrongKho + int.Parse(i.SubItems[3].Text);
                int kq = this.link.insert("update KhoHang set SoluongTrongKho = " + soLuongNew + " where TenHangHoa = N'" + tenHangHoa + "'");
                lstGioHang.Items.Remove(i);
            }
            taiGridViewHangHoa();
            tinhTien();
        }

        private void btnTangSoLuong_Click(object sender, EventArgs e)
        {
            int i;
            if (lstGioHang.SelectedItems.Count != 0)
            {
                i = lstGioHang.Items.IndexOf(lstGioHang.SelectedItems[0]);
                string tenHangHoa = lstGioHang.Items[i].SubItems[1].Text;
                int soLuongHangHoaNayTrongKho = int.Parse(this.link.commandScalar("select SoluongTrongKho from KhoHang where TenHangHoa = N'" + tenHangHoa + "'"));
                if (int.Parse(numericTang.Value.ToString()) >= soLuongHangHoaNayTrongKho)
                    lstGioHang.Items[i].SubItems[3].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) + soLuongHangHoaNayTrongKho) + "";
                else
                    lstGioHang.Items[i].SubItems[3].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) + int.Parse(numericTang.Value.ToString())) + "";
                lstGioHang.Items[i].SubItems[4].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text)*Double.Parse(lstGioHang.Items[i].SubItems[2].Text)) + "";
                capNhatKhoHangKhiThem(tenHangHoa, (int)Int64.Parse(numericTang.Value.ToString()));
                numericTang.Value = 1;
                taiGridViewHangHoa();
                tinhTien();
            }
        }

        private void btnGiamSoLuong_Click(object sender, EventArgs e)
        {
            int i;
            if (lstGioHang.SelectedItems.Count != 0)
            {
                i = lstGioHang.Items.IndexOf(lstGioHang.SelectedItems[0]);
                string tenHangHoa = lstGioHang.SelectedItems[0].SubItems[1].Text;
                // nếu số lượng giảm của numberic lớn hơn hoặc băng số lượng hàng hóa đó thì xóa hàng đó ra khỏi giỏ
                if (int.Parse(numericGiam.Value.ToString()) >= int.Parse(lstGioHang.Items[i].SubItems[3].Text))
                {
                    int soLuongHangHoaNayTrongKho = int.Parse(this.link.commandScalar("select SoluongTrongKho from KhoHang where TenHangHoa = N'" + tenHangHoa + "'"));
                    int soLuongNew = soLuongHangHoaNayTrongKho + int.Parse(lstGioHang.Items[i].SubItems[3].Text);
                    int k = this.link.insert("update KhoHang set SoluongTrongKho = " + soLuongNew + " where TenHangHoa = N'" + tenHangHoa + "'");
                    lstGioHang.Items.Remove(lstGioHang.Items[i]);
                }
                //ngược lại thì giảm số lượng và tinh lại tiền hàng
                else
                {
                    int soLuongHangHoaNayTrongKho = int.Parse(this.link.commandScalar("select SoluongTrongKho from KhoHang where TenHangHoa = N'" + tenHangHoa + "'"));
                    int soLuongNew = soLuongHangHoaNayTrongKho + int.Parse(numericGiam.Value.ToString());
                    int kq = this.link.insert("update KhoHang set SoluongTrongKho = " + soLuongNew + " where TenHangHoa = N'" + tenHangHoa + "'");
                    lstGioHang.Items[i].SubItems[3].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) - int.Parse(numericGiam.Value.ToString())) + "";
                    lstGioHang.Items[i].SubItems[4].Text = (int.Parse(lstGioHang.Items[i].SubItems[3].Text) * Double.Parse(lstGioHang.Items[i].SubItems[2].Text)) + "";
                }
                taiGridViewHangHoa();
                numericGiam.Value = 1;
                tinhTien();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            //chỉ thanh toán khi :
            //  số tiền trả lại >= 0 
            //  trong giỏ có hàng
            //  tất cả các thông tin cần thiết đều có
            //sau khi insert hóa đơn
            // insert từng chi tiết hóa đơn 
            if (Double.Parse(txtTienTraLai.Text) >= 0)
            {
                if (lstGioHang.Items.Count > 0)
                {
                    string maHoaDon = txtMaHoaDon.Text;
                    string ngayLapHoaDon = dateTimeInput1.Value.ToShortDateString();
                    string tenNhanVienLapHoaDon = txtNhanVien.Text;
                    string maNVLapHoaDon = manv;
                    string tenKhachHang = cbbKhachHang.Text;
                    string maKhachHang = this.link.commandScalar("select MaKhachHang from KhachHang where TenKhachHang = N'" + tenKhachHang + "'");
                    string tienHang = txtTienHang.Text;
                    string phanTramGiamGia = txtPhanTramGiamGia.Text;
                    string giamGia = txtGiamGia.Text;
                    string tongThanhTien = txtTongGiaTriGioHang.Text;
                    string khachDua = cmbTienKhachDua.Text;
                    string traLai = txtTienTraLai.Text;
                    string command = "insert into HoaDon values('" + maHoaDon + "','" + ngayLapHoaDon + "',GETDATE(),N'" + tenNhanVienLapHoaDon + "','" + maNVLapHoaDon + "',N'" + tenKhachHang + "','" + maKhachHang + "'," + tienHang + "," + phanTramGiamGia + "," + giamGia + "," + tongThanhTien + "," + khachDua + "," + traLai + ")";
                    if (this.link.insert(command) != 0)
                    {
                        MessageBox.Show("Mã hóa đơn :" + maHoaDon + "\n" + "Ngày lập hóa đơn" + ngayLapHoaDon + "\n" + "Tên nhân viên lập hóa đơn :" + tenNhanVienLapHoaDon + "\n" + "Mã nv lập hóa đơn :" + maNVLapHoaDon + "\n" + "Tên khách hàng :" + tenKhachHang + "\n" + "Mã khách hàng :" + maKhachHang + "\n" + "Tiền hàng :" + tienHang + " Đ\n" + "Phần trăm giảm giá :" + phanTramGiamGia + "\n" + "Giảm giá :" + giamGia + " Đ\n" + "Tổng thành tiền :" + tongThanhTien + " Đ\n" + "Khách đưa :" + khachDua + " Đ\n" + "Trả lại :" + traLai + " Đ", "Hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (ListViewItem item in lstGioHang.Items)
                        {//insert các thành phần trong chi tiết hóa đơn
                            string tenHangHoa = item.SubItems[1].Text;
                            string maHangHoa = this.link.commandScalar("select MaHangHoa from KhoHang where TenHangHoa = N'" + tenHangHoa + "'");
                            string giaBan = item.SubItems[2].Text;
                            string soLuong = item.SubItems[3].Text;
                            string thanhTien = item.SubItems[4].Text;
                            this.link.insert("insert into ChiTietHoaDon values('" + maHoaDon + "','" + maHangHoa + "',N'" + tenHangHoa + "'," + giaBan + "," + soLuong + "," + thanhTien + ")");
                        }
                        frmReportHoaDon frmHD = new frmReportHoaDon(this.link, maHoaDon);
                        frmHD.ShowDialog();
                    }
                    else
                        MessageBox.Show("Thanh toán bị lỗi !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    taoHoaDonMoi();
                }

            }
            else
                MessageBox.Show("Khách chưa đưa đủ tiền !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void taoHoaDonMoi()
        {
            //Tạo hóa đơn mới
            string comm = "select count(*) from HoaDon";
            int soLuongHoaDon = (int)Int64.Parse(this.link.commandScalar(comm));
            txtMaHoaDon.Text = "HOADON_" + (soLuongHoaDon + 1);
            txtNhanVien.Text = timTenNhanVien(this.manv);
            loadComBoBoxKhachHang();
            dateTimeInput1.Value = DateTime.Now;
            lstGioHang.Items.Clear();
            txtTienHang.Text = "0";
            txtGiamGia.Text = "0";
            txtPhanTramGiamGia.Text = "0";
            txtTongGiaTriGioHang.Text = "0";
            txtTienTraLai.Text = "0";
        }
       
    }

}
