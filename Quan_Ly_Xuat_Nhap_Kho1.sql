



--Bài toán đặt ra: Thiết kế cơ sở dữ liệu Quản lý xuất nhập kho. quản lý Nhập hàng từ nhà cung cấp, và xuất hàng cho khách, 
--khách trong bài toán này không phải khách mua lẻ, mà thường các đại lý, các siêu thị mua hàng với số lượng lớn.

-- Tạo database QuanLyNhapXuatKho----------------------
CREATE DATABASE Quan_Ly_Xuat_Nhap_Kho1
go
use Quan_Ly_Xuat_Nhap_Kho1

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
execute ThemNhaCungCap @mancc='ncc010', @tenncc=N'Quất Lâm rì sọt', @diachi=N'Hà Nam', @sdt='1122334455'
execute ThemNhaCungCap @mancc='ncc011', @tenncc=N'Quất Lâm rì sọt', @diachi=N'Hà Nam', @sdt='1122334455'
go



--3------------stored Insert Nhân Viên Kho ----------------------------------------------------------------------
CREATE PROC ThemNhanVienKho(@manv varchar(10), @tennv Nvarchar(50), @tuoi Nvarchar(100), @sdt varchar(10))
AS
BEGIN
	Insert into tbl_NhanVienKho( MaNV, TenNV, Tuoi, Sdt)
	Values (@manv, @tennv, @tuoi, @sdt)
END
go
execute ThemNhanVienKho @manv='nv001', @tennv=N'Trần Văn A',     @tuoi=12, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv002', @tennv=N'NGuyễn Thị B',   @tuoi=13, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv003', @tennv=N'Hà Tuấn D',      @tuoi=14, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv004', @tennv=N'Doãn Chí Bình',  @tuoi=15, @sdt='1122334455'
execute ThemNhanVienKho @manv='nv005', @tennv=N'Triệu Trí Kính', @tuoi=16, @sdt='1122334455'

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
execute ThemNhonSanPham @manhom='nsp002' , @tennhom=N'Đồ Mĩ Nghệ', @makho= 'mk001'
execute ThemNhonSanPham @manhom='nsp003' , @tennhom=N'Sản Phẩm Di Động',@makho= 'mk002'
execute ThemNhonSanPham @manhom='nsp004' , @tennhom=N'Sản Phẩm Đồ Sứ',@makho= 'mk002'
execute ThemNhonSanPham @manhom='nsp005' , @tennhom=N'Đồ Tiêu Dùng',@makho= 'mk002'
execute ThemNhonSanPham @manhom='nsp006' , @tennhom=N'Đồ Tiêu Dùng',@makho= 'mk002'

go


--5------------stored Insert Hàng hóa---------------------------------------------------------------------------
CREATE PROC ThemHangHoa(@mahh varchar(10), @tennhh Nvarchar(50), @dongia decimal(18,0), @donvitinh nvarchar(10), @manhom varchar(10))
AS
BEGIN
	Insert into tbl_HangHoa( Mahanghoa, Tenhanghoa, Dongia, Donvitinh, Manhom)
	Values (@mahh, @tennhh, @dongia, @donvitinh, @manhom)
