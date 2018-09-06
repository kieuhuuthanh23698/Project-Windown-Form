USE QL_SIEUTHI

CREATE TABLE KhoHang
(
	MaHangHoa nchar (30) not null primary key,
	TenHangHoa nvarchar (50),
	LoaiHangHoa nvarchar (50),
	GiaBan float,
	GiaMua float,
	DonVi nvarchar (20),
	SoluongTrongKho int
)

CREATE TABLE NhanVien
(
	MaNhanVien nchar (20) not null primary key,
	TenNhanVien nvarchar (50),
	NgaySinh date,
	GioiTinh nvarchar (5),
	Luong float,
	Email nchar (20),
	DiaChi nvarchar (50),
	Tuoi int,
	CapNguoiDung nchar (10)
)

CREATE TABLE KhachHang
(
	MaKhachHang nchar (20) not null primary key,
	TenKhachHang nvarchar (50),
	SoDienThoai nchar (20)
)

CREATE TABLE HoaDon
(
	MaHoaDon nchar (20) not null primary key,
	NgayLapHoaDon date,
	GioLapHoaDon time,
	TenNVLapHoaDon nvarchar (50),
	MaNVLapHoaDon nchar (20),
	TenKhachHang nvarchar (50),
	MaKhachHang nchar (20),
	TienHang float,
	PhanTramGiamGia float,
	GiamGia float,
	TongThanhTien float,
	KhachDua float,
	TraLai float,
)

CREATE TABLE ChiTietHoaDon
(
	MaHoaDon nchar (20) not null,
	MaHangHoa nchar (30) not null,
	TenHangHoa nvarchar (30),
	GiaBan float,
	Soluong int,
	ThanhTien float
)
Alter table ChiTietHoaDon
Add constraint  PK_ChiTietHoaDon primary key (MaHoaDon,MaHoaDon)

CREATE TABLE ThongTinSieuThi
(
	TenSieuThi nvarchar (50) not null primary key,
	DiaChiSieuThi nvarchar (50),
	SoDT nchar (20),
	TenChuSieuThi nvarchar (50),
	MaNVChuSieuThi nchar (20),
	CongQuy float,
)

CREATE TABLE Users
(
	UserName nchar (30) not null,
	Passwords nchar (30) not null,
	MaNhanVien nchar (20) not null
)
Alter table Users
Add contraint PK_Users primary key (UserName,Passwords,MaNhanVien)

CREATE TABLE ThuChi
(
	ThuChi nchar (5),
	TenHangHoa nvarchar (50),
	MaHangHoa nchar (30),
	SoLuong int,
	SoTienThuChi float,
	NgayThuChi date not null,
	GioThuChi date not null,
	TenNhanVienThuChi nvarchar (50),
	MaNhanVienThuChi nchar (20)
)
Alter table ThuChi
Add contraint PK_ThuChi primary key (NgayThuChi,GioThuChi)

















