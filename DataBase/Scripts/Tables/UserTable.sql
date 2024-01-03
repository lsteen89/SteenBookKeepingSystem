IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')
BEGIN
    CREATE TABLE Users (
        UserId UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        Username NVARCHAR(100) NOT NULL UNIQUE,
        Email NVARCHAR(100) NOT NULL UNIQUE,
        Password NVARCHAR(MAX) NOT NULL,
        DateOfBirth DateTime NOT NULL,
        FullName NVARCHAR(200) NOT NULL
    )
END
GO