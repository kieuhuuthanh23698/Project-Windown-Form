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
    public partial class frmDanhMucNhanVien : Form
    {
        KetNoiDuLieu kn;
        string manv;

        public frmDanhMucNhanVien(KetNoiDuLieu kn, string manv)
        {
            this.kn = kn;
            this.manv = manv;
            InitializeComponent();
            TaoTreeViewNV();
            if (kTraAdmin("",manv) == false)
            {
                txtMatkhau.PasswordChar = '*';
                cbbCap.Enabled = false;
                txtUsers.Enabled = false;
                txtMatkhau.Enabled = false;
            }
            btnHuyThem.Hide();
        }

        public void TaoTreeViewNV()
        {
            SqlDataReader rd = kn.comManReader("select TenNhanVien from NhanVien", "Nhan Vien");
            while (rd.Read())
            {
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(rd["TenNhanVien"].ToString());
                TreeViewNV.Nodes.Add(node);
            }
            this.kn.sql.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            txtMa.Focus();
            btnHuyThem.Show();
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            TreeViewNV.Enabled = false;
            txtMa.Enabled = true;

            //reset các text box thông tin
            txtMa.Text = "";
            txtTen.Text = "";
            dateTimeNgaySinh.Text = "";
            cboxGtinh.Text = "";
            cboxTuoi.Text = "";
            txtMail.Text = "";
            txtDiachi.Text = "";
            txtLuong.Text = "";
            cbbCap.Text = "";
            txtUsers.Text = "";
            txtMatkhau.Text = "";

            dateTimeNgaySinh.Value = DateTime.Now;
            cboxGtinh.SelectedIndex = 0;
            cbbCap.SelectedIndex = 0;
            cboxTuoi.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (TreeViewNV.SelectedNode != null)
            {
                if (txtTen.Text != "" && cboxGtinh.Text != "" && dateTimeNgaySinh.Text != "" && cboxTuoi.Text != "" && KTMail(txtMail.Text) == true && txtDiachi.Text != "" && txtLuong.Text != "" && cbbCap.Text != "" && txtUsers.Text != "" && txtMatkhau.Text != "")
                {
                    string chuoinv = "update NhanVien set TenNhanVien=N'" + txtTen.Text + "',NgaySinh='" + dateTimeNgaySinh.Text + "',GioiTinh=N'" + cboxGtinh.Text + "',Luong=" + txtLuong.Text + ",Email='" +
                        txtMail.Text + "',DiaChi=N'" + txtDiachi.Text + "',Tuoi=" + cboxTuoi.Text + ",UserName='" + txtUsers.Text + "',Passwords='" + txtMatkhau.Text + "',CapNguoiDung='" + cbbCap.Text + "' where MaNhanVien='" + txtMa.Text + "'";
                    int kq = this.kn.insert(chuoinv);
                    if (kq != 0)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!","CẬP NHẬT THÔNG TIN NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin thất bại!","CẬP NHẬT THÔNG TIN NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn phải điền đầy đủ thông tin thì mới cập nhật thông tin được !","CẬP NHẬT THÔNG TIN NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private bool KtraKhoaChinh(string s)
        {
            bool kq = true;
            string i = this.kn.commandScalar("select MaNhanVien from NhanVien where MaNhanVien='" + s + "'").Trim();
            if (i == "")
            {
                return false;
            }
            return kq;
        }

        private bool KTMail(string s)
        {
            char[] mangchuoi = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
                if (mangchuoi[i] == '@')
                    return true;
            return false;
        }

        private void frmDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            string[] tuoi = { "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "34", "35", "36", "37", "38", "39","40" };
            foreach (string s in tuoi)
            {
                cboxTuoi.Items.Add(s);
            }
            string[] gtinh = { "Nam", "Nữ" };
            foreach (string s in gtinh)
            {
                cboxGtinh.Items.Add(s);
            }
        }

        private void TreeViewNV_Click(object sender, EventArgs e)
        {
            if (TreeViewNV.SelectedNode != null)
            {
                //hiển thị thông tin của nhân viên lên textbox
                SqlDataReader dr = this.kn.comManReader("select * from NhanVien where TenNhanVien = N'" + TreeViewNV.SelectedNode.Text.Trim() + "'", "NhanVien");
                dr.Read();
                txtMa.Text = dr["MaNhanVien"].ToString().Trim();
                txtTen.Text = dr["TenNhanVien"].ToString().Trim();
                dateTimeNgaySinh.Text = dr["NgaySinh"].ToString().Trim();
                cboxGtinh.Text = dr["GioiTinh"].ToString().Trim();
                cboxTuoi.Text = dr["Tuoi"].ToString().Trim();
                txtMail.Text = dr["Email"].ToString().Trim();
                txtDiachi.Text = dr["DiaChi"].ToString().Trim();
                txtLuong.Text = dr["Luong"].ToString().Trim();
                cbbCap.Text = dr["CapNguoiDung"].ToString().Trim();
                txtUsers.Text = dr["UserName"].ToString().Trim();
                txtMatkhau.Text = dr["PassWords"].ToString().Trim();
                dr.Close();
            }
        }

        public bool kTraAdmin(string tenNhanVien, string maNhanVien)
        {
            string chuoiQuery = "select CapNguoiDung from NhanVien where TenNhanVien = N'" + tenNhanVien + "' or MaNhanVien = '" + maNhanVien + "'";
            string capNguoiDung = this.kn.commandScalar(chuoiQuery).Trim();
            if (capNguoiDung == "Admin")
                return true;
            return false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (TreeViewNV.SelectedNode != null)
                {
                    //lưu ý : ko thể xóa tài khoảng đang đăng nhập, ko thể xóa tài khoảng admin
                    if (kTraAdmin(TreeViewNV.SelectedNode.Text, "") == false)
                    {
                        if (this.manv != txtMa.Text)
                        {
                            //xóa các bảng liên quan đến nhân viên này
                            string xoathuchi = "delete ThuChi from ThuChi,HoaDon,NhanVien where ThuChi.MaNhanVienThuChi=HoaDon.MaNVLapHoaDon and HoaDon.MaNVLapHoaDon=NhanVien.MaNhanVien and MaNhanVien='" + txtMa.Text + "'";
                            string xoaChiTietHoaDon = "delete ChiTietHoaDon from ChiTietHoaDon, HoaDon , NhanVien where ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon and NhanVien.MaNhanVien = HoaDon.MaNVLapHoaDon and MaNhanVien = '" + txtMa.Text + "'";
                            string xoaHoaDon = "delete HoaDon from HoaDon, NhanVien where HoaDon.MaNVLapHoaDon = NhanVien.MaNhanVien and NhanVien.MaNhanVien = '" + txtMa.Text + "'";
                            string xoaNhanVien = "delete NhanVien where MaNhanVien = '" + txtMa.Text + "'";
                            int kq = this.kn.insert(xoathuchi);
                            kq = this.kn.insert(xoaChiTietHoaDon);
                            kq = this.kn.insert(xoaHoaDon);
                            kq = this.kn.insert(xoaNhanVien);
                            if (kq != 0)
                            {
                                MessageBox.Show("Đã xóa nhân viên","XÓA NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                TreeViewNV.Nodes.Clear();
                                TaoTreeViewNV();
                                //reset lại các text box vì nó vẫn còn chứa các thông tin của nhân viên vừa xóa
                                txtMa.Text = "";
                                txtTen.Text = "";
                                txtMail.Text = "";
                                txtDiachi.Text = "";
                                txtLuong.Text = "";
                                txtUsers.Text = "";
                                txtMatkhau.Text = "";
                            }
                        }
                        else
                            MessageBox.Show("Bạn đăng nhập bằng tài khoảng này ! Không thể xóa được !","XÓA NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Đây là Admin ! Không thể xóa !", "XÓA NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KTMail(txtMail.Text) == false)
            {
                MessageBox.Show("Định dạng mail phải có ký tự @! Vui lòng nhập đúng định dạng tenmail@gmail.com", "MAIL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
            }
            else
            {
                if (txtMa.Text != "" && txtTen.Text != "" && txtMail.Text != "" && cbbCap.Text != "" && txtDiachi.Text != "" && txtLuong.Text != "" && txtUsers.Text
                    != "" && txtMatkhau.Text != "")
                {
                    if (KtraKhoaChinh(txtMa.Text) == true)
                    {
                        MessageBox.Show("Đã tồn tại mã nhân viên này !", "THÊM NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //ko them
                    }
                    else
                    {
                        //thêm nhân vien
                        string chuoi = "INSERT INTO NhanVien VALUES('" + txtMa.Text + "',N'" + txtTen.Text + "','" + dateTimeNgaySinh.Text + "',N'" + cboxGtinh.Text+ "'," + 
                            txtLuong.Text + ",'" + txtMail.Text + "','" + txtDiachi.Text + "'," + cboxTuoi.Text + ",'" + txtUsers.Text + "','" + txtMatkhau.Text + "','" + cbbCap.Text + "')";
                        int kq = this.kn.insert(chuoi);
                        //kq = 0 them that bai
                        if (kq == 0)
                            MessageBox.Show("Không thêm nhân viên được !","THÊM NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Thêm nhân viên thành công !","THÊM NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            //update lại treeview
                            TreeViewNV.Nodes.Clear();
                            TaoTreeViewNV();

                            //reset các txt box thông tin
                            txtMa.Text = "";
                            txtTen.Text = "";
                            txtMail.Text = "";
                            txtDiachi.Text = "";
                            txtLuong.Text = "";
                            txtUsers.Text = "";
                            txtMatkhau.Text = "";

                            btnLuu.Enabled = false;
                            btnHuyThem.Hide();
                            btnThem.Enabled = true;
                            btnSua.Enabled = true;
                            btnXoa.Enabled = true;
                            TreeViewNV.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin của nhân viên!", "THÊM NHÂN VIÊN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            //reset các text box thông tin
            txtMa.Text = "";
            txtTen.Text = "";
            txtMail.Text = "";
            txtDiachi.Text = "";
            txtLuong.Text = "";
            txtUsers.Text = "";
            txtMatkhau.Text = "";

            btnHuyThem.Hide();
            TreeViewNV.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

    }
}