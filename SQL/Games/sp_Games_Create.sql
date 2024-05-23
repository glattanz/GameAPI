SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_Create
	@Title nvarchar(256),
    @Description nvarchar(max),
    @Genre nvarchar(256),
    @DeveloperId int,
    @PublisherId int,
    @Rating int = 0,
    @ReleaseDate datetime,
    @IsAvaliable bit,
    @Size float,
    @Tags nvarchar(max) = '',
    @Subgenres nvarchar(max) = '',
    @AvaliableLanguages nvarchar(max) = '',
    @AvaliablePlatforms nvarchar(max) = ''

AS
BEGIN

	SET NOCOUNT ON;

    DECLARE @id int;

    INSERT INTO Games
    (Title,
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
     AvaliablePlatforms)
    VALUES
    (@Title,
     @Description,
     @Genre,
     @DeveloperId,
     @PublisherId,
     @Rating,
     @ReleaseDate,
     @IsAvaliable,
     @Size,
     @Tags,
     @Subgenres,
     @AvaliableLanguages,
     @AvaliablePlatforms)
    
	SET @id = @@IDENTITY

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
    WHERE Id = @id
    
END