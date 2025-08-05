CREATE DATABASE FluentDb;
GO
USE FluentDb;
GO
CREATE TABLE Products (Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(100), Price DECIMAL(18,2));
INSERT INTO Products (Name, Price) VALUES ('Laptop',1200),('Keyboard',99),('Mouse',49);
