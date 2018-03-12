--Bài toán đặt ra: Thiết kế cơ sở dữ liệu Quản lý xuất nhập kho. quản lý Nhập hàng từ nhà cung cấp, và xuất hàng cho khách, 
--khách trong bài toán này không phải khách mua lẻ, mà thường các đại lý, các siêu thị mua hàng với số lượng lớn.

-- Tạo database QuanLyNhapXuatKho----------------------
CREATE DATABASE QuanlyXuat_Nhapkho
go
use QuanlyXuat_Nhapkho
go
------------------TẠO BẢNG BẰNG CÂU LỆNH--------------------------------------------------
--1----tạo bảng tbl_KhoHang-----------------------
CREATE TABLE tbl_KhoHang
(
	Makho  varchar(10) not null primary key,
	Tenkho nvarchar(50),
)

--2----tạo bảng tbl_NhanVienKho--------------------
CREATE TABLE tbl_NhanVienKho
(
	MaNV  varchar(10) not null primary key,
	TenNV nvarchar(50),
	Sdt   varchar(11),
	Tuoi  int,
)

--3---tạo bảng tbl_NhaCungCap----------------------
CREATE TABLE tbl_NhaCungCap
(
	MaNCC       varchar(10) not null primary key,
	TenNCC      nvarchar(50),
	Diachi      nvarchar(100),
	Sodienthoai varchar(10),
) 

--4---tạo bảng tbl_NhomSanPham---------------------
CREATE TABLE tbl_NhomSanPham
(
	Manhom  varchar(10) not null primary key,
	Tennhom nvarchar(50),
	Makho   varchar(10) not null references tbl_KhoHang(Makho)
)

--5---tạo bảng tbl_HangHoa-------------------------
CREATE TABLE tbl_HangHoa
(
	Mahanghoa  varchar(10) not null primary key,
	Tenhanghoa nvarchar(50),
	Donvitinh  nvarchar(10),
	Dongia	   Decimal(18,0) not null default 0,
	Manhom     varchar(10) not null references tbl_NhomSanPham(Manhom)
)

--6---tạo bảng tbl_KhachHang-----------------------
CREATE TABLE tbl_KhachHang
(
	Makhachhang  varchar(10) not null primary key,
	Tenkhachhang Nvarchar(50),
	Diachi		 Nvarchar(100),
	Sodienthoai	 varchar(10),
)

--7---tạo bảng tbl_PhieuNhap------------------------
CREATE TABLE tbl_PhieuNhap
(
	Sophieunhap   varchar(10) not null primary key,
	Ngaylapphieu  Datetime,
	Nguoilapphieu varchar(10) not null references tbl_NhanVienKho(MaNV),
	Tongtien      decimal(18, 0) default 0,
	Manhom        varchar(10) not null references tbl_NhomSanPham(Manhom),
	MaNCC         varchar(10) not null references tbl_NhaCungCap(MaNCC),
	
)

--8---tạo bảng tbl_ChiTietPhieuNhap------------------
CREATE TABLE tbl_ChiTietPhieuNhap
(
	Sophieunhap varchar(10) not null references tbl_PhieuNhap(Sophieunhap),
	Mahanghoa   varchar(10) not null references tbl_HangHoa(Mahanghoa),
	Dongianhap      Decimal(18, 0) not null  default 0,
	Soluong     Int not null,
	primary key (Sophieunhap, Mahanghoa)

)

--9---tạo bảng tbl_PhieuXuat------------------
CREATE TABLE tbl_PhieuXuat
(
	Sophieuxuat   varchar(10) not null primary key,
	Ngaylapphieu  Datetime,
	Nguoilapphieu varchar(10) not null references tbl_NhanVienKho(MaNV),
	Tongtien      decimal(18, 0) default 0,
	Makhachhang   varchar(10) not null references tbl_KhachHang(Makhachhang),
)

--10---tạo bảng tbl_ChiTietPhieuXuat------------------
CREATE TABLE tbl_ChiTietPhieuXuat
(
	Sophieuxuat varchar(10) not null references tbl_PhieuXuat(Sophieuxuat),
	Mahanghoa   varchar(10) not null references tbl_HangHoa(Mahanghoa),
	Dongiaban      Decimal(18, 0) not null default 0,
	Soluong     Int not null,
	primary key (Sophieuxuat, Mahanghoa)

)
go
----------------------INSERT DỮ LIỆU BẰNG CÂU LỆNH-------------------------------------------------------------