END
go
execute ThemHangHoa @mahh='sp001', @tennhh=N'Tủ Lạnh ToShiBa',    @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp002', @tennhh=N'Tủ Lạnh Tàu',        @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp003', @tennhh=N'Tủ Quật Trần',       @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp002'
execute ThemHangHoa @mahh='sp004', @tennhh=N'Điều Hòa',           @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp008'
execute ThemHangHoa @mahh='sp005', @tennhh=N'Quạt Điện',          @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp005'
execute ThemHangHoa @mahh='sp006', @tennhh=N'Điện Thoại NOKIA',   @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp007'
execute ThemHangHoa @mahh='sp007', @tennhh=N'Điện Thoại SAMSUNG', @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp008'
execute ThemHangHoa @mahh='sp008', @tennhh=N'Điện Thoại Tàu',     @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp009', @tennhh=N'Máy Tính Dell',      @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp010', @tennhh=N'Tranh Đông Hồ',      @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp002'
execute ThemHangHoa @mahh='sp011', @tennhh=N'Hải Sản Đông Lạnh',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp005'
execute ThemHangHoa @mahh='sp012', @tennhh=N'Bình Hoa Sứ',        @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp013', @tennhh=N'Bat Đĩa Bát Tràng',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp009'
execute ThemHangHoa @mahh='sp014', @tennhh=N'Bat Đĩa Hội An ',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp005'
execute ThemHangHoa @mahh='sp015', @tennhh=N'Gốm Sứ Bát Tràng',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp016', @tennhh=N'Điện Thoại Apple',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp017', @tennhh=N'Tủ Lạnh LG',    @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp018', @tennhh=N'Tủ Lạnh Tây',        @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp019', @tennhh=N'Tủ Quật Tường',       @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp020', @tennhh=N'Điều Hòa Toshiba',           @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp008'
execute ThemHangHoa @mahh='sp021', @tennhh=N'Quạt Điện Nhật',          @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp022', @tennhh=N'Điện Thoại Ummi',   @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp006'
execute ThemHangHoa @mahh='sp023', @tennhh=N'Điện Thoại Back', @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp024', @tennhh=N'Điện Thoại Sony',     @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp025', @tennhh=N'Máy Tính Asus',      @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp005'
execute ThemHangHoa @mahh='sp026', @tennhh=N'Tranh Vẽ',      @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp002'
execute ThemHangHoa @mahh='sp027', @tennhh=N'Hải Sản Tươi Sống',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp005'
execute ThemHangHoa @mahh='sp028', @tennhh=N'Bình Hoa Giấy',        @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp029', @tennhh=N'Tăm vip',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp030', @tennhh=N'Tăm Vip 2',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp031', @tennhh=N'Tăm Vip 3',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp032', @tennhh=N'Tăm Vip 4',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp033', @tennhh=N'Tăm Vip 5',    @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp009'
execute ThemHangHoa @mahh='sp034', @tennhh=N'Tăm Vip 6',        @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp035', @tennhh=N'Giày nike',       @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp036', @tennhh=N'Giày Adidas',           @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp037', @tennhh=N'Bánh Ngọt',          @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp001'
execute ThemHangHoa @mahh='sp038', @tennhh=N'Tai Nghe NOKIA',   @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp007'
execute ThemHangHoa @mahh='sp039', @tennhh=N'Tai Nghe SAMSUNG', @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp009'
execute ThemHangHoa @mahh='sp040', @tennhh=N'Tai Nghe Sony',     @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp041', @tennhh=N'Máy Tính dát Vàng',      @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp003'
execute ThemHangHoa @mahh='sp042', @tennhh=N'Xe Mazda',      @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp002'
execute ThemHangHoa @mahh='sp043', @tennhh=N'Xe Audio',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp005'
execute ThemHangHoa @mahh='sp044', @tennhh=N'Xe Đạp',        @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp007'
execute ThemHangHoa @mahh='sp045', @tennhh=N'Xe Máy',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp046', @tennhh=N'Máy Bay',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp047', @tennhh=N'Tàu Hỏa cho bé',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp008'
execute ThemHangHoa @mahh='sp048', @tennhh=N'Cốc Uống Nước',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
execute ThemHangHoa @mahh='sp049', @tennhh=N'TRà Sữa',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp006'
execute ThemHangHoa @mahh='sp050', @tennhh=N'Trà Đào',  @dongia=10000, @donvitinh=N'Chiếc', @manhom='nsp004'
go




--6------------stored Insert Khách Hàng--------------------------------------------------------------------------
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
go



