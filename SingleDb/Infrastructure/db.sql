CREATE DATABASE [single-tenant-db]

GO 

CREATE TABLE [single-tenant-db].[dbo].[Order] (
    [Id] int,
    [Name] varchar(255),
    [TenantId] int,
);

GO

INSERT INTO [single-tenant-db].[dbo].[Order] ([Id], [Name], [TenantId])
VALUES
    (1, 'Order 1', 1),
    (2, 'Order 2', 1),
    (3, 'Order 3', 2);