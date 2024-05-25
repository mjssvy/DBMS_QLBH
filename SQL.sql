use QTHCSDL
CREATE TABLE [dbo].[BangGia] (
    [MaBangGia]  INT        NOT NULL,
    [MaHang]     INT        NULL,
    [MaDVT]      INT        NULL,
    [SoLuongDVT] INT        NULL,
    [GiaMua]     FLOAT (53) NULL,
    [GiaBan]     FLOAT (53) NULL,
    [DaXoa]      NCHAR (10) NULL,
    CONSTRAINT [PK_BangGia] PRIMARY KEY CLUSTERED ([MaBangGia] ASC)
);
CREATE TABLE [dbo].[ChiTietDonHang] (
    [MaChiTiet] INT        NOT NULL,
    [MaDH]      INT        NULL,
    [MaHang]    INT        NULL,
    [GiaMua]    FLOAT (53) NULL,
    [GiaBang]   FLOAT (53) NULL,
    [SoLuong]   INT        NULL,
    [ThanhTien] FLOAT (53) NULL,
    CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED ([MaChiTiet] ASC)
);
CREATE TABLE [dbo].[ChiTietDonHangMua] (
    [MaChiTiet] INT        NULL,
    [MaDH]      INT        NULL,
    [MaHang]    INT        NULL,
    [SoLuong]   INT        NULL,
    [GiaMua]    FLOAT (53) NULL,
    [ThanhTien] FLOAT (53) NULL
);
CREATE TABLE [dbo].[DonHangBan] (
    [MaDH]       INT        NOT NULL,
    [NgayDH]     DATE       NULL,
    [MaNV]       INT        NOT NULL,
    [MaKH]       INT        NULL,
    [TongGiaTri] FLOAT (53) NULL,
    CONSTRAINT [PK_DonHangBan] PRIMARY KEY CLUSTERED ([MaDH] ASC)
);
CREATE TABLE [dbo].[DonHangMua] (
    [MaDH]       INT        NULL,
    [NgayDH]     DATE       NULL,
    [MaNV]       INT        NULL,
    [MaNCC]      INT        NULL,
    [TongGiaTri] FLOAT (53) NULL
);
CREATE TABLE [dbo].[DonViTinh] (
    [MaDVT]  INT           NOT NULL,
    [TenDVT] NVARCHAR (50) NULL,
    [GhiChu] NVARCHAR (50) NULL,
    [DaXoa]  NCHAR (10)    NULL,
    CONSTRAINT [PK_DonViTinh] PRIMARY KEY CLUSTERED ([MaDVT] ASC)
);
CREATE TABLE [dbo].[HangHoa] (
    [MaHang]      INT           NOT NULL,
    [TenHang]     NVARCHAR (50) NULL,
    [MaDVT]       INT           NULL,
    [GiaMua]      FLOAT (53)    NULL,
    [GiaBan]      FLOAT (53)    NULL,
    [GiaBinhQuan] FLOAT (53)    NULL,
    [SoLuongTon]  INT           NULL,
    [NgayCapNhat] DATE          NULL,
    [GhiChu]      NVARCHAR (50) NULL,
    [DaXoa]       NCHAR (10)    NULL,
    CONSTRAINT [PK_HangHoa] PRIMARY KEY CLUSTERED ([MaHang] ASC)
);
CREATE TABLE [dbo].[KhachHang] (
    [MaKH]      INT            NOT NULL,
    [TenKH]     NVARCHAR (50)  NULL,
    [DienThoai] INT            NULL,
    [DiaChi]    NVARCHAR (MAX) NULL,
    [GhiChu]    NVARCHAR (50)  NULL,
    [DaXoa]     NCHAR (10)     NULL,
    CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED ([MaKH] ASC)
);
CREATE TABLE [dbo].[NhaCungCap] (
    [MaNCC]     INT           NOT NULL,
    [TenNCC]    NVARCHAR (50) NULL,
    [DienThoai] INT           NULL,
    [DiaChi]    NVARCHAR (50) NULL,
    [GhiChu]    NVARCHAR (50) NULL,
    [DaXoa]     NCHAR (10)    NULL,
    CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED ([MaNCC] ASC)
);
CREATE TABLE [dbo].[NhanVien] (
    [MaNV]      INT            NOT NULL,
    [TenNV]     NVARCHAR (50)  NULL,
    [DienThoai] INT            NULL,
    [DiaChi]    NVARCHAR (MAX) NULL,
    [TaiKhoan]  NVARCHAR (50)  NULL,
    [MatKhau]   NVARCHAR (50)  NULL,
    [Quyen]     NCHAR (10)     NULL,
    [GhiChu]    NVARCHAR (50)  NULL,
    [DaXoa]     NCHAR (10)     NULL,
    CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED ([MaNV] ASC)
);