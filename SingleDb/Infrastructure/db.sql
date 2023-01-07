CREATE DATABASE [single-tenant-db]

GO 

CREATE TABLE [single-tenant-db].[dbo].[Orders] (
    [Id] int,
    [Name] varchar(255),
    [TenantId] int,
);

GO

INSERT INTO [single-tenant-db].[dbo].[Orders] ([Id], [Name], [TenantId])
VALUES
    (1, 'Order 1', 1),
    (2, 'Order 2', 1),
    (3, 'Order 3', 2);

GO

CREATE TABLE [single-tenant-db].[dbo].[OrderItems] (
    [Id] int,
    [Name] varchar(255),
    [OrderId] int,
);

GO

INSERT INTO [single-tenant-db].[dbo].[OrderItems] ([Id], [Name], [OrderId])
VALUES
    (1, 'Product 1', 2),
    (2, 'Product 1', 2);
