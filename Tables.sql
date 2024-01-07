--Customer Table
CREATE TABLE Customer (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(30),
    Email NVARCHAR(20),
    FirstName NVARCHAR(20),
    LastName NVARCHAR(20),
    CreatedOn DATETIME,
    IsActive BIT
);
 
 
--Product Table
CREATE TABLE Product (
    ProductId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductName NVARCHAR(50),
    UnitPrice DECIMAL,
    SupplierId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Supplier(SupplierId),
    CreatedOn DATETIME,
    IsActive BIT
);
 
--Order Table
CREATE TABLE [Order] (
    OrderId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductId UNIQUEIDENTIFIER,
    OrderStatus INT,
    OrderType INT,
    OrderBy UNIQUEIDENTIFIER,
    OrderedOn DATETIME,
    ShippedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
    FOREIGN KEY (OrderBy) REFERENCES Customer(UserId)
);
 
 
-- Create Supplier Table
CREATE TABLE Supplier (
    SupplierId UNIQUEIDENTIFIER PRIMARY KEY,
    SupplierName NVARCHAR(50),
    CreatedOn DATETIME,
    IsActive BIT
);
 
 
-- To end the previous batch
GO
--Stored Procedure 
CREATE PROCEDURE GetActiveOrdersByCustomer
    @CustomerId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        o.OrderId,
        o.OrderStatus,
        o.OrderType,
        o.OrderedOn,
        o.ShippedOn,
        o.IsActive,
        p.ProductName,
        p.UnitPrice,
        s.SupplierName
    FROM [Order] o
    INNER JOIN Product p ON o.ProductId = p.ProductId
    INNER JOIN Supplier s ON p.SupplierId = s.SupplierId
    WHERE o.IsActive = 1 AND o.OrderBy = @CustomerId;
END;
