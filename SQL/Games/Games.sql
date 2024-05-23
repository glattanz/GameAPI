SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM SysObjects WHERE Name = 'Games')
BEGIN
	--* drop table dbo.Games
    RETURN
END

CREATE TABLE dbo.Games
(
    Id int IDENTITY(1,1) NOT NULL,
    Title nvarchar(256) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	Genre nvarchar(256) NOT NULL,
	DeveloperId int NOT NULL,
	PublisherId int NOT NULL,
	Rating float NOT NULL DEFAULT 0,
	ReleaseDate datetime NOT NULL,
    IsAvaliable bit NOT NULL DEFAULT 1,
	[Size] float NOT NULL,
	Tags nvarchar(max) NULL,
	Subgenres nvarchar(max) NULL,
	AvaliableLanguages nvarchar(max) NULL,
	AvaliablePlatforms nvarchar(max) NULL
) ON [PRIMARY]

ALTER TABLE dbo.Games ADD CONSTRAINT PK_Games PRIMARY KEY CLUSTERED
(
    Id ASC
)
WITH (
    PAD_INDEX = OFF,
    STATISTICS_NORECOMPUTE = OFF,
    SORT_IN_TEMPDB = OFF,
    IGNORE_DUP_KEY = OFF,
    ONLINE = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
) ON [PRIMARY]

CREATE NONCLUSTERED INDEX IDX_Games_Id ON dbo.Games
(
	Id ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]