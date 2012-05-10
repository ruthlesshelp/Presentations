IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_ApplicationTotals]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[rpt_ApplicationTotals]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE rpt_ApplicationTotals
	-- Add the parameters for the stored procedure here
	@StudentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT SUM(Principal) AS Total
	FROM dbo.[Application]
	WHERE
	    StudentId = @StudentId

END
GO
