﻿CREATE DATABASE [core-db]

GO

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

CREATE DATABASE [tenant-2-db]

GO 

CREATE TABLE [tenant-2-db].[dbo].[Orders] (
    [Id] int,
    [Name] varchar(255),
);

INSERT INTO [tenant-2-db].[dbo].[Orders] ([Id], [Name])
VALUES
    (3, 'Order 3');

