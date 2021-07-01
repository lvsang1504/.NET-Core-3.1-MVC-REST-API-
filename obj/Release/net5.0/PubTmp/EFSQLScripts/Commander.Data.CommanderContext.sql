IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701015409_InitalMigration')
BEGIN
    CREATE TABLE [Notifications] (
        [Id] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NOT NULL,
        [IdStudent] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NOT NULL,
        [TimeCreated] datetime2 NOT NULL,
        [isRead] bit NOT NULL,
        [isDelete] bit NOT NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701015409_InitalMigration')
BEGIN
    CREATE TABLE [PeriodicReportItem] (
        [Id] int NOT NULL IDENTITY,
        [TopicCode] nvarchar(max) NOT NULL,
        [IdStudent] nvarchar(max) NOT NULL,
        [Field] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NOT NULL,
        [DateStarted] datetime2 NOT NULL,
        [DateEnd] datetime2 NOT NULL,
        CONSTRAINT [PK_PeriodicReportItem] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701015409_InitalMigration')
BEGIN
    CREATE TABLE [Topics] (
        [Id] int NOT NULL IDENTITY,
        [TopicCode] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Field] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [Image] nvarchar(max) NOT NULL,
        [Type] nvarchar(max) NOT NULL,
        [Budget] int NOT NULL,
        [DateCreated] datetime2 NOT NULL,
        [AcceptanceTime] datetime2 NOT NULL,
        [Note] nvarchar(max) NULL,
        CONSTRAINT [PK_Topics] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701015409_InitalMigration')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Role] int NOT NULL,
        [KeyFirebase] nvarchar(max) NULL,
        [IdStudent] nvarchar(10) NOT NULL,
        [Name] nvarchar(250) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Class] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701015409_InitalMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210701015409_InitalMigration', N'5.0.6');
END;
GO

COMMIT;
GO