--7------------stored Insert Phiếu Nhập---------------------------------------------------------------------------
CREATE PROC ThemPhieuNhap(@sophieunhap varchar(10), @ngaylapphieu date, @nguoilapphieu varchar(10), @tongtien decimal(18,0), @manhom varchar(10),@mancc varchar(10))
AS
BEGIN
	Insert into tbl_PhieuNhap( Sophieunhap, Ngaylapphieu, Nguoilapphieu, Tongtien, Manhom, MaNCC)
	Values (@sophieunhap, @ngaylapphieu, @nguoilapphieu, @tongtien, @manhom, @mancc)
END
go
execute ThemPhieuNhap @sophieunhap='spn001', @ngaylapphieu='2015-12-12', @nguoilapphieu='nv001', @tongtien=5000000,   @manhom='nsp001',@mancc='ncc001'
execute ThemPhieuNhap @sophieunhap='spn002', @ngaylapphieu='2015-10-12', @nguoilapphieu='nv001', @tongtien=5000000,   @manhom='nsp005',@mancc='ncc002'
execute ThemPhieuNhap @sophieunhap='spn003', @ngaylapphieu='2014-05-12', @nguoilapphieu='nv001', @tongtien=23000000,  @manhom='nsp001',@mancc='ncc003'
execute ThemPhieuNhap @sophieunhap='spn004', @ngaylapphieu='2016-12-12', @nguoilapphieu='nv001', @tongtien=5005000,	  @manhom='nsp003',@mancc='ncc004'
execute ThemPhieuNhap @sophieunhap='spn005', @ngaylapphieu='2017-02-12', @nguoilapphieu='nv001', @tongtien=134000000, @manhom='nsp002',@mancc='ncc005'
go




--8------------stored Insert Phiếu Xuất---------------------------------------------------------------------------
CREATE PROC ThemPhieuXuat(@sophieuxuat varchar(10), @ngaylapphieu date, @nguoilapphieu varchar(10), @tongtien decimal(18,0), @makhachang varchar(10))
AS
BEGIN
	Insert into tbl_PhieuXuat( Sophieuxuat, Ngaylapphieu, Nguoilapphieu, Tongtien, Makhachhang)
	Values (@sophieuxuat, @ngaylapphieu,@nguoilapphieu, @tongtien, @makhachang)
END
go
execute ThemPhieuXuat @sophieuxuat='spx001', @ngaylapphieu='2015-12-12', @nguoilapphieu='nv001', @tongtien=20000000,  @makhachang='kh001'
execute ThemPhieuXuat @sophieuxuat='spx002', @ngaylapphieu='2014-12-12', @nguoilapphieu='nv001', @tongtien=120000000, @makhachang='kh002'
execute ThemPhieuXuat @sophieuxuat='spx003', @ngaylapphieu='2013-12-12', @nguoilapphieu='nv001', @tongtien=230000000, @makhachang='kh003'
execute ThemPhieuXuat @sophieuxuat='spx004', @ngaylapphieu='2012-12-12', @nguoilapphieu='nv002', @tongtien=250000000, @makhachang='kh004'
execute ThemPhieuXuat @sophieuxuat='spx005', @ngaylapphieu='2011-12-12', @nguoilapphieu='nv002', @tongtien=2000000,   @makhachang='kh005'
execute ThemPhieuXuat @sophieuxuat='spx007', @ngaylapphieu='2011-12-12', @nguoilapphieu='nv001', @tongtien=0,		  @makhachang='kh005'




--9------------stored Insert Chi tiết phiếu nhập-------------------------------------------------------------------
go
CREATE PROC ThemCTPhieuNhap(@sophieunhap varchar(10), @mahanghoa varchar(10),@dongianhap decimal(18,0), @soluong int)
AS
BEGIN
	Insert into tbl_ChiTietPhieuNhap( Sophieunhap, Mahanghoa, Dongianhap, Soluong)
	Values (@sophieunhap, @mahanghoa, @dongianhap, @soluong)
