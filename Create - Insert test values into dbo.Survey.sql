USE [BookstoreDb]
GO

SELECT * FROM [dbo].[Survey]

--INSERT INTO [dbo].[Survey] (
--  [Name]
--  ,[Description]
--  ,SurveyTypeCode
--  ,Instructions
--  ,IsLocked
--  ,LeaverYear
--)

--SELECT
--  'Name field value2'
--  ,'Description field value2'
--  ,'Name field value2'
--  ,'Instructions field value2'
--  , 0
--  ,'2015-16'

--  'Name field value'

--/****** Object: Table [dbo].[Survey] Script Date: 1/19/2018 10:03:08 AM ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TABLE [dbo].[Survey] (
--    [Id]             INT             IDENTITY (1, 1) NOT NULL,
--    [Name]           NVARCHAR (500)  NULL,
--    [Description]    NVARCHAR (3000) NULL,
--    [SurveyTypeCode] VARCHAR (50)    NULL,
--    [Instructions]   NVARCHAR (3000) NULL,
--    [IsLocked]       BIT             NULL,
--    [CloseDate]      DATETIME        NULL,
--    [CreateDate]     DATETIME        NULL,
--    [CreatedBy]      VARCHAR (50)    NULL,
--    [UpdateDate]     DATETIME        NULL,
--    [UpdatedBy]      VARCHAR (50)    NULL,
--    [SchoolYear]     CHAR (7)        NULL,
--    [LeaverYear]     CHAR (7)        NULL,
--    [IsReported]     BIT             NULL,
--    [OpenDate]       DATETIME        NULL
--);


