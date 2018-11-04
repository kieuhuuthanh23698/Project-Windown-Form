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
    public partial class frmThemNhomMatHang : Form
    {
        KetNoiDuLieu link;

        public frmThemNhomMatHang(KetNoiDuLieu link)
        {
            this.link = link;
            InitializeComponent();
        }

        public bool ktraKhoaChinh(string maLoaiMatHang, DataTable tbLoaiMatHang)
        {
            int n = tbLoaiMatHang.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                string s = tbLoaiMatHang.Rows[i]["MaLoaiHangHoa"].ToString().Trim();
                if (maLoaiMatHang == tbLoaiMatHang.Rows[i]["MaLoaiHangHoa"].ToString().Trim())
                    return true;
            }
            return false;
        }

        private void btnThemNhomMatHang_Click(object sender, EventArgs e)
        {
            //string command;
            //lấy 2 chuỗi mã và tên, thực hiện insert vào csdl, trước khi thêm phải kiểm tra xem loại hàng hóa này đã có chưa
            //tên và mã của loại hàng hóa ko dc trùng 
            if (txtMaNhomMatHang.Text != "" && txtTenNhomMatHang.Text != "")
            {
                //thêm loại mặt hàng bằng command

                //if (this.link.commandScalar("select MaLoaiHangHoa from LoaiHangHoa where MaLoaiHangHoa = '" + txtMaNhomMatHang.Text + "'").Trim() == "" && this.link.commandScalar("select MaLoaiHangHoa from LoaiHangHoa where TenLoaiHangHoa = N'" + txtTenNhomMatHang.Text + "'").Trim() == "")
                //{
                //    command = "insert into LoaiHangHoa values('" + txtMaNhomMatHang.Text.ToUpper() + "',N'" + txtTenNhomMatHang.Text.ToUpper() + "')";
                //    int i = this.link.insert(command);
                //    if (i != 0)
                //        MessageBox.Show("Thêm thành công !", "Thêm nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    else
                //        MessageBox.Show("Thêm thất bại !", "Thêm nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    this.Close();
                //}
                //else
                //    MessageBox.Show("Đã có nhóm mặt hàng này !","Thêm nhóm mặt hàng",MessageBoxButtons.OK,MessageBoxIcon.Error);


                //--------------------------------------thêm loại mặt hàng bằng data set---------------------------------------------
                SqlConnection sql = this.link.getSql();
                string queryLoaiHangHoa = "select * from LoaiHangHoa";
                SqlDataAdapter dataAdapter_LoaiHangHoa = new SqlDataAdapter(queryLoaiHangHoa,sql);
                DataSet dataSet_LoaiHangHoa = new DataSet();
                dataAdapter_LoaiHangHoa.Fill(dataSet_LoaiHangHoa,"LoaiHangHoa");
                DataTable dataTable_LoaiMatHang = dataSet_LoaiHangHoa.Tables["LoaiHangHoa"];
                if (ktraKhoaChinh(txtMaNhomMatHang.Text, dataTable_LoaiMatHang) == false)//không trùng khóa chính
                {
                    DataRow newRow = dataTable_LoaiMatHang.NewRow();
                    newRow[0] = txtMaNhomMatHang.Text;
                    newRow[1] = txtTenNhomMatHang.Text;
                    dataTable_LoaiMatHang.Rows.Add(newRow);
                    SqlCommandBuilder commandBuilderLoaiHangHoa = new SqlCommandBuilder(dataAdapter_LoaiHangHoa);
                    commandBuilderLoaiHangHoa.GetInsertCommand();//chú ý : khi insert thì phải getInsertCommand()
                    dataAdapter_LoaiHangHoa.Update(dataTable_LoaiMatHang); 
                    MessageBox.Show("Thêm thành công !", "Thêm nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Đã có nhóm mặt hàng này !", "Thêm nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenNhomMatHang_TextChanged(object sender, EventArgs e)
        {
            //kiểm tra độ dài tên nhóm mặt hàng, nếu quá 50 kí tự thì ko cho nhập, đồng thời báo lỗi qua error provider
            if (txtTenNhomMatHang.Text.Length > 50)
            //                errorProvider1.SetError(txtTenNhomMatHang,"Tên nhóm mặt hàng không được dài quá 50 kí tự")
            {
                balloonTip1.SetBalloonText(txtTenNhomMatHang, "Tên nhóm mặt hàng không được dài quá 50 kí tự");
                balloonTip1.ShowBalloon(txtTenNhomMatHang);
            }
            else
                balloonTip1.RemoveAll();

        }

        private void txtTenNhomMatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTenNhomMatHang.Text.Length > 50 && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtMaNhomMatHang_TextChanged(object sender, EventArgs e)
        {
            //kiểm tra độ dài tên nhóm mặt hàng, nếu quá 20 kí tự thì ko cho nhập, đồng thời báo lỗi qua error provider
            if (txtMaNhomMatHang.Text.Length > 20)
            {
                balloonTip1.SetBalloonText(txtMaNhomMatHang, "Mã nhóm mặt hàng không được quá 20 kí tự");
                balloonTip1.ShowBalloon(txtMaNhomMatHang);
            }
            else
                balloonTip1.RemoveAll(); ;
        }

        private void txtMaNhomMatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaNhomMatHang.Text.Length > 20 && e.KeyChar != '\b')
                e.Handled = true;
        }

    }
}
