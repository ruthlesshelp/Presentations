IF EXISTS ( SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Students]') ) 
   DROP VIEW [dbo].[vw_Students]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Students]
AS
    SELECT
        [Individual].[Id]
       ,[LastName]
       ,[FirstName]
       ,[MiddleName]
       ,[Suffix]
       ,[DateOfBirth]
       ,[HighSchoolName]
       ,[HighSchoolCity]
       ,[HighSchoolState]
    FROM
        [Individual]
        INNER JOIN [Student]
        ON [Individual].[Id] = [Student].[Id]
GO
