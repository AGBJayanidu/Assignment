# Assignment

# Overview 
This sample project demonstrates the creation of a .NET Core Web API using ADO.NET for data access. The API manages entities like Customer, Order, Product, and Supplier through various endpoints, supporting CRUD operations and a specific query.

# Table Structures

# Customer
* UserId (guid) - Primary Key
* Username (string (30))
* Email (string (20))
* FirstName (String (20))
* LastName (String (20))
* CreatedOn (DateTime)
* IsActive (Boolean)

# Order
* OrderId (guid) - Primary Key
* ProductId (Guid) - Foreign Key to Product Table
* OrderStatus (int (1))
* OrderType (int (1))
* OrderBy (Guid) - Foreign Key to User Table
* OrderedOn (DateTime)
* ShippedOn (DateTime)
* IsActive (Boolean)

# Product
* ProductId (guid) - Primary Key
* ProductName (string (50))
* UnitPrice (decimal)
* SupplierId (Guid) - Foreign Key to Supplier Table
* CreatedOn (DateTime)
* IsActive (Boolean)

# Supplier
* SupplierId (guid)
* SupplierName (string (50))
* CreatedOn (DateTime)
* IsActive (Boolean)

Database setup: Use the SQL scripts provided in the DatabaseScripts foler to create the required tables and stored procedure.

API setup: Open the Visual Studio and configure the database concetion string in the appsettings.jason file

Run the API: build and Run the API -> dotnet run
