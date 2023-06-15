CREATE DATABASE QuanLyGarageOto

create table QUYENHAN
(
 MaQH int primary key,
 TenQH varchar(50)
)


CREATE TABLE TAIKHOAN(
   MaTK int primary key,
   MaQH int,
   TenChuTaiKhoan varchar(50),
   TenDangNhap varchar(50),
   MatKhau varchar(50)
)

alter table TAIKHOAN add foreign key (MaQH) references QUYENHAN(MaQH)  

DROP TABLE TAIKHOAN
DROP TABLE QUYENHAN

CREATE TABLE TAIKHOAN(
   MaTK int primary key,
   TenChuTaiKhoan varchar(50),
   TenDangNhap varchar(50),
   MatKhau varchar(50)
)
DROP TABLE TAIKHOAN

create table QUYENHAN
(
 MaQH int primary key,
 TenQH varchar(50)
)


CREATE TABLE TAIKHOAN(
   MaTK int primary key,
   TenChuTaiKhoan varchar(50),
   TenDangNhap varchar(50),
   MatKhau varchar(50),
   TenQH varchar (50)
)

DROP TABLE TAIKHOAN

CREATE TABLE TAIKHOAN(
   MaTK int primary key,
   TenChuTaiKhoan varchar(50),
   TenDangNhap varchar(50),
   MatKhau varchar(50),
   MaQH int
)

alter table TAIKHOAN add foreign key (MaQH) references QUYENHAN(MaQH)  

DROP TABLE TAIKHOAN
DROP TABLE QUYENHAN

CREATE TABLE TAIKHOAN(
   MaTK int primary key,
   TenChuTaiKhoan varchar(50),
   TenDangNhap varchar(50),
   MatKhau varchar(50),
   TenQH varchar (50)
)

CREATE TABLE THAMSO(
MaThamSo varchar(5),
 TenThamSo varchar(50) primary key,
 GiaTri int
)

create table HIEUXE
(
	MaHX int PRIMARY KEY,
	TenHieuXe varchar(30)
)

CREATE TABLE TIENCONG(
 MaTC int primary key,
 TenTienCong varchar(50),
 ChiPhi int
) 

CREATE TABLE KHACHHANG(
 MaKH int primary key,
 TenKH varchar(50),
 DienThoai int,
 DiaChi varchar(100)
)

CREATE TABLE XE(
 BienSo varchar(10) primary key,
 MaHX int,
 MaKH int,
 TienNo int,
 NgayTiepNhan datetime
)

alter table XE add foreign key (MaHX) references HIEUXE(MaHX)
alter table XE add foreign key (MaKH) references KHACHHANG(MaKH)

create table VATTUPHUTUNG(
 MaVTPT int primary key,
 TenVTPT varchar(50),
 DonGiaNhap int,
 DonGiaBan int,
 SoLuong int
)

Create table PHIEUTHUTIEN(
 MaPhieuThuTien int primary key,
 BienSo varchar(10),
 TienThu int,
 NgayThuTien datetime
)

alter table PHIEUTHUTIEN add foreign key (BienSo) references XE(BienSo)


CREATE TABLE PHIEUSUACHUA(
	MaPhieuSuaChua int primary key,
	BienSo varchar(10) NULL,
	MaKH int NULL,
	TienCong int NULL,
	TienVTPT int NULL,
	TongTien int NULL)

ALTER TABLE PHIEUSUACHUA ADD FOREIGN KEY (BienSo) REFERENCES XE (BienSo)
ALTER TABLE PHIEUSUACHUA  WITH CHECK ADD FOREIGN KEY(MaKH) REFERENCES KHACHHANG (MaKH)

create table CT_PHIEUSUACHUA(
 MaPhieuSuaChua int,
 MaTC int,
 MaVTPT int,
 SoLuongVTPT int
)

alter table CT_PHIEUSUACHUA add foreign key (MaPhieuSuaChua) references PHIEUSUACHUA(MaPhieuSuaChua)
alter table CT_PHIEUSUACHUA add foreign key (MaTC) references TIENCONG(MaTC)
alter table CT_PHIEUSUACHUA add foreign key (MaVTPT) references VATTUPHUTUNG(MaVTPT)

CREATE TABLE PHIEUNHAPVTPT
(
MaPNVTPT int primary key,
MaVTPT int,
SoLuong int,
ThoiDiem datetime
)

alter table PHIEUNHAPVTPT add foreign key (MaVTPT) references VATTUPHUTUNG(MaVTPT)


create table CT_SUDUNGVTPT(
 MaPhieuSuaChua int,
 MaVTPT int,
 SuDung int,
 DonGia int,
 ThanhTien int,
 primary key ( MaPhieuSuaChua, MaVTPT)
)

