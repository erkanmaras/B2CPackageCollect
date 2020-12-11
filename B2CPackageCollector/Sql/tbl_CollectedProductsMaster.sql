USE [ProgramTest]
GO

/****** Object:  Table [dbo].[CollectedProductsMaster]    Script Date: 12/7/2017 1:28:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectedProductsMaster](
	[CollectedProductsMasterID] [uniqueidentifier] NOT NULL,
	[AlisverisID] [char](20) NOT NULL,
	[IsPrinted] [bit] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[CompleteType] [smallint] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CollectedProductsMaster] PRIMARY KEY NONCLUSTERED 
(
	[CollectedProductsMasterID] ASC,
	[AlisverisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CollectedProductsMaster] ADD  DEFAULT ((0)) FOR [IsPrinted]
GO

ALTER TABLE [dbo].[CollectedProductsMaster] ADD  DEFAULT ((0)) FOR [IsCompleted]
GO

ALTER TABLE [dbo].[CollectedProductsMaster] ADD  DEFAULT ((0)) FOR [CompleteType]
GO


