SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_Create
	@Title nvarchar(256),
    @Description nvarchar(max),
    @GenreId int,
    @DeveloperId int,
    @PublisherId int,
    @Rating int = 0,
    @ReleaseDate datetime,
    @IsAvaliable bit

AS
BEGIN

	SET NOCOUNT ON;

    DECLARE @id int;

    INSERT INTO Games
    (Title,
     [Description],
     GenreId,
     DeveloperId,
     PublisherId,
     Rating,
     ReleaseDate,
     IsAvaliable)
    VALUES
    (@Title,
     @Description,
     @GenreId,
     @DeveloperId,
     @PublisherId,
     @Rating,
     @ReleaseDate,
     @IsAvaliable)
    
	SET @id = @@IDENTITY

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
    WHERE Id = @id
    
END