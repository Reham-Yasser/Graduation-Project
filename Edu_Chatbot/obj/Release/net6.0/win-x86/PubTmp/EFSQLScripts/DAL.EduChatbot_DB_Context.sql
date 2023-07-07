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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE TABLE [Tracks] (
        [id] int NOT NULL IDENTITY,
        [track_Name] nvarchar(max) NOT NULL,
        [quize_id] int NOT NULL,
        CONSTRAINT [PK_Tracks] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE TABLE [Courses] (
        [id] int NOT NULL IDENTITY,
        [Course_name] nvarchar(max) NOT NULL,
        [Course_type] nvarchar(max) NOT NULL,
        [Course_link] nvarchar(max) NOT NULL,
        [Course_level] int NOT NULL,
        [Track_id] int NOT NULL,
        CONSTRAINT [PK_Courses] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Courses_Tracks_Track_id] FOREIGN KEY ([Track_id]) REFERENCES [Tracks] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE TABLE [Quizes] (
        [id] int NOT NULL IDENTITY,
        [Score] int NOT NULL,
        [Track_id] int NOT NULL,
        CONSTRAINT [PK_Quizes] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Quizes_Tracks_Track_id] FOREIGN KEY ([Track_id]) REFERENCES [Tracks] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE TABLE [DashBoards] (
        [id] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [age] int NULL,
        [phone] nvarchar(max) NULL,
        [Image] nvarchar(max) NULL,
        [Job] nvarchar(max) NOT NULL,
        [user_Level] int NOT NULL,
        [Coursesid] int NULL,
        CONSTRAINT [PK_DashBoards] PRIMARY KEY ([id]),
        CONSTRAINT [FK_DashBoards_Courses_Coursesid] FOREIGN KEY ([Coursesid]) REFERENCES [Courses] ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE TABLE [Questions] (
        [id] int NOT NULL IDENTITY,
        [Quizes_id] int NOT NULL,
        [Quizesid] int NOT NULL,
        [question_Header] nvarchar(max) NOT NULL,
        [Right_answer] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Questions] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Questions_Quizes_Quizesid] FOREIGN KEY ([Quizesid]) REFERENCES [Quizes] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE TABLE [Choices] (
        [id] int NOT NULL IDENTITY,
        [Question_id] int NOT NULL,
        [Questionid] int NOT NULL,
        [choice] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Choices] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Choices_Questions_Questionid] FOREIGN KEY ([Questionid]) REFERENCES [Questions] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE TABLE [DashBoard_Track] (
        [Dash_Id] int NOT NULL,
        [Track_Id] int NOT NULL,
        [DashBoardid] int NOT NULL,
        [Tracksid] int NOT NULL,
        CONSTRAINT [PK_DashBoard_Track] PRIMARY KEY ([Track_Id], [Dash_Id]),
        CONSTRAINT [FK_DashBoard_Track_DashBoards_DashBoardid] FOREIGN KEY ([DashBoardid]) REFERENCES [DashBoards] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DashBoard_Track_Tracks_Tracksid] FOREIGN KEY ([Tracksid]) REFERENCES [Tracks] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE INDEX [IX_Choices_Questionid] ON [Choices] ([Questionid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE INDEX [IX_Courses_Track_id] ON [Courses] ([Track_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE INDEX [IX_DashBoard_Track_DashBoardid] ON [DashBoard_Track] ([DashBoardid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE INDEX [IX_DashBoard_Track_Tracksid] ON [DashBoard_Track] ([Tracksid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE INDEX [IX_DashBoards_Coursesid] ON [DashBoards] ([Coursesid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE INDEX [IX_Questions_Quizesid] ON [Questions] ([Quizesid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    CREATE UNIQUE INDEX [IX_Quizes_Track_id] ON [Quizes] ([Track_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230514202828_UpdateMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230514202828_UpdateMigration', N'6.0.16');
END;
GO

COMMIT;
GO

