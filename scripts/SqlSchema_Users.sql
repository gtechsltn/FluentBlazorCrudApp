USE [FluentBlazorDb]
GO

--DROP TABLE [dbo].[Users];
--TRUNCATE TABLE [dbo].[Users];
--DELETE FROM [dbo].[Users];

CREATE TABLE [dbo].[Users] (
    ID INT PRIMARY KEY,
	[Username] VARCHAR(50),
    [Email] VARCHAR(100),
	[UsernameToLower] VARCHAR(50) UNIQUE,
    [EmailToLower] VARCHAR(100) UNIQUE,
    [PasswordHash] VARCHAR(255)
);

ALTER TABLE [dbo].[Users]
	ADD CONSTRAINT [UQ_Users_UsernameToLower] UNIQUE ([UsernameToLower]);

-- Tạo chỉ mục duy nhất cho cột Username
CREATE UNIQUE INDEX [IX_UsernameToLower] ON Users ([UsernameToLower]);

-- Tạo chỉ mục duy nhất cho cột Email
CREATE UNIQUE INDEX [IX_EmailToLower] ON Users ([EmailToLower]);

DBCC CHECKIDENT ('[dbo].[Users]', RESEED, 0);

--This command resets the next available ID to 1. The RESEED value is the value of the last ID used, so setting it to 0 means the next ID will be 1.

--Cannot insert duplicate key row in object 'dbo.Users' with unique index 'IX_Users_UsernameToLower'. The duplicate key value is (admin).

INSERT INTO [dbo].[Users]([Username], [UsernameToLower], [Email], [EmailToLower], [HashedPassword], [Salt]) VALUES (N'Admin', N'admin', N'admin@customer.net', N'admin@customer.net', N'$2a$12$7nvD6HXBR0yrEAZukvQbh.aaR.rePrnmjVpA2VoCbcKEVw9h2FI/i', N'$2a$12$etl9Yao5aI1TgwfXkLnv4u')

--Cannot insert duplicate key row in object 'dbo.Users' with unique index 'IX_Users_UsernameToLower'. The duplicate key value is (manh.nguyen).

INSERT INTO [dbo].[Users]([Username], [UsernameToLower], [Email], [EmailToLower], [HashedPassword], [Salt]) VALUES (N'manh.nguyen', N'manh.nguyen', N'manh.nguyen@thirdsight.net', N'manh.nguyen@thirdsight.net', N'$2a$12$7nvD6HXBR0yrEAZukvQbh.aaR.rePrnmjVpA2VoCbcKEVw9h2FI/i', N'$2a$12$etl9Yao5aI1TgwfXkLnv4u')

SELECT TOP (1000) [Id]
    ,[Username]
	,[UsernameToLower]
    ,[HashedPassword]
    ,[Salt]
FROM [dbo].[Users]

/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[HashedPassword] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[UsernameToLower] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [HashedPassword], [Salt], [UsernameToLower]) VALUES (1, N'Admin', N'$2a$12$7nvD6HXBR0yrEAZukvQbh.aaR.rePrnmjVpA2VoCbcKEVw9h2FI/i', N'$2a$12$etl9Yao5aI1TgwfXkLnv4u', N'admin')
GO
INSERT [dbo].[Users] ([Id], [Username], [HashedPassword], [Salt], [UsernameToLower]) VALUES (2, N'manh.nguyen', N'$2a$12$7nvD6HXBR0yrEAZukvQbh.aaR.rePrnmjVpA2VoCbcKEVw9h2FI/i', N'$2a$12$etl9Yao5aI1TgwfXkLnv4u', N'manh.nguyen')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
*/

-- Find the duplicate rows:
-- ===> Run query below
SELECT Username, COUNT(*)
FROM [dbo].[Users]
GROUP BY Username
HAVING COUNT(*) > 1;

SELECT UsernameToLower, COUNT(*)
FROM [dbo].[Users]
GROUP BY UsernameToLower
HAVING COUNT(*) > 1;

SELECT EmailToLower, COUNT(*)
FROM [dbo].[Users]
GROUP BY EmailToLower
HAVING COUNT(*) > 1;

SELECT Email, COUNT(*)
FROM [dbo].[Users]
GROUP BY Email
HAVING COUNT(*) > 1;

-- Delete the duplicate rows: If the duplicate rows are redundant and not needed, you can delete them.
-- ===> Run query below
;WITH CTE AS (
    SELECT
        [UsernameToLower],
        ROW_NUMBER() OVER (PARTITION BY [UsernameToLower] ORDER BY ID) AS rn
    FROM [dbo].[Users]
)
DELETE FROM CTE
WHERE rn > 1;