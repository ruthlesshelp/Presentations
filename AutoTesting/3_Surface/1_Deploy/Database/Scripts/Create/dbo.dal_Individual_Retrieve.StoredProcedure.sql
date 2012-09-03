IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Individual_Retrieve]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Individual_Retrieve]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[dal_Individual_Retrieve] 
	@Id int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    SELECT [Id]
        ,[LastName]
        ,[FirstName]
        ,[MiddleName]
        ,[Suffix]
        ,[DateOfBirth]
    FROM [dbo].[Individual]
    WHERE
        [Id] = @Id

END
GO
