IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Individual]') AND type in (N'U'))
BEGIN
	PRINT N'!!!'
	PRINT N'Cannot create table [dbo].[Individual]. It already already exists.'
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individual](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Suffix] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_Individual] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
BEGIN
	PRINT N'!!!'
	PRINT N'Cannot create table [dbo].[Student]. It already already exists.'
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[HighSchoolName] [nvarchar](50) NULL,
	[HighSchoolCity] [nvarchar](40) NULL,
	[HighSchoolState] [nvarchar](2) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Individual] FOREIGN KEY([Id])
REFERENCES [dbo].[Individual] ([Id])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Individual]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Application]') AND type in (N'U'))
BEGIN
	PRINT N'!!!'
	PRINT N'Cannot create table [dbo].[Application]. It already already exists.'
END
GO

CREATE TABLE [dbo].[Application](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Principal] [decimal](9, 2) NULL,
	[AnnualPercentageRate] [decimal](6, 4) NULL,
	[TotalPayments] [int] NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO

ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Student]
GO

