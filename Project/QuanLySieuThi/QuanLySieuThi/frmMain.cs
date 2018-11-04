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
    public partial class frmMain : Form
    {
        KetNoiDuLieu link;
        string manv;

        public string timTenNhanVien(string manv)
        {
            return link.comMandScalar("select TenNhanVien from NhanVien where MaNhanVien = '" + manv + "'");
        }

        public frmMain(KetNoiDuLieu link, string manv)
        {
            InitializeComponent();
            this.link = link;
            this.manv = manv;
            lblTenNhanVien.Text = timTenNhanVien(manv);
            frmHoaDon f = new frmHoaDon(this.link, this.manv);
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            dockContainerItem1.Control.Controls.Add(f);
            f.Show();
        }

        private void logout(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin(this.link);
            frmLogin.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Exit();    
        }

        private void changePass(object sender, EventArgs e)
        {
            frmDoiMatKhau frmChangePass = new frmDoiMatKhau(this.manv,this.link);
            frmChangePass.ShowDialog();
        }
        
        private void openHoaDon(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for (int i = 0; i < tab.Items.Count; i++)
            {
                if (tab.Items[i].ToString() == "Hóa đơn")
                {
                    tonTai = true;
                    break;
                }
            }
            if (tonTai == false)//nếu chưa có thì mở tab này lên
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Hóa đơn", "Hóa đơn");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.bill_icon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Hóa đơn";
                item.Control = new Control();
                item.Control = panel;
                frmHoaDon f = new frmHoaDon(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            else
            {
                tab.Items.Clear();
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Hóa đơn", "Hóa đơn");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.bill_icon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Hóa đơn";
                item.Control = new Control();
                item.Control = panel;
                frmHoaDon f = new frmHoaDon(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
        }

        private void openDanhMucMatHang(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < tab.Items.Count; i++)
                if (tab.Items[i].ToString() == "Danh mục mặt hàng")
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục mặt hàng", "Danh mục mặt hàng");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.hang_hoa;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục mặt hàng";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucMatHang f = new frmDanhMucMatHang(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            else
            {
                tab.Items.Clear();
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục mặt hàng", "Danh mục mặt hàng");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.hang_hoa;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục mặt hàng";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucMatHang f = new frmDanhMucMatHang(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
        }

        private void openDanhMucKhachHang(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < tab.Items.Count; i++)
                if (tab.Items[i].ToString() == "Danh mục khách hàng")
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("", "Danh mục khách hàng");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.khach_hang_2;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục khách hàng";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucKhachHang f = new frmDanhMucKhachHang(this.link);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            else
            {
                tab.Items.Clear();
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("", "Danh mục khách hàng");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.khach_hang_2;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục khách hàng";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucKhachHang f = new frmDanhMucKhachHang(this.link);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
        }

        private void openDanhMucNhanVien(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < tab.Items.Count; i++)
                if (tab.Items[i].ToString() == "Danh mục nhân viên")
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục nhân viên", "Danh mục nhân viên");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.nhan_vien;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục nhân viên";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucNhanVien f = new frmDanhMucNhanVien(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            else
            {
                tab.Items.Clear();
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục nhân viên", "Danh mục nhân viên");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.nhan_vien;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục nhân viên";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucNhanVien f = new frmDanhMucNhanVien(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
        }

        private void openThongKeHoaDon(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < tab.Items.Count; i++)
                if (tab.Items[i].ToString() == "Thống kê hóa đơn")
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thống kê hóa đơn", "Thống kê hóa đơn");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.thongkeHoaDon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Thống kê hóa đơn";
                item.Control = new Control();
                item.Control = panel;
                frmThongKeHoaDon f = new frmThongKeHoaDon(this.link);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            else
            {
                tab.Items.Clear();
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thống kê hóa đơn", "Thống kê hóa đơn");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.thongkeHoaDon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Thống kê hóa đơn";
                item.Control = new Control();
                item.Control = panel;
                frmThongKeHoaDon f = new frmThongKeHoaDon(this.link);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
        }

        private void openThongTinCuaHang(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < tab.Items.Count; i++)
                if (tab.Items[i].ToString() == "Thông tin cửa hàng")
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thông tin cửa hàng", "Thông tin cửa hàng");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.store_icon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Thông tin cửa hàng";
                item.Control = new Control();
                item.Control = panel;
                frmThongTinSieuThi f = new frmThongTinSieuThi(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            else
            {
                tab.Items.Clear();
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thông tin cửa hàng", "Thông tin cửa hàng");
                tab.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.store_icon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Thông tin cửa hàng";
                item.Control = new Control();
                item.Control = panel;
                frmThongTinSieuThi f = new frmThongTinSieuThi(this.link, this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
        }

        private void bar2_DockTabClosed(object sender, DevComponents.DotNetBar.DockTabClosingEventArgs e)
        {
            if (tab.Items.Count == 1)
                tab.Items.Clear();
            tab.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