----------------------------viết stored------------------------------------------------------------------------

--1------------		stored Insert Kho Hang --------------------------------------------------------------------
CREATE PROC ThemKhoHang(@makho varchar(10), @tenkho Nvarchar(50))
AS
BEGIN
	Insert into tbl_KhoHang( Makho, Tenkho)
	Values (@makho, @tenkho)
END
go
execute ThemKhoHang @makho= 'mk001', @tenkho = N'Kho hàng đồ sứ'
execute ThemKhoHang @makho= 'mk002', @tenkho = N'Kho hàng đồ gia dụng'
execute ThemKhoHang @makho= 'mk003', @tenkho = N'Kho hàng đồ điện tử'
execute ThemKhoHang @makho= 'mk004', @tenkho = N'Kho hàng vật liệu xây dựng'
execute ThemKhoHang @makho= 'mk005', @tenkho = N'Kho hàng tổng hợp'
execute ThemKhoHang @makho= 'mk006', @tenkho = N'Kho hàng tổng hợp'
execute ThemKhoHang @makho= 'mk007', @tenkho = N'Kho hàng đồ Gốm'
execute ThemKhoHang @makho= 'mk008', @tenkho = N'Kho hàng đồ gỗ'
execute ThemKhoHang @makho= 'mk009', @tenkho = N'Kho Thực phẩm'
execute ThemKhoHang @makho= 'mk010', @tenkho = N'Kho hàng Quần Áo'
go

--2------------stored Insert Nhà Cung Cấp ----------------------------------------------------------------------
CREATE PROC ThemNhaCungCap(@mancc varchar(10), @tenncc Nvarchar(50), @diachi Nvarchar(100), @sdt varchar(10))
AS
BEGIN
	Insert into tbl_NhaCungCap( MaNCC, TenNCC, Diachi, Sodienthoai)
	Values (@mancc, @tenncc, @diachi, @sdt)
END
go
execute ThemNhaCungCap @mancc='ncc001', @tenncc=N'Việt Nam Mô Bai', @diachi=N'Hà Nội', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc002', @tenncc=N'Việt Nam E Lai', @diachi=N'Nội Bài', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc003', @tenncc=N'Siêu Thị Điện Máy Xanh', @diachi=N'Hà Nội', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc004', @tenncc=N'Công Ty Mĩ Phầm Hà Thạch', @diachi=N'Phú Thọ', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc005', @tenncc=N'Khu Công Nghiệp Bắc Thăng Long', @diachi=N'Hà Nội', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc006', @tenncc=N'Công Ty Bánh Kẹo Hải Hà', @diachi=N'Hà Nội', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc007', @tenncc=N'Công Ty Nhôm Sông Hồng', @diachi=N'Việt Trì', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc008', @tenncc=N'Công Ty Cổ Phần DATAVIET', @diachi=N'Hà Nội', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc009', @tenncc=N'Hà Nam MoBISITOi', @diachi=N'Hà Nam', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc010', @tenncc=N'Điện máy Xanh', @diachi=N'Hà Nam', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc011', @tenncc=N'Công Ty Cổ phần Sò Huyết Nam Định', @diachi=N'Nam Định', @sdt='1122334455'
go


--3------------stored Insert Nhân Viên Kho ----------------------------------------------------------------------
CREATE PROC ThemNhanVienKho(@manv varchar(10), @tennv Nvarchar(50), @tuoi Nvarchar(100), @sdt varchar(10))
AS
BEGIN
	Insert into tbl_NhanVienKho( MaNV, TenNV, Tuoi, Sdt)
	Values (@manv, @tennv, @tuoi, @sdt)