END
go
execute ThemCTPhieuNhap @sophieunhap='spn002', @mahanghoa='sp001', @dongianhap=400000, @soluong=1
execute ThemCTPhieuNhap @sophieunhap='spn001', @mahanghoa='sp002', @dongianhap=4000000, @soluong=13

--10------------stored Insert Chi tiết phiếu xuất-------------------------------------------------------------------
go
CREATE PROC ThemCTPhieuXuat(@sophieuxuat varchar(10), @mahanghoa varchar(10),@dongiaban decimal(18,0), @soluong int)
AS
BEGIN
	Insert into tbl_ChiTietPhieuXuat( Sophieuxuat, Mahanghoa, Dongiaban, Soluong)
	Values (@sophieuxuat, @mahanghoa, @dongiaban, @soluong)
END
go
execute ThemCTPhieuXuat @sophieuxuat='spx007', @mahanghoa='sp001', @dongiaban=120000, @soluong=2
execute ThemCTPhieuXuat @sophieuxuat='spx007', @mahanghoa='sp002', @dongiaban=100000, @soluong=1
execute ThemCTPhieuXuat @sophieuxuat='spx007', @mahanghoa='sp003', @dongiaban=100000, @soluong=10
execute ThemCTPhieuXuat @sophieuxuat='spx007', @mahanghoa='sp007', @dongiaban=100000, @soluong=5
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
execute EDITKhoHang @makho= 'mk001', @tenkho = N'Kho hàng đồ sứ'
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
execute EDITNhaCungCap @mancc='ncc001', @tenncc=N'Việt Nam Mô Bai', @diachi=N'Hà Nội', @sdt='1122334455'
go


--3------------stored Update Nhân Viên Kho -----------------------------------------------------------------
go
CREATE PROC EDITNhanVienKho(@manv varchar(10), @tennv Nvarchar(50), @tuoi Nvarchar(100), @sdt varchar(10))
AS
BEGIN
	Update tbl_NhanVienKho
	Set TenNV=@tennv, Tuoi= @tuoi, Sdt=@sdt
	Where MaNV = @manv
END
go
execute EDITNhanVienKho @manv='nv001', @tennv=N'Trần Đức Mạnh',     @tuoi=25, @sdt='01658942987'
go


--4------------stored Update Nhóm Sản Phẩm ----------------------------------------------------------------
go
CREATE PROC EDITNhonSanPham(@manhom varchar(10), @tennhom Nvarchar(50), @makho varchar(10))
AS
BEGIN
	Update tbl_NhomSanPham
	Set Tennhom=@tennhom, Makho = @makho
	Where Manhom = @manhom

END
go
execute EDITNhonSanPham @manhom='nsp001' , @tennhom=N'Đồ Gia Dụng', @makho='mk005'
go


--5------------stored Update Hàng hóa---------------------------------------------------------------------
go
CREATE PROC EDITHangHoa(@mahh varchar(10), @tennhh Nvarchar(50),@dongia decimal(18,0), @donvitinh varchar(10), @manhom varchar(10))
AS
BEGIN
	Update tbl_HangHoa
	Set Tenhanghoa = @tennhh, Donvitinh=@donvitinh, Manhom=@manhom, Dongia=@dongia
	Where Mahanghoa=@mahh

END
go
execute EDITHangHoa @mahh='sp001', @tennhh=N'Tủ Lạnh ToShiBa', @donvitinh=N'Chiec', @manhom='nsp001',@dongia=120000
go


--6------------stored Update Khách Hàng--------------------------------------------------------------------
go
CREATE PROC EDITKhachHang(@makh varchar(10), @tennkh Nvarchar(50), @diachi varchar(10), @sdt varchar(10))
AS
BEGIN
	Update tbl_KhachHang
	Set Tenkhachhang = @tennkh, Diachi=@diachi, Sodienthoai=@sdt
	Where Makhachhang=@makh
END
go
execute EDITKhachHang @makh='kh001', @tennkh=N'Trần Đức Mạnh', @diachi=N'Phú Thọ', @sdt='012345678'
go


