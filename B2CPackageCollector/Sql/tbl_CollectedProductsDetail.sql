
/****** Object:  Table [dbo].[CollectedProductsDetail]    Script Date: 12/7/2017 1:28:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectedProductsDetail](
	[CollectedProductsDetailID] [uniqueidentifier] NOT NULL,
	[IslemID] [numeric](10, 0) NULL,
	[CollectedQty] [numeric](14, 4) NULL,
	[AlisverisID] [char](20) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CollectedProductsDetailID] PRIMARY KEY NONCLUSTERED 
(
	[CollectedProductsDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CollectedProductsDetail] ADD  DEFAULT ((0)) FOR [CollectedQty]
GO