END
go
execute ThemNhanVienKho @manv='nv001', @tennv=N'Trần Văn A',     @tuoi=22, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv002', @tennv=N'NGuyễn Thị B',   @tuoi=13, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv003', @tennv=N'Hà Tuấn D',      @tuoi=14, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv004', @tennv=N'Doãn Chí Bình',  @tuoi=15, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv005', @tennv=N'Triệu Trí Kính', @tuoi=16, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv006', @tennv=N'Trần Đức Sọ',  @tuoi=30, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv007', @tennv=N'Phạm Nhữ Chiến', @tuoi= 21, @sdt='0978765439'
execute ThemNhanVienKho @manv='nv008', @tennv='Nguyễn Văn Phúc', @tuoi= 21, @sdt='0978765439'
execute ThemNhanVienKho @manv='nv009', @tennv='vũ Lông Khánh', @tuoi= 19 , @sdt='01600446567'
execute ThemNhanVienKho @manv='nv010', @tennv= 'Lưu Thị Phong', @tuoi=35, @sdt='0946657557'

go

--4------------stored Insert Nhóm sản phẩm ----------------------------------------------------------------------
CREATE PROC ThemNhonSanPham(@manhom varchar(10), @tennhom Nvarchar(50), @makho varchar(10))
AS
BEGIN
	Insert into tbl_NhomSanPham( Manhom, Tennhom, Makho)
	Values (@manhom, @tennhom, @makho)
END
go
execute ThemNhonSanPham @manhom='nsp001' , @tennhom=N'Đồ Gia Dụng',@makho= 'mk001'
execute ThemNhonSanPham @manhom='nsp002' , @tennhom=N'Đồ Mĩ Nghệ', @makho= 'mk002'
execute ThemNhonSanPham @manhom='nsp003' , @tennhom=N'Sản Phẩm Di Động',@makho= 'mk003'
execute ThemNhonSanPham @manhom='nsp004' , @tennhom=N'Sản Phẩm Đồ Sứ',@makho= 'mk004'
execute ThemNhonSanPham @manhom='nsp005' , @tennhom=N'Đồ Tiêu Dùng',@makho= 'mk005'
execute ThemNhonSanPham @manhom='nsp006' , @tennhom=N'Đồ Tiêu Dùng',@makho= 'mk001'
execute ThemNhonSanPham @manhom='nsp007' , @tennhom=N'Đồ Điện tử',@makho= 'mk006'
execute ThemNhonSanPham @manhom='nsp008' , @tennhom=N'Sản Phẩm Đồ Sứ',@makho= 'mk008'
execute ThemNhonSanPham @manhom='nsp009' , @tennhom=N'Đồ Tiêu Dùng',@makho= 'mk009'
execute ThemNhonSanPham @manhom='nsp010' , @tennhom=N'Đồ Tiêu Dùng',@makho= 'mk010'


go


--5------------stored Insert Khách Hàng--------------------------------------------------------------------------
CREATE PROC ThemKhachHang(@makh varchar(10), @tennkh Nvarchar(50), @diachi nvarchar(10), @sdt varchar(10))
AS
BEGIN
	Insert into tbl_KhachHang( Makhachhang, Tenkhachhang, Diachi, Sodienthoai)
	Values (@makh, @tennkh, @diachi, @sdt)
END
go
execute ThemKhachHang @makh='kh001', @tennkh=N'Trần Đức Mạnh',  @diachi=N'Phú Thọ', @sdt='012345678'
execute ThemKhachHang @makh='kh002', @tennkh=N'Trần Quốc Dân',  @diachi=N'Phú Thọ', @sdt='012345678'
execute ThemKhachHang @makh='kh003', @tennkh=N'Trần Anh Tông',  @diachi=N'Phú Thọ', @sdt='012345678'
execute ThemKhachHang @makh='kh004', @tennkh=N'Trần Đức Nam',   @diachi=N'Phú Thọ', @sdt='012345678'
execute ThemKhachHang @makh='kh005', @tennkh=N'Trần Quốc Toản', @diachi=N'Phú Thọ', @sdt='012345678'
execute ThemKhachHang @makh='kh006', @tennkh=N'Trần Quốc Toản', @diachi=N'Phú Thọ', @sdt='012345678'
execute ThemKhachHang @makh='kh007', @tennkh=N'Nguyễn Thành Hiệp',  @diachi=N'Hà Nội', @sdt='012345678'
execute ThemKhachHang @makh='kh008', @tennkh=N'Đặng Văn Công',  @diachi=N'Nam Định', @sdt='012345678'
execute ThemKhachHang @makh='kh009', @tennkh=N'Nguyễn văn Quyền',  @diachi=N'Hà Nam', @sdt='012345678'
execute ThemKhachHang @makh='kh010', @tennkh=N'Lưu Thị Phong',   @diachi=N'Vĩnh phúc', @sdt='012345678'
go



