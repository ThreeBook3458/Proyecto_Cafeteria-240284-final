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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207021915_InitialCreate'
)
BEGIN
    CREATE TABLE [Productos] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(100) NOT NULL,
        [Descripcion] nvarchar(500) NOT NULL,
        [Precio] decimal(18,2) NOT NULL,
        [Stock] int NOT NULL,
        [ImagenUrl] nvarchar(max) NULL,
        [ImagenBase64] nvarchar(max) NULL,
        CONSTRAINT [PK_Productos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207021915_InitialCreate'
)
BEGIN
    CREATE TABLE [Users] (
        [Username] nvarchar(50) NOT NULL,
        [Password] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Username])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207021915_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Username', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([Username], [Password])
    VALUES (N''admin'', N''admin123'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Username', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207021915_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251207021915_InitialCreate', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207023244_SeedInitialData'
)
BEGIN
    EXEC(N'DELETE FROM [Users]
    WHERE [Username] = N''admin'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207023244_SeedInitialData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'ImagenBase64', N'ImagenUrl', N'Nombre', N'Precio', N'Stock') AND [object_id] = OBJECT_ID(N'[Productos]'))
        SET IDENTITY_INSERT [Productos] ON;
    EXEC(N'INSERT INTO [Productos] ([Id], [Descripcion], [ImagenBase64], [ImagenUrl], [Nombre], [Precio], [Stock])
    VALUES (1, N''Café espresso diluido con agua caliente'', NULL, N''/images/CafeAmericano.jpg'', N''Café Americano'', 35.0, 100),
    (2, N''Espresso con leche vaporizada y espuma'', NULL, N''/images/cappuccinoAmericano.jpg'', N''Cappuccino'', 45.0, 80),
    (3, N''Café espresso con abundante leche'', NULL, N''/images/Latte.jpg'', N''Latte'', 48.0, 75),
    (4, N''Mezcla de café, chocolate y leche'', NULL, N''/images/Moka.jpg'', N''Moka'', 52.0, 60),
    (5, N''Té de hierbas verdes con hielos'', NULL, N''/images/Matcha.jpg'', N''Matcha'', 120.0, 25)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descripcion', N'ImagenBase64', N'ImagenUrl', N'Nombre', N'Precio', N'Stock') AND [object_id] = OBJECT_ID(N'[Productos]'))
        SET IDENTITY_INSERT [Productos] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207023244_SeedInitialData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Username', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([Username], [Password])
    VALUES (N''Aaronh'', N''huerta12.Ar'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Username', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251207023244_SeedInitialData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251207023244_SeedInitialData', N'8.0.11');
END;
GO

COMMIT;
GO

