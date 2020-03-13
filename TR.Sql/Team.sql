USE [Ashi]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 28/02/2020 3:03:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Team](	
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](600) NOT NULL,		
	[SportType] [int] Not NULL,
	[YearEstablish] [int] NULL,
	[LogoId] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](25) NULL,
	[ModifyDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](25) NULL,
	
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Team] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Team] ADD  DEFAULT (getdate()) FOR [ModifyDate]
GO



