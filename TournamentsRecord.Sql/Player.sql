USE [Ashi]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 28/02/2020 3:03:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Player](	
	[PlayerId] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] Not NULL,
	[FullName] [nvarchar](250) NULL,
	[DOB] [date] NULL,
	[POB] [nvarchar](250) NULL,	
	[PhoneNumber] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Nationality] [nvarchar](250) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](25) NULL,
	[ModifyDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](25) NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Team_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO

ALTER TABLE [dbo].[Player] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Player] ADD  DEFAULT (getdate()) FOR [ModifyDate]
GO




