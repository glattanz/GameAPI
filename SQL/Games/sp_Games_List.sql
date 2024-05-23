SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_List
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		Id,
        Title,
        [Description],
        Genre,
        DeveloperId,
        PublisherId,
        Rating,
        ReleaseDate,
        IsAvaliable,
        [Size],
        Tags,
        Subgenres,
        AvaliableLanguages,
        AvaliablePlatforms
    FROM Games WITH(NOLOCK)

END