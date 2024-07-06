SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_AddSubGenre
	@GameId int,
	@GenreId int

AS
BEGIN

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.Games WHERE Id = @GameId)
    BEGIN
        RETURN
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Genres WHERE Id = @GenreId)
    BEGIN
        RETURN
    END

    INSERT INTO GameSubgenres
        (GameId,
	     SubgenreId)
    VALUES
        (@GameId,
	     @GenreId)
    
END