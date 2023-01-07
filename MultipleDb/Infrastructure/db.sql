CREATE DATABASE [core-db]

GO

CREATE TABLE [core-db].[dbo].[Tenants] (
    [Id] int,
    [DbName] varchar(255),
);

GO

INSERT INTO [core-db].[dbo].[Tenants] ([Id], [DbName])
VALUES
    (1, 'tenant-1-db'),
    (2, 'tenant-2-db');

GO

---

CREATE DATABASE [tenant-1-db]

GO 

CREATE TABLE [tenant-1-db].[dbo].[Orders] (
    [Id] int,
    [Name] varchar(255),
);

INSERT INTO [tenant-1-db].[dbo].[Orders] ([Id], [Name])
VALUES
    (1, 'Order 1'),
    (2, 'Order 2');
    
GO

CREATE TABLE [tenant-1-db].[dbo].[OrderItems] (
    [Id] int,
    [Name] varchar(255),
    [OrderId] int,
);

GO

INSERT INTO [tenant-1-db].[dbo].[OrderItems] ([Id], [Name], [OrderId])
VALUES
    (1, 'Product 1', 2),
    (2, 'Product 1', 2);

GO

---

CREATE DATABASE [tenant-2-db]

GO 

CREATE TABLE [tenant-2-db].[dbo].[Orders] (
    [Id] int,
    [Name] varchar(255),
);

INSERT INTO [tenant-2-db].[dbo].[Orders] ([Id], [Name])
VALUES
    (3, 'Order 3');
    
GO

CREATE TABLE [tenant-2-db].[dbo].[OrderItems] (
    [Id] int,
    [Name] varchar(255),
    [OrderId] int,
);
