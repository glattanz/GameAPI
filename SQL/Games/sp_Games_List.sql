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
        GenreId,
        DeveloperId,
        PublisherId,
        Rating,
        ReleaseDate,
        IsAvaliable
    FROM Games WITH(NOLOCK)

END