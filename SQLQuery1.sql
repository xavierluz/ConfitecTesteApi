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

CREATE TABLE [Escolaridades] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(100) NOT NULL,
    [TipoEscolaridade] int NOT NULL,
    CONSTRAINT [PK_Escolaridades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(50) NOT NULL,
    [SobreNome] nvarchar(50) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [TipoEscolaridade] int NOT NULL,
    [EscolaridadeId] int NOT NULL,
    [HistoricoEscolaridadeId] int NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_Escolaridades_HistoricoEscolaridadeId] FOREIGN KEY ([HistoricoEscolaridadeId]) REFERENCES [Escolaridades] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Usuarios_HistoricoEscolaridadeId] ON [Usuarios] ([HistoricoEscolaridadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220821185451_InitialCreate', N'6.0.8');
GO

COMMIT;
GO