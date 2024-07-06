SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_AddTag
	@GameId int,
	@TagId int

AS
BEGIN

	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.Games WHERE Id = @GameId)
    BEGIN
        RETURN
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Tags WHERE Id = @TagId)
    BEGIN
        RETURN
    END

    INSERT INTO GameTags
        (GameId,
	     TagId)
    VALUES
        (@GameId,
	     @TagId)
    
END