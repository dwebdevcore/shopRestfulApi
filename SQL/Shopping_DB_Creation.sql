-- USAGE
-- This schema supports minimal functionality of a sales application

-- ASSUMPTIONS (These has been considered to ensure schema is light-weight)
-- a) No categories 
-- b) No returns
-- c) Users do not change their location
-- d) Existing product names/descriptions do not change, but their prices can vary


-- WARNING
-- Script drops all the tables if they exist, prior to creation

-- Step 1 - Drop and re-create the tables
DROP TABLE OrderItems
DROP TABLE Orders
DROP TABLE Products
DROP TABLE Users


-- Step 2 - Table creation
-- Table:	Users 
-- Usage:	Stores all user related information. Id is an identity column.
CREATE TABLE Users (
    Id uniqueidentifier PRIMARY KEY,
	[Firstname] nvarchar(255) NOT NULL,
	[Lastname] nvarchar(255)  NOT NULL,
	[AddressOne] nvarchar(255)  NOT NULL,
	[AddressTwo] nvarchar(255)  NULL,
	[City] nvarchar(255)  NOT NULL,
	[State] nvarchar(2) NOT NULL,
	[Zip] nvarchar(5) NOT NULL
);

-- Table:	Products 
-- Usage:	Stores all product related information(Master data). Id is an identity column.
CREATE TABLE Products (
    Id uniqueidentifier PRIMARY KEY,
	[Name] nvarchar(255) NOT NULL,
	[Description] nvarchar(1024) NULL,
	[PurchasePrice] real NOT NULL,
	[SalePrice] real NOT NULL,
	[ImageUrl] nvarchar(1024) NOT NULL
);

-- Table:	Orders 
-- Usage:	Stores all order related information. Id is an identity column.
CREATE TABLE Orders (
    Id uniqueidentifier PRIMARY KEY,
	[TransactionDate] datetime NOT NULL,
	UserId nvarchar(255) NOT NULL				-- user that placed the order
);

-- Table:	Orders 
-- Usage:	Stores all order related information. Id is an identity column.
CREATE TABLE OrderItems (
    Id uniqueidentifier PRIMARY KEY,
	OrderId nvarchar(255) NOT NULL,				-- order the item/product is part of
	ProductId nvarchar(255) NOT NULL,				-- item ordered
	Qty int NOT NULL,					-- number of units
	PurchasePrice real NOT NULL,
	SalePrice real NOT NULL
);
