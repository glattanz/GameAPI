SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_AddLanguage
	@GameId int,
	@LanguageId int

AS
BEGIN

	SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Games WHERE Id = @GameId)
    BEGIN
        RETURN
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Languages WHERE Id = @LanguageId)
    BEGIN
        RETURN
    END

    INSERT INTO GameLanguages
        (GameId,
	     LanguageId)
    VALUES
        (@GameId,
	     @LanguageId)
    
END