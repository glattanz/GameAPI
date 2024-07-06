SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_AddPlatform
	@GameId int,
	@PlatformId int

AS
BEGIN

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.Games WHERE Id = @GameId)
    BEGIN
        RETURN
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Platforms WHERE Id = @PlatformId)
    BEGIN
        RETURN
    END

    INSERT INTO GamePlatforms
        (GameId,
	     PlatformId)
    VALUES
        (@GameId,
	     @PlatformId)
    
END