CREATE DATABASE LibrariesDb
GO
USE LibrariesDb

CREATE TABLE Book (
    	Id int IDENTITY(1,1) PRIMARY KEY,
    	Name nvarchar(255) NOT NULL,
    	Author nvarchar(255) NOT NULL,
    	Note nvarchar(max)
);

GO

INSERT INTO Book (Name, Author, Note)
VALUES(N'Hệ điều hành', 'HCMUS', N''),
VALUES(N'Mạng máy tính', 'HCMUS', N''),
VALUES(N'Phân tích và thiết kế phần mềm', 'HCMUS', N'')