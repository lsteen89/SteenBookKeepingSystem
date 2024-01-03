IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'BookKeeping')
BEGIN
CREATE DATABASE BookKeeping
END
GO
    USE BookKeeping
GO