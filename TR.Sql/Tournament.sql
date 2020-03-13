USE [Ashi]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 28/02/2020 3:03:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tournament](	
	[TournamentId] [int] IDENTITY(1,1) NOT NULL,	
	[UserId] [int] Not NULL,	
	[Name] [nvarchar](250) NULL,	
	[SportType] [int] Not NULL,
	[PhoneNumber] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Nationality] [nvarchar](250) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](25) NULL,
	[ModifyDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](25) NULL,
 CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED 
(
	[TournamentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tournament]  WITH CHECK ADD  CONSTRAINT [FK_Tournament_User_USerId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Tournament] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Tournament] ADD  DEFAULT (getdate()) FOR [ModifyDate]
GO




