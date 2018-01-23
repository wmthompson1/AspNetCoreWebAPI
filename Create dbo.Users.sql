USE [BookstoreDb]
GO

--/****** Object: Table [dbo].[Users] Script Date: 1/18/2018 1:55:20 PM ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO


--CREATE TABLE [dbo].[Users] (
--    [Id]           INT             IDENTITY (1, 1) NOT NULL,
--    [FirstName]    VARCHAR (30)    NULL,
--    [LastName]     VARCHAR (50)    NULL,
--    [Username]     VARCHAR (50)    NULL,
--    [Password]     VARCHAR (50)	   NULL

--);

INSERT INTO dbo.Users(FirstName, LastName, UserName, [Password])
VALUES('William', 'Thompson', 'wmThompson1', 'abc')
