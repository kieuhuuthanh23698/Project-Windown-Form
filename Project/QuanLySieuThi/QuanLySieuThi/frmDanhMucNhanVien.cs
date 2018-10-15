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
            if (KTMail(txtMail.Text) == false)
            {
                MessageBox.Show("Định dạng mail phải có ký tự @! Vui lòng nhập đúng định dạng tenmail@gmail.com");
                txtMail.Focus();
            }

            if (txtMa.Text != "" && txtTen.Text != "" && txtMail.Text != "" && txtCap.Text != "" && txtDiachi.Text != "" && txtLuong.Text != "" && txtUsers.Text
                != "" && txtMatkhau.Text != "")
            {
                if (KtraKhoaChinh(txtMa.Text) == true)
                {
                    MessageBox.Show("Đã tồn tại mã");
                    //ko them
                }
                else
                {
                    //them
<<<<<<< HEAD
                    int kq = this.kn.insert("INSERT INTO NhanVien VALUES('" + txtMa.Text + "',N'" + txtTen.Text + "','" + dateTimeNgaySinh.Text + "',N'" + cboxGtinh.Text + "'," 
                        + txtLuong.Text + ",'" + txtMail.Text + "','" + txtDiachi.Text + "'," + cboxTuoi.Text + ",'" + txtUsers.Text + "','" + txtMatkhau.Text + "','" + txtCap.Text + "')");
=======
                    int kq = this.kn.insert("INSERT INTO NhanVien VALUES('" + txtMa.Text + "',N'" + txtTen.Text + "','" + dateTimeNgaySinh.Text + "',N'" + cboxGtinh.Text + "'," + txtLuong.Text + ",'" + txtMail.Text + "','" + txtDiachi.Text + "'," + cboxTuoi.Text + ",'" + txtUsers.Text + "','" + txtMatkhau.Text + "','" + txtCap.Text + "')");
>>>>>>> 3497e4f3aa1fd8e6f409af3ee8364403b9a0c4af
                    //kq = 0 them that bai
                    if (kq == 0)
                        MessageBox.Show("Khong them duoc");
                    else
                    {
                        MessageBox.Show("Thêm thành công");
                        //TaoTreeViewNV();
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin của nhân viên!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "")
            {
                if (KtraKhoaChinh(txtMa.Text) == true)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại!");
                }
                else
                {
                    MessageBox.Show("Sửa thành công!");
                    //TaoTreeViewNV();
                    frmDanhMucNhanVien f = new frmDanhMucNhanVien(this.kn, manv);
                }
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

<<<<<<< HEAD
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
            cboxTuoi.SelectedIndex = 5;
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
                
            }
        }

        
=======
>>>>>>> 3497e4f3aa1fd8e6f409af3ee8364403b9a0c4af
    }
}
