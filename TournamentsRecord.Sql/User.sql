USE [Ashi]
GO

/****** Object:  Table [dbo].[User]    Script Date: 2/03/2020 2:39:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](	
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](128) NOT NULL,
	[EmailAddress] [nvarchar](128) NOT NULL,
	[GivenName] [nvarchar](25) NOT NULL,
	[FamilyName] [nvarchar](25) NOT NULL,	
	[UserType] [int] NOT NULL,
	[ExternalUserId] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](25) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[ModifyBy] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[User] ADD  DEFAULT (N'') FOR [Password]
GO






