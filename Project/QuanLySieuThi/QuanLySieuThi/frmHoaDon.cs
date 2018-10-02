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
    }
}
