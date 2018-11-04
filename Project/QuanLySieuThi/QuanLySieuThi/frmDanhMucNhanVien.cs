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
            TaiNV();
            taiAutoCompleteText();
            if (kTraAdmin("",manv) == false)
            {
                txtMatkhau.PasswordChar = '*';
                cbbCap.Enabled = false;
                txtUsers.Enabled = false;
                txtMatkhau.Enabled = false;
            }
            btnHuyThem.Hide();
        }

        public void TaiNV()
        {
            dataGridView_Nhanvien.DataSource = this.kn.comManTable("select MaNhanVien as N'Mã nhân viên',TenNhanVien as N'Tên nhân viên' from NhanVien", "Nhan Vien").Tables["Nhan Vien"];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            txtMa.Focus();
            btnHuyThem.Show();
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dataGridView_Nhanvien.Enabled = false;
            txtMa.Enabled = true;

            //reset các text box thông tin
            txtMa.Text = taoMaNhanVien();
            txtTen.Text = "";
            dateTimeNgaySinh.Text = "";
            cboxGtinh.Text = "";
            cboxTuoi.Text = "";
            txtMail.Text = "";
            txtDiachi.Text = "";
            txtLuong.Text = "";
            cbbCap.Text = "";
            txtUsers.Text = taoMaNhanVien();
            txtMatkhau.Text = "";

            dateTimeNgaySinh.Value = DateTime.Now;
            cboxGtinh.SelectedIndex = 0;
            cbbCap.SelectedIndex = 0;
            cboxTuoi.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView_Nhanvien.SelectedRows.Count!=0)
            {
                if (txtTen.Text != "" && cboxGtinh.Text != "" && dateTimeNgaySinh.Text != "" && cboxTuoi.Text != "" && KTMail(txtMail.Text) == true && txtDiachi.Text != "" && txtLuong.Text != "" && cbbCap.Text != "" && txtUsers.Text != "" && txtMatkhau.Text != "")
                {
                    string chuoinv = "update NhanVien set TenNhanVien=N'" + txtTen.Text + "',NgaySinh='" + dateTimeNgaySinh.Text + "',GioiTinh=N'" + cboxGtinh.Text + "',Luong=" + txtLuong.Text + ",Email='" +
                        txtMail.Text + "',DiaChi=N'" + txtDiachi.Text + "',Tuoi=" + cboxTuoi.Text + ",UserName='" + txtUsers.Text + "',Passwords='" + txtMatkhau.Text + "',CapNguoiDung='" + cbbCap.Text + "' where MaNhanVien='" + txtMa.Text + "'";
                    int kq = this.kn.query(chuoinv);
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
                    MessageBox.Show("Bạn chọn nhân viên trong danh sách và sửa lại thì mới cập nhật thông tin được !","CẬP NHẬT THÔNG TIN NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private bool KtraKhoaChinh(string s)
        {
            bool kq = true;
            string i = this.kn.comMandScalar("select MaNhanVien from NhanVien where MaNhanVien='" + s + "'").Trim();
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

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView_Nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Nhanvien.SelectedRows.Count != 0)
            {
                //hiển thị thông tin của nhân viên lên textbox
                SqlDataReader dr = this.kn.comManReader("select * from NhanVien where MaNhanVien = N'" + dataGridView_Nhanvien.CurrentRow.Cells[0].Value.ToString() + "'", "NhanVien");
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
            string capNguoiDung = this.kn.comMandScalar(chuoiQuery).Trim();
            if (capNguoiDung == "Admin")
                return true;
            return false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridView_Nhanvien.CurrentCell.RowIndex;

                string maNV = dataGridView_Nhanvien.Rows[r].Cells[0].Value.ToString(); 
                if (dataGridView_Nhanvien.SelectedRows.Count!=0)
                {
                    //lưu ý : ko thể xóa tài khoảng đang đăng nhập, ko thể xóa tài khoảng admin
                    if (kTraAdmin(maNV, "") == false)
                    {
                        if (this.manv != txtMa.Text)
                        {
                            //xóa các bảng liên quan đến nhân viên này
                            //string xoathuchi = "delete ThuChi from ThuChi,HoaDon,NhanVien where ThuChi.MaNhanVienThuChi=HoaDon.MaNVLapHoaDon and HoaDon.MaNVLapHoaDon=NhanVien.MaNhanVien and MaNhanVien='" + txtMa.Text + "'";
                            string xoaChiTietHoaDon = "delete ChiTietHoaDon from ChiTietHoaDon, HoaDon , NhanVien where ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon and NhanVien.MaNhanVien = HoaDon.MaNVLapHoaDon and MaNhanVien = '" + txtMa.Text + "'";
                            string xoaHoaDon = "delete HoaDon from HoaDon, NhanVien where HoaDon.MaNVLapHoaDon = NhanVien.MaNhanVien and NhanVien.MaNhanVien = '" + txtMa.Text + "'";
                            string xoaNhanVien = "delete NhanVien where MaNhanVien = '" + txtMa.Text + "'";
                            //int kq = this.kn.query(xoathuchi);
                            int kq = this.kn.query(xoaChiTietHoaDon);
                            kq = this.kn.query(xoaHoaDon);
                            kq = this.kn.query(xoaNhanVien);
                            if (kq != 0)
                            {
                                MessageBox.Show("Đã xóa nhân viên","XÓA NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                TaiNV();
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
                            txtLuong.Text + ",'" + txtMail.Text + "',N'" + txtDiachi.Text + "'," + cboxTuoi.Text + ",'" + txtUsers.Text + "','" + txtMatkhau.Text + "','" + cbbCap.Text + "')";
                        int kq = this.kn.query(chuoi);
                        //kq = 0 them that bai
                        if (kq == 0)
                            MessageBox.Show("Không thêm nhân viên được !","THÊM NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Thêm nhân viên thành công !","THÊM NHÂN VIÊN",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            //update lại treeview
                            TaiNV();

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
                            dataGridView_Nhanvien.Enabled = true;
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
            dataGridView_Nhanvien.Enabled = true;
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

        public string taoMaNhanVien()
        {
            int dem = 0;
            int count;
            do
            {
                string chuoiCount = "select COUNT(*) from NhanVien where MaNhanVien = '200116022" + dem + "'";
                count = int.Parse(this.kn.comMandScalar(chuoiCount));
                if (count == 0)
                    return "200116022" + dem;
                dem++;
            } while (count != 0);
            return "200116022" + (dem + 1);
        }

        public void taiAutoCompleteText()
        {
            SqlDataReader rd = this.kn.comManReader("select TenNhanVien from NhanVien", "TenNhanVien");

            while (rd.Read())
            {
                txtTimtenNv.AutoCompleteCustomSource.Add(rd["TenNhanVien"].ToString());
            }
            rd.Close();

            this.kn.closeConnection();
        }

        private void txtTimtenNv_TextChanged(object sender, EventArgs e)
        {
            if (txtTimtenNv.Text.Trim().Equals("") == true)
                TaiNV();
            else
                dataGridView_Nhanvien.DataSource = this.kn.comManTable("select MaNhanVien,TenNhanVien from NhanVien where TenNhanVien like N'" + txtTimtenNv.Text + "%'", "Nhan Vien").Tables["Nhan Vien"];
        }

       
    }
}