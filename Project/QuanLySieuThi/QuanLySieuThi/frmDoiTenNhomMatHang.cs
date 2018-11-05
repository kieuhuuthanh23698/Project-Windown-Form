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
    public partial class  frmDoiTenNhomMatHang : Form
    {
        KetNoiDuLieu link;
        string ten;

        public frmDoiTenNhomMatHang(string ten,KetNoiDuLieu link)
        {
            this.link = link;
            this.ten = ten;
            InitializeComponent();
            txtTenNhomMatHang.Text = ten;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenNhomMatHang.Text.Equals(ten) == false)
                {
                    //load bảng Loại hàng hóa từ csdl lên bộ nhớ
                    SqlConnection sql = this.link.getSql();
                    string queryLoaiHangHoa = "select * from LoaiHangHoa";
                    SqlDataAdapter dataAdapter_LoaiHangHoa = new SqlDataAdapter(queryLoaiHangHoa, sql);
                    DataSet dataSet_LoaiHangHoa = new DataSet();
                    dataAdapter_LoaiHangHoa.Fill(dataSet_LoaiHangHoa, "LoaiHangHoa");
                    DataTable dataTable_LoaiMatHang = dataSet_LoaiHangHoa.Tables["LoaiHangHoa"];

                    //thực hiện sửa đổi
                    int n = dataTable_LoaiMatHang.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {
                        if (dataTable_LoaiMatHang.Rows[i]["TenLoaiHangHoa"].ToString().Trim() == ten)
                        {
                            dataTable_LoaiMatHang.Rows[i]["TenLoaiHangHoa"] = txtTenNhomMatHang.Text;
                            break;
                        }
                    }

                    //update bảng Loại hàng hóa từ bộ nhớ xuống csdl
                    SqlCommandBuilder commandBuilderLoaiHangHoa = new SqlCommandBuilder(dataAdapter_LoaiHangHoa);
                    commandBuilderLoaiHangHoa.GetUpdateCommand();//chú ý : khi update thì phải getUpdateCommand()
                    dataAdapter_LoaiHangHoa.Update(dataTable_LoaiMatHang);
                    MessageBox.Show("Sửa thành công !", "Sửa tên nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