alter table CT_SUDUNGVTPT add foreign key (MaPhieuSuaChua) references PHIEUSUACHUA(MaPhieuSuaChua)
alter table CT_SUDUNGVTPT add foreign key (MaVTPT) references VATTUPHUTUNG(MaVTPT)

DROP TABLE CT_SUDUNGVTPT

create table BAOCAODOANHSO(
 MaBCDS int,
 Thang int,
 Nam int,
 TongDoanhThu int,
 primary key (MaBCDS)
)


create table CT_BAOCAODOANHSO(
 MaBCDS int,
 MaHX int,
 SoLuotSua int,
 ThanhTien int,
 TiLe int,
 primary key (MaBCDS, MaHX)
)

alter table CT_BAOCAODOANHSO add constraint A foreign key (MaBCDS) references BAOCAODOANHSO(MaBCDS)
alter table CT_BAOCAODOANHSO add foreign key (MaHX) references HIEUXE(MaHX)

create table BAOCAOTON(
 MaVTPT int,
ThoiDiemBaoCao datetime,
 TonDau int,
 TonCuoi int,
 PhatSinh int,
 primary key (MaVTPT,ThoiDiemBaoCao)
)

alter table BAOCAOTON add foreign key (MaVTPT) references VATTUPHUTUNG(MaVTPT)

DROP TABLE BAOCAOTON

CREATE TABLE BAOCAOTON(
	MaBCT int PRIMARY KEY,
	ThoiDiemBaoCao datetime)

CREATE TABLE CT_BAOCAOTON(
	MaBCT int,
	MaVTPT int,
	TonDau int,
	PhatSinh int,
	TonCuoi int,
	 primary key (MaBCT,MaVTPT)
)
alter table CT_BAOCAOTON add foreign key (MaBCT) references BAOCAOTON(MaBCT)
alter table CT_BAOCAOTON add foreign key (MaVTPT) references VATTUPHUTUNG(MaVTPT)

SET DATEFORMAT dmy

INSERT [dbo].[THAMSO] ([MaThamSo], [TenThamSo], [GiaTri]) VALUES (N'TS1', N'phan tram ti le gia ban', 125)
INSERT [dbo].[THAMSO] ([MaThamSo], [TenThamSo], [GiaTri]) VALUES (N'TS2', N'So xe sua chua toi da', 30)

INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (0, N'Lexus')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (1, N'Audi')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (2, N'Mazda')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (3, N'Mercedes')
INSERT [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (4, N'Ford')

INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (0, N'Thay den xe', 50000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (1, N'Thay guong chieu hau', 100000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (2, N'Thay kinh chan gio', 70000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (3, N'Thay bugi', 150000)
INSERT [dbo].[TIENCONG] ([MaTC], [TenTienCong], [ChiPhi]) VALUES (4, N'Thay lop xe', 60000)

INSERT [dbo].[VATTUPHUTUNG] ([MaVTPT], [TenVTPT], [DonGiaNhap], [DonGiaBan], [SoLuong]) VALUES (0, N'den xe', 100000, 125000, 3)
INSERT TAIKHOAN (MaTK, TenChuTaiKhoan, TenDangNhap, MatKhau) VALUES (0, N'Nguyen Van Boss', N'boss', N'1234')

DELETE FROM TAIKHOAN

INSERT TAIKHOAN (MaTK, TenChuTaiKhoan, TenDangNhap, MatKhau) VALUES (0, N'Nguyen Van Boss', N'boss', N'1234')

DELETE FROM TAIKHOAN
DELETE FROM QUYENHAN

INSERT QUYENHAN (MaQH, TenQH) VALUES (0, N'Admin')
INSERT QUYENHAN (MaQH, TenQH) VALUES (1, N'Staff')

INSERT TAIKHOAN (MaTK, TenChuTaiKhoan, TenDangNhap, MatKhau, MaQH) VALUES (0, N'Doan Ngoc Quynh Thu', N'Thu',N'1234',0)
INSERT TAIKHOAN (MaTK, TenChuTaiKhoan, TenDangNhap, MatKhau, MaQH) VALUES (1, N'Nguyen Van A', N'A',N'5678',1)

INSERT [dbo].[TAIKHOAN] ([MaTK], [TenChuTaiKhoan], [TenDangNhap], [MatKhau], [TenQH]) VALUES (0, N'Doan Ngoc Quynh Thu', N'boss', N'0', N'admin')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TenChuTaiKhoan], [TenDangNhap], [MatKhau], [TenQH]) VALUES (1, N'Nguyen Van A', N'A', N'1234', N'staff')



DELETE FROM CT_PHIEUSUACHUA
DELETE FROM PHIEUSUACHUA
DELETE FROM PHIEUTHUTIEN
DELETE FROM XE
DELETE FROM KHACHHANG
DELETE FROM PHIEUNHAPVTPT
DELETE FROM CT_BAOCAOTON
DELETE FROM BAOCAOTON
DELETE FROM VATTUPHUTUNG
DELETE FROM CT_BAOCAODOANHSO
DELETE FROM BAOCAODOANHSO

GO
CREATE PROCEDURE [dbo].[ThemKhachHang]
	@TenKH varchar(30),
	@DienThoai varchar(10),
	@DiaChi varchar(100)
AS
BEGIN
	DECLARE @test int
	SELECT @test=COUNT(MaKH) FROM KHACHHANG WHERE (@TenKH = TenKH) and (@DienThoai = DienThoai) 
	if @test = 0
	BEGIN
		DECLARE @imakh int
		select  @imakh = MAX(MaKH) from KHACHHANG
		IF (@imakh is null) set @imakh = 0
		else set @imakh = @imakh + 1			
		INSERT INTO KHACHHANG (MaKH, TenKH, DiaChi, DienThoai) VALUES (@imakh, @TenKH, @DiaChi,@DienThoai)
	END
END;
GO

CREATE PROCEDURE [dbo].[ThemXe]
	@BienSo varchar(10) ,
	@HieuXe int,
	@NgayTiepNhan datetime,
	@MaKH int,
	@TienNo int
AS
BEGIN
	INSERT INTO XE (BienSo, MaHX, NgayTiepNhan, MaKH, TienNo) VALUES (@BienSo, @HieuXe, @NgayTiepNhan, @MaKH, @TienNo)
END;
GO

create procedure [dbo].[NhapVTPT]
	@MaPhuTung int,
	@SoLuong int,
	@ThoiDiem datetime
AS
BEGIN
	DECLARE @iMPNVTPT int
	SELECT @iMPNVTPT = COUNT(MaPNVTPT) FROM PHIEUNHAPVTPT
	SET @iMPNVTPT = @iMPNVTPT + 1
	INSERT INTO PHIEUNHAPVTPT (MaPNVTPT, MaVTPT, SoLuong, ThoiDiem) VALUES (@iMPNVTPT, @MaPhuTung, @SoLuong, @ThoiDiem)
	UPDATE VATTUPHUTUNG SET SoLuong = SoLuong + @SoLuong WHERE MaVTPT = @MaPhuTung
END
GO

create procedure [dbo].[NhapMoiVTPT]
	@TenPhuTung varchar(30),
	@SoLuong int,
	@DonGiaNhap int,
	@DonGiaBan int,
	@ThoiDiem datetime
AS
BEGIN
	DECLARE @iMPNVTPT int
	SELECT @iMPNVTPT = COUNT(MaPNVTPT) FROM PHIEUNHAPVTPT
	SET @iMPNVTPT = @iMPNVTPT + 1
	DECLARE @iMVTPT int
	SELECT @iMVTPT = COUNT(MaVTPT) FROM VATTUPHUTUNG
	SET @iMVTPT = @iMVTPT + 1
	INSERT INTO VATTUPHUTUNG (MaVTPT, TenVTPT, DonGiaNhap, DonGiaBan, SoLuong) VALUES (@iMVTPT, @TenPhuTung, @DonGiaNhap, @DonGiaBan, @SoLuong)
	INSERT INTO PHIEUNHAPVTPT (MaPNVTPT, MaVTPT, SoLuong, ThoiDiem) VALUES (@iMPNVTPT, @iMVTPT, @SoLuong, @ThoiDiem)
END
GO

CREATE PROCEDURE [dbo].[ThemPhieuThuTien]
	@BienSo varchar(10),
	@TienThu int,
	@NgayThuTien datetime
AS
BEGIN
		DECLARE @imaptt int
		SELECT @imaptt = COUNT(MaPhieuThuTien) from PHIEUTHUTIEN
		SET @imaptt = @imaptt + 1
		INSERT INTO PHIEUTHUTIEN (MaPhieuThuTien, BienSo, TienThu, NgayThuTien) VALUES (@imaptt, @BienSo, @TienThu, @NgayThuTien)
		UPDATE XE SET TienNo = TienNo - @TienThu WHERE BienSo = @BienSo
END
GO

create procedure [dbo].[TimKiemTuongDoi]
	@DuLieu varchar(100)
AS
BEGIN
	SELECT BienSo, TenHieuXe, TenKH, TienNo
	FROM XE, HIEUXE as HX, KHACHHANG as KH
	WHERE XE.MaHX = HX.MaHX and KH.MaKH = XE.MaKH and ((BienSo LIKE '%'+@DuLieu+'%') or (TenHieuXe LIKE '%'+@DuLieu+'%') or (TenKH LIKE '%'+@DuLieu+'%') or (TienNo LIKE '%'+@DuLieu+'%'))
END
GO

create procedure [dbo].[TimKiemChinhXac]
	@BienSo varchar(10),
	@HieuXe varchar(30)
AS
BEGIN
	SELECT BienSo, TenHieuXe, TenKH, TienNo
	FROM XE, HIEUXE as HX, KHACHHANG as KH
	WHERE XE.MaHX = HX.MaHX and KH.MaKH = XE.MaKH and @BienSo = XE.BienSo and @HieuXe = HX.TenHieuXe 
END
GO

DROP PROC TimKiemTuongDoi
GO
DROP PROC TimKiemChinhXac
GO
create procedure [dbo].[TimKiemTuongDoi]
	@DuLieu varchar(100)
AS
BEGIN
	SELECT BienSo as 'Biển số', TenHieuXe as 'Tên hiệu xe', TenKH as 'Tên khách hàng', TienNo as 'Tiền nợ'
	FROM XE, HIEUXE as HX, KHACHHANG as KH
	WHERE XE.MaHX = HX.MaHX and KH.MaKH = XE.MaKH and ((BienSo LIKE '%'+@DuLieu+'%') or (TenHieuXe LIKE '%'+@DuLieu+'%') or (TenKH LIKE '%'+@DuLieu+'%') or (TienNo LIKE '%'+@DuLieu+'%'))
END
GO

create procedure [dbo].[TimKiemChinhXac]
	@BienSo varchar(10),
	@HieuXe varchar(30)
AS
BEGIN
	SELECT BienSo as 'Biển số', TenHieuXe as 'Tên hiệu xe', TenKH as 'Tên khách hàng', TienNo as 'Tiền nợ'
	FROM XE, HIEUXE as HX, KHACHHANG as KH
	WHERE XE.MaHX = HX.MaHX and KH.MaKH = XE.MaKH and @BienSo = XE.BienSo and @HieuXe = HX.TenHieuXe 
END
GO


create procedure [dbo].[BaoCaoDoanhThu]
		@Thang int,
		@Nam int
AS
BEGIN
	select HX.TenHieuXe as 'Hiệu Xe', COUNT(PSC.MaPhieuSuaChua) as 'Số Lượt Sửa', SUM(PTT.TienThu) as 'Thành Tiền', (COUNT(PSC.MaPhieuSuaChua)*100/(SELECT Count(*) FROM  PHIEUTHUTIEN as PTT, PHIEUSUACHUA as PSC where  PTT.BienSo = PSC.BienSo and Month(PTT.NgayThuTien) = @Thang and YEAR(PTT.NgayThuTien) = @Nam) ) as 'Tỉ Lệ'
	FROM KHACHHANG as KH, XE, HIEUXE as HX, PHIEUTHUTIEN as PTT, PHIEUSUACHUA as PSC
	WHERE KH.MaKH = XE.MaKH and XE.MaHX = HX.MaHX and PTT.BienSo = PSC.BienSo and PSC.BienSo = Xe.BienSo and Month(PTT.NgayThuTien) = @Thang and YEAR(PTT.NgayThuTien) = @Nam
	Group by HX.TenHieuXe
END
GO

create procedure [dbo].[TongTienDoanhThu]
		@Thang int,
		@Nam int
AS
BEGIN
	select sum(PTT.TienThu)
	from PHIEUTHUTIEN as PTT
	WHERE Month(PTT.NgayThuTien) = @Thang and YEAR(PTT.NgayThuTien) = @Nam
END
GO

CREATE PROC [dbo].[USP_DangNhap]
@TenDangNhap nvarchar(50), @MatKhau nvarchar(50)
AS
BEGIN
	SELECT * FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau
END
GO

create procedure [dbo].[DoiMK]
	@MaTK int,
	@MatKhauMoi varchar(20)
AS
BEGIN
	UPDATE TAIKHOAN
	SET MatKhau = @MatKhauMoi 
	WHERE MaTK = @MaTK
END
GO

create procedure [dbo].[XoaVTPT]
		@TenVTPT varchar(50)
AS
BEGIN
	DECLARE @iMaVTPT int
	SELECT @iMaVTPT = MaVTPT FROM VATTUPHUTUNG WHERE TenVTPT=@TenVTPT
    DELETE FROM PHIEUNHAPVTPT WHERE PHIEUNHAPVTPT.MaVTPT=@iMaVTPT
	DELETE FROM CT_BAOCAOTON WHERE CT_BAOCAOTON.MaVTPT=@iMaVTPT
	DELETE FROM VATTUPHUTUNG WHERE TenVTPT=@TenVTPT
END
GO

--SELECT COUNT(MaPhieuSuachua) as 'So lan sua' FROM PHIEUSUACHUA, XE WHERE XE.BienSo=PHIEUSUACHUA.BienSo AND PHIEUSUACHUA.BienSo='A1234'