----------------------UPDATE DỮ LIỆU BẰNG CÂU LỆNH-----------------------------------------------------------

----------------------------viết stored----------------------------------------------------------------------

--1------------stored Update Kho Hàng -----------------------------------------------------------------------
go
CREATE PROC EDITKhoHang(@makho varchar(10), @tenkho Nvarchar(50))
AS
BEGIN
	Update tbl_KhoHang
	set Tenkho=@tenkho
	Where Makho=@makho
END
go


--2------------stored Update Nhà Cung Cấp -------------------------------------------------------------------
go
CREATE PROC EDITNhaCungCap(@mancc varchar(10), @tenncc Nvarchar(50), @diachi Nvarchar(100), @sdt varchar(10))
AS
BEGIN
	Update tbl_NhaCungCap
	Set TenNCC=@tenncc, Diachi= @diachi, Sodienthoai=@sdt
	Where MaNCC = @mancc
END
go


--3------------stored Update Nhân Viên Kho -----------------------------------------------------------------

CREATE PROC EDITNhanVienKho(@manv varchar(10), @tennv Nvarchar(50), @tuoi Nvarchar(100), @sdt varchar(10))
AS
BEGIN
	Update tbl_NhanVienKho
	Set TenNV=@tennv, Tuoi= @tuoi, Sdt=@sdt
	Where MaNV = @manv
END
go


--4------------stored Update Nhóm Sản Phẩm ----------------------------------------------------------------

CREATE PROC EDITNhonSanPham(@manhom varchar(10), @tennhom Nvarchar(50), @makho varchar(10))
AS
BEGIN
	Update tbl_NhomSanPham
	Set Tennhom=@tennhom, Makho = @makho
	Where Manhom = @manhom

END
go



--5------------stored Update Khách Hàng--------------------------------------------------------------------

CREATE PROC EDITKhachHang(@makh varchar(10), @tennkh Nvarchar(50), @diachi varchar(10), @sdt varchar(10))
AS
BEGIN
	Update tbl_KhachHang
	Set Tenkhachhang = @tennkh, Diachi=@diachi, Sodienthoai=@sdt
	Where Makhachhang=@makh
END
go


----------------------DELETE DỮ LIỆU BẰNG CÂU LỆNH------------------------------------------------------------

----------------------------viết Delete-----------------------------------------------------------------------

--1------------stored Delete Kho Hang ------------------------------------------------------------------------

CREATE PROC DELETEKhoHang(@makho varchar(10))
AS
BEGIN
	DELETE FROM tbl_KhoHang Where (Makho=@makho)
END
go

--2------------stored Delete Nhà Cung Cấp --------------------------------------------------------------------

CREATE PROC DELETENhaCungCap(@mancc varchar(10))
AS
BEGIN
	DELETE FROM tbl_NhaCungCap Where (MaNCC=@mancc)
END
go

--3------------stored Delete Nhân Viên Kho --------------------------------------------------------------------

CREATE PROC DELETENhanVienKho(@manv varchar(10))
AS
BEGIN
	DELETE FROM tbl_NhanVienKho Where (MaNV=@manv)

END
go

--4------------stored Delete Nhóm Sản phẩm -------------------------------------------------------------------
CREATE PROC DELETENhonSanPham(@manhom varchar(10))
AS
BEGIN
	DELETE FROM tbl_NhomSanPham Where (Manhom=@manhom)
END

--5------------stored Delete Khách Hàng-----------------------------------------------------------------------
go
CREATE PROC DELETEKhachHang(@makh varchar(10))
AS
BEGIN
	DELETE FROM tbl_KhachHang Where (Makhachhang=@makh)
END
go

---Tìm Kiếm Kho hàng theo Mã Kho-------
CREATE PROC TimKiem(@makho varchar(10) )
AS
BEGIN
	SELECT* FROM tbl_KhoHang  WHERE Makho like @makho
END
go
execute TimKiem @makho='mk008'
select * from tbl_KhoHang where Makho = 'mk001'