--7------------stored Update Phiếu Nhập--------------------------------------------------------------------
go
CREATE PROC EDITPhieuNhap(@sophieunhap varchar(10), @ngaylapphieu date, @nguoilapphieu varchar(10), @tongtien decimal(18,0), @manhom varchar(10),@mancc varchar(10))
AS
BEGIN
	Update tbl_PhieuNhap
	Set Ngaylapphieu = @ngaylapphieu, Nguoilapphieu=@nguoilapphieu, Tongtien=@tongtien, Manhom=@manhom, MaNCC=@mancc
	Where Sophieunhap=@sophieunhap
END
go
execute EDITPhieuNhap @sophieunhap='spn001', @ngaylapphieu='2015-12-12', @nguoilapphieu='nv001', @tongtien=5000000, @manhom='nsp001',@mancc='ncc001'
go


--8------------stored Update Phiếu Xuất--------------------------------------------------------------------
go
CREATE PROC EDITPhieuXuat(@sophieuxuat varchar(10), @ngaylapphieu date, @nguoilapphieu varchar(10), @tongtien decimal(18,0), @makhachang varchar(10))
AS
BEGIN
	Update tbl_PhieuXuat
	Set Ngaylapphieu = @ngaylapphieu, Nguoilapphieu=@nguoilapphieu, Tongtien=@tongtien, Makhachhang=@makhachang
	Where Sophieuxuat=@sophieuxuat
END
go
execute EDITPhieuXuat @sophieuxuat='spx001', @ngaylapphieu='2015-12-12',@nguoilapphieu='nv001', @tongtien=20000000, @makhachang='kh001'
go


--9------------stored Update Chi tiết phiếu nhập-------------------------------------------------------------
go
CREATE PROC EDITCTPhieuNhap(@sophieunhap varchar(10), @mahanghoa varchar(10),@dongianhap decimal(18,0), @soluong int)
AS
BEGIN
	Update tbl_ChiTietPhieuNhap
	Set Dongianhap = @dongianhap,Soluong=@soluong
	Where Sophieunhap=@sophieunhap AND Mahanghoa=@mahanghoa
END
go
execute EDITCTPhieuNhap @sophieunhap='spn007', @mahanghoa='sp001', @dongianhap=3400000, @soluong=1
go


--10------------stored Update Chi tiết phiếu xuất--------------------------------------------------------------
go
CREATE PROC EDITCTPhieuXuat(@sophieuxuat varchar(10), @mahanghoa varchar(10),@dongiaban decimal(18,0), @soluong int)
AS
BEGIN
	Update tbl_ChiTietPhieuXuat
	Set Dongiaban = @dongiaban,Soluong=@soluong
	Where Sophieuxuat=@sophieuxuat AND Mahanghoa=@mahanghoa
END
go
execute EDITCTPhieuXuat @sophieuxuat='spx007', @mahanghoa='sp001', @dongiaban=1287000, @soluong=2
go








----------------------DELETE DỮ LIỆU BẰNG CÂU LỆNH------------------------------------------------------------

----------------------------viết Delete-----------------------------------------------------------------------

--1------------stored Delete Kho Hang ------------------------------------------------------------------------
go
CREATE PROC DELETEKhoHang(@makho varchar(10))
AS
BEGIN
	DELETE FROM tbl_KhoHang Where (Makho=@makho)
END
go
execute DELETEKhoHang @makho= 'mk006'
go


--2------------stored Delete Nhà Cung Cấp --------------------------------------------------------------------
go
CREATE PROC DELETENhaCungCap(@mancc varchar(10))
AS
BEGIN
	DELETE FROM tbl_NhaCungCap Where (MaNCC=@mancc)
END
go
execute DELETENhaCungCap @mancc='ncc011'

--3------------stored Delete Nhân Viên Kho --------------------------------------------------------------------
go
CREATE PROC DELETENhanVienKho(@manv varchar(10))
AS
BEGIN
	DELETE FROM tbl_NhanVienKho Where (MaNV=@manv)

