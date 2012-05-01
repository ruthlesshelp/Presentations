IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Application_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Application_Create]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Application_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Application_Delete]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Application_Retrieve]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Application_Retrieve]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Application_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Application_Update]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Individual_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Individual_Create]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Individual_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Individual_Delete]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Individual_Retrieve]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Individual_Retrieve]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Individual_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Individual_Update]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Student_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Student_Create]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Student_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Student_Delete]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Student_Retrieve]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Student_Retrieve]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dal_Student_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[dal_Student_Update]
GO

