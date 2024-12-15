CREATE DATABASE QLikhachsan
GO
USE QLikhachsan
GO
CREATE TABLE Phong 
(
    IDphong    INT IDENTITY (1, 1)  PRIMARY KEY,
    Phongtrong VARCHAR (250) NOT NULL,
    Loaiphong  VARCHAR (250) NOT NULL,
    Giuong     VARCHAR (250) NOT NULL,
    Gia        BIGINT        NOT NULL,
    Dadat      VARCHAR (50)  DEFAULT ('NO') NULL
)
CREATE TABLE Khachhang (
    IDkhachhang  INT           IDENTITY (1, 1) PRIMARY KEY,
    Tenkhachhang VARCHAR (250) NOT NULL,
    Sdt          BIGINT        NOT NULL,
    Quoctich     VARCHAR (250) NOT NULL,
    Gioitinh     VARCHAR (50)  NOT NULL,
    Ngaysinh      VARCHAR (50)  NOT NULL,
    CCCD         VARCHAR (250) NOT NULL,
    Diachi       VARCHAR (350) NOT NULL,
    Nhanphong    VARCHAR (250) NOT NULL,
    Traphong     VARCHAR (250) ,
    Thanhtoan    VARCHAR (250) DEFAULT ('NO'),
    IDphong      INT           NOT NULL,
    FOREIGN KEY (IDphong) REFERENCES[Phong] ([IDphong])
)
CREATE TABLE Nhanvien (
    IDnhanvien     INT           IDENTITY (1, 1) NOT NULL,
    Tennhanvien    VARCHAR (250) NOT NULL,
    Sdt            BIGINT        NOT NULL,
    Gioitinh       VARCHAR (50)  NOT NULL,
    Email    VARCHAR (120) NOT NULL,
    Tennguoidung   VARCHAR (150) NOT NULL,
    Matkhau       VARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED (IDnhanvien ASC)
)