END
go
execute DELETENhaCungCap @mancc='nv005'

--4------------stored Delete Nhóm Sản phẩm -------------------------------------------------------------------
go
CREATE PROC DELETENhonSanPham(@manhom varchar(10))
AS
BEGIN
	DELETE FROM tbl_NhomSanPham Where (Manhom=@manhom)
END
go
execute DELETENhonSanPham @manhom='nsp006'


--5------------stored Delete Hàng hóa-------------------------------------------------------------------------
go
CREATE PROC DELETEHangHoa(@mahh varchar(10))
AS
BEGIN
	DELETE FROM tbl_HangHoa Where (Mahanghoa=@mahh)
END
go
execute DELETEHangHoa @mahh='sp014'

--6------------stored Delete Khách Hàng-----------------------------------------------------------------------
go
CREATE PROC DELETEKhachHang(@makh varchar(10))
AS
BEGIN
	DELETE FROM tbl_KhachHang Where (Makhachhang=@makh)
END
go
execute DELETEKhachHang @makh='kh006'

--7------------stored Delete Phiếu Nhập-----------------------------------------------------------------------
go
CREATE PROC DELETEPhieuNhap(@sophieunhap varchar(10))
AS
BEGIN
	DELETE FROM tbl_PhieuNhap Where (Sophieunhap=@sophieunhap)
END
go
execute DELETEPhieuNhap @sophieunhap='spn006'

--8------------stored Delete Phiếu Xuất-----------------------------------------------------------------------
go
CREATE PROC DELETEPhieuXuat(@sophieuxuat varchar(10))
AS
BEGIN
	DELETE FROM tbl_PhieuXuat Where (Sophieuxuat=@sophieuxuat)
END
go
execute DELETEPhieuXuat @sophieuxuat='spx008'

--9------------stored Delete Chi tiết phiếu nhập--------------------------------------------------------------
go
CREATE PROC DELETECTPhieuNhap(@sophieunhap varchar(10), @mahanghoa varchar(10))
AS
BEGIN
	DELETE FROM tbl_ChiTietPhieuNhap Where (Sophieunhap=@sophieunhap AND  Mahanghoa=@mahanghoa)
END
go
execute DELETECTPhieuNhap @sophieunhap='spn007', @mahanghoa='sp001'


--10------------stored Delete Chi tiết phiếu xuất-------------------------------------------------------------
go
CREATE PROC DELETECTPhieuXuat(@sophieuxuat varchar(10), @mahanghoa varchar(10))
AS
BEGIN
	DELETE FROM tbl_ChiTietPhieuXuat Where (Sophieuxuat=@sophieuxuat AND  Mahanghoa=@mahanghoa)
END
go
execute DELETECTPhieuXuat @sophieuxuat='spx007', @mahanghoa='sp001'









---------------------------------------------------------
--SELECT Makho AS 'Mã kho', Tenkho AS 'Tên Kho'  FROM tbl_KhoHang

--SELECT Manhom AS 'Mã nhóm', Tên Nhom AS 'Tên nhóm', Makho AS 'Mã kho' FROM tbl_NhomSanPham


--11------------stored Delete Chi tiết phiếu nhập theo số phiếu nhập-------------------------------------------------------------
go
CREATE PROC DELETECTPhieuNhapTheoSPN(@Sophieunhap varchar(10))
AS
BEGIN
	DELETE FROM tbl_ChiTietPhieuNhap Where (Sophieunhap=@Sophieunhap)
END
go
go
--12------------stored Delete Chi tiết phiếu nhập theo số phiếu nhập-------------------------------------------------------------
go
CREATE PROC DELETECTPhieuXuatTheoSPX(@sophieuxuat varchar(10))
AS
BEGIN
	DELETE FROM tbl_ChiTietPhieuXuat Where (Sophieuxuat=@sophieuxuat)
END
go

