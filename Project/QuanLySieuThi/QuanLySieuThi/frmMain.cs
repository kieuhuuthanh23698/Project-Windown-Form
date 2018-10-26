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

        public string timTenNhanVien(string manv)
        {
            return link.commandScalar("select TenNhanVien from NhanVien where MaNhanVien = '" + manv + "'");
        }

        KetNoiDuLieu link;
        string manv;

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
            frmDoiMatKhau frmChangePass = new frmDoiMatKhau();
            frmChangePass.ShowDialog();
        }

        private void danhMucMatHang(object sender, EventArgs e)
        {
        }
        
        private void openHoaDon(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < bar2.Items.Count; i++)
                if (bar2.Items[i].Equals("Hóa đơn") == true)
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Hóa đơn", "Hóa đơn");
                bar2.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.bill_icon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Hóa đơn";
                item.Control = new Control();
                item.Control = panel;
                frmHoaDon f = new frmHoaDon(this.link,this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            //đã có tab này
            else
            {
                for(int i = 0; i < bar2.Items.Count; i++)
                    if (bar2.Items[i].Equals("Hóa đơn") == true)
                    {
                        //mở tab này nếu nó đang đóng
                        bar2.Items.Clear();
                        
                        DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Hóa đơn", "Hóa đơn");
                        bar2.Items.Add(item);
                        Image a = global::QuanLySieuThi.Properties.Resources.bill_icon;
                        item.Image = a;
                        item.Selected = true;
                        DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                        panel.Name = "Hóa đơn";
                        item.Control = new Control();
                        item.Control = panel;
                        frmHoaDon f = new frmHoaDon(this.link,this.manv);
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        item.Control.Controls.Add(f);
                        f.Show();
                        break;
                    }
            }
        }

        private void openDanhMucMatHang(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < bar2.Items.Count; i++)
                if (bar2.Items[i].Equals("Danh mục mặt hàng") == true)
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục mặt hàng", "Danh mục mặt hàng");
                bar2.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.hang_hoa;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục mặt hàng";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucMatHang f = new frmDanhMucMatHang(this.link,this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            //đã có tab này
            else
            {
                for(int i = 0; i < bar2.Items.Count; i++)
                    if (bar2.Items[i].Equals("Danh mục mặt hàng") == true)
                    {
                        //mở tab này nếu nó đang đóng
                        bar2.Items.Clear();
                        
                        DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục mặt hàng", "Danh mục mặt hàng");
                        bar2.Items.Add(item);
                        Image a = global::QuanLySieuThi.Properties.Resources.bill_icon;
                        item.Image = a;
                        item.Selected = true;
                        DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                        panel.Name = "Danh mục mặt hàng";
                        item.Control = new Control();
                        item.Control = panel;
                        frmDanhMucMatHang f = new frmDanhMucMatHang(this.link,this.manv);
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        item.Control.Controls.Add(f);
                        f.Show();
                        break;
                    }
            }
        }

        private void openDanhMucKhachHang(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < bar2.Items.Count; i++)
                if (bar2.Items[i].Equals("Danh mục khách hàng") == true)
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("", "Danh mục khách hàng");
                bar2.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.khach_hang_2;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục khách hàng";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucKhachHang f = new frmDanhMucKhachHang(this.link,this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            //đã có tab này
            else
            {
                for(int i = 0; i < bar2.Items.Count; i++)
                    if (bar2.Items[i].Equals("Danh mục khách hàng") == true)
                    {
                        //mở tab này nếu nó đang đóng
                        bar2.Items.Clear();
                        
                        DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục khách hàng", "Danh mục khách hàng");
                        bar2.Items.Add(item);
                        Image a = global::QuanLySieuThi.Properties.Resources.bill_icon;
                        item.Image = a;
                        item.Selected = true;
                        DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                        panel.Name = "Danh mục khách hàng";
                        item.Control = new Control();
                        item.Control = panel;
                        frmDanhMucKhachHang f = new frmDanhMucKhachHang(this.link,this.manv);
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        item.Control.Controls.Add(f);
                        f.Show();
                        break;
                    }
            }
        }

        private void openDanhMucNhanVien(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < bar2.Items.Count; i++)
                if (bar2.Items[i].Equals("Danh mục nhân viên") == true)
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục nhân viên", "Danh mục nhân viên");
                bar2.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.nhan_vien;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Danh mục nhân viên";
                item.Control = new Control();
                item.Control = panel;
                frmDanhMucNhanVien f = new frmDanhMucNhanVien(this.link,this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            //đã có tab này
            else
            {
                for(int i = 0; i < bar2.Items.Count; i++)
                    if (bar2.Items[i].Equals("Danh mục nhân viên") == true)
                    {
                        //mở tab này nếu nó đang đóng
                        bar2.Items.Clear();
                        
                        DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Danh mục nhân viên", "Danh mục nhân viên");
                        bar2.Items.Add(item);
                        Image a = global::QuanLySieuThi.Properties.Resources.nhan_vien;
                        item.Image = a;
                        item.Selected = true;
                        DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                        panel.Name = "Danh mục nhân viên";
                        item.Control = new Control();
                        item.Control = panel;
                        frmDanhMucNhanVien f = new frmDanhMucNhanVien(this.link,this.manv);
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        item.Control.Controls.Add(f);
                        f.Show();
                        break;
                    }
            }
        }

        private void openThongKeThuChi(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
                for (int i = 0; i < bar2.Items.Count; i++ )
                    if (bar2.Items[i].Text.Equals("Thống kê thu chi") == true)
                    {
                        tonTai = true;
                        break;
                    }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thống kê thu chi", "Thống kê thu chi");
                bar2.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.chart_icon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Thống kê thu chi";
                item.Control = new Control();
                item.Control = panel;
                frmThongKeThuChi f = new frmThongKeThuChi();
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            //đã có tab này
            else
            {
                //for(int i = 0; i < bar2.Items.Count; i++)
                    for (int i = 0; i < bar2.Items.Count; i++ )
                        if (bar2.Items[i].Text.Equals("Thống kê thu chi") == true)
                        {
                            //mở tab này nếu nó đang đóng
                            bar2.Items.Clear();
                            
                            DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thống kê thu chi", "Thống kê thu chi");
                            bar2.Items.Add(item);
                            Image a = global::QuanLySieuThi.Properties.Resources.chart_icon;
                            item.Image = a;
                            item.Selected = true;
                            DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                            panel.Name = "Thống kê thu chi";
                            item.Control = new Control();
                            item.Control = panel;
                            frmThongKeThuChi f = new frmThongKeThuChi();
                            f.TopLevel = false;
                            f.Dock = DockStyle.Fill;
                            item.Control.Controls.Add(f);
                            f.Show();
                        }
            }
        }

        private void openThongKeHoaDon(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < bar2.Items.Count; i++)
                if (bar2.Items[i].Equals("Thống kê hóa đơn") == true)
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thống kê hóa đơn", "Thống kê hóa đơn");
                bar2.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.thongkeHoaDon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Thống kê hóa đơn";
                item.Control = new Control();
                item.Control = panel;
                frmThongKeHoaDon f = new frmThongKeHoaDon();
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            //đã có tab này
            else
            {
                for(int i = 0; i < bar2.Items.Count; i++)
                    if (bar2.Items[i].Equals("Thống kê hóa đơn") == true)
                    {
                        //mở tab này nếu nó đang đóng
                        bar2.Items.Clear();
                        
                        DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thống kê hóa đơn", "Thống kê hóa đơn");
                        bar2.Items.Add(item);
                        Image a = global::QuanLySieuThi.Properties.Resources.thongkeHoaDon;
                        item.Image = a;
                        item.Selected = true;
                        DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                        panel.Name = "Thống kê hóa đơn";
                        item.Control = new Control();
                        item.Control = panel;
                        frmThongKeHoaDon f = new frmThongKeHoaDon();
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        item.Control.Controls.Add(f);
                        f.Show();
                    }
            }
        }

        private void openThongTinCuaHang(object sender, EventArgs e)
        {
            //kiểm tra xem đã có tab này chưa
            bool tonTai = false;
            for(int i = 0; i < bar2.Items.Count; i++)
                if (bar2.Items[i].Equals("Thông tin cửa hàng") == true)
                {
                    tonTai = true;
                    break;
                }

            //nếu chưa có thì tạo và thêm vô
            if (tonTai == false)
            {
                DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thông tin cửa hàng", "Thông tin cửa hàng");
                bar2.Items.Add(item);
                Image a = global::QuanLySieuThi.Properties.Resources.store_icon;
                item.Image = a;
                item.Selected = true;
                DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                panel.Name = "Thông tin cửa hàng";
                item.Control = new Control();
                item.Control = panel;
                frmThongTinSieuThi f = new frmThongTinSieuThi(this.link,this.manv);
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                item.Control.Controls.Add(f);
                f.Show();
            }
            //đã có tab này
            else
            {
                for(int i = 0; i < bar2.Items.Count; i++)
                    if (bar2.Items[i].Equals("Thông tin cửa hàng") == true)
                    {
                        //mở tab này nếu nó đang đóng
                        bar2.Items.Clear();
                        
                        DevComponents.DotNetBar.DockContainerItem item = new DevComponents.DotNetBar.DockContainerItem("Thông tin cửa hàng", "Thông tin cửa hàng");
                        bar2.Items.Add(item);
                        Image a = global::QuanLySieuThi.Properties.Resources.store_icon;
                        item.Image = a;
                        item.Selected = true;
                        DevComponents.DotNetBar.PanelDockContainer panel = new DevComponents.DotNetBar.PanelDockContainer();
                        panel.Name = "Thông tin cửa hàng";
                        item.Control = new Control();
                        item.Control = panel;
                        frmThongTinSieuThi f = new frmThongTinSieuThi(this.link,this.manv);
                        f.TopLevel = false;
                        f.Dock = DockStyle.Fill;
                        item.Control.Controls.Add(f);
                        f.Show();
                    }
            }
        }

        private void bar2_DockTabClosed(object sender, DevComponents.DotNetBar.DockTabClosingEventArgs e)
        {
            bar2.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
