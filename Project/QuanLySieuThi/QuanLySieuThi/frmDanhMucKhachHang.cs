using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLySieuThi
{
    public partial class frmDanhMucKhachHang : Form
    {
        KetNoiDuLieu kn;
        string makh;
        public frmDanhMucKhachHang( KetNoiDuLieu kn,string makh)
        {
            this.kn = kn;
            this.makh = makh;
            InitializeComponent();
            TaiGridViewKhachHang();
        }

        public void TaiGridViewKhachHang()
        {
            dataGridViewKhachHang.DataSource = this.kn.comManTable("select MaKhachHang,TenKhachHang,SoDienThoai from KhachHang","Khach Hang").Tables["Khach Hang"];
        }

        private bool KtraKhoaChinh(string s)
        {
            bool kq = true;
            string i = this.kn.commandScalar("select MaKhachHang from KhachHang where MaKhachHang='" + s + "'").Trim();
            if (i == "")
            {
                return false;
            }
            return kq;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMa.Focus();
            btnLuu.Enabled = true;
        }


        private void btnChinhsua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "" && txtTen.Text != "" && txtSDT.Text != "")
            {
                string chuoisua = "update KhachHang set TenKhachHang=N'"+txtTen.Text+"',SoDienThoai='"+txtSDT.Text+"' where MaKhachHang='"+txtMa.Text+"'";
                int kq = this.kn.insert(chuoisua);
                if (kq != 0)
                {
                    MessageBox.Show("Đã sửa thành công!");
                    TaiGridViewKhachHang();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewKhachHang.SelectedRows.Count!=0)
            {
                string chuoixoahd = "delete HoaDon from HoaDon,KhachHang where HoaDon.MaKhachHang=KhachHang.MaKhachHang and HoaDon.MaKhachHang='"+txtMa.Text+"'";
                int kq = this.kn.insert(chuoixoahd);
                if (kq != 0)
                {
                    string chuoixoakh = "delete KhachHang from KhachHang where MaKhachHang='"+txtMa.Text+"'";
                    kq = this.kn.insert(chuoixoakh);
                    if (kq != 0)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!");
                        TaiGridViewKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtMa.Text != "" && txtTen.Text != "" && txtSDT.Text != "")
            {
                if (KtraKhoaChinh(txtMa.Text) == true)
                {
                    MessageBox.Show("Đã tồn tại mã");
                }
                else
                {
                    int kq = this.kn.insert("insert into KhachHang values('" + txtMa.Text + "',N'" + txtTen.Text + "','" + txtSDT.Text + ")");
                    if (kq == 0)
                        MessageBox.Show("Khong them duoc");
                    else
                    {
                        MessageBox.Show("Thêm thành công");
                        TaiGridViewKhachHang();
                    }
                }
            }
            btnXoa.Enabled = true;
            btnChinhsua.Enabled = true;
        }

        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string chuoikh = " select MaKhachHang,TenKhachHang,SoDienThoai from KhachHang";
                dataGridViewKhachHang.DataSource = this.kn.comManTable(chuoikh,"KhachHang").Tables["KhachHang"];
                txtMa.DataBindings.Clear();
                txtMa.DataBindings.Add("text",MaKhachHang,"MaKhachHang");
                txtTen.DataBindings.Clear();
                txtTen.DataBindings.Add("text",TenKhachHang,"TenKhachHang");
                txtSDT.DataBindings.Clear();
                txtMa.DataBindings.Add("text",SoDienThoai,"SoDienThoai");
            }
            catch (Exception)
            { }
        }



 
    }
}
