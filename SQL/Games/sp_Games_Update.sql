SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_Update
    @Id int,
	@Title nvarchar(256),
    @Description nvarchar(max),
    @Genre nvarchar(256),
    @DeveloperId int,
    @PublisherId int,
    @Rating float,
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

    UPDATE Games SET
     Title = @Title,
     [Description] = @Description,
     Genre = @Genre,
     DeveloperId = @DeveloperId,
     PublisherId = @PublisherId,
     Rating = @Rating,
     ReleaseDate = @ReleaseDate,
     IsAvaliable = @IsAvaliable,
     [Size] = @Size,
     Tags = @Tags,
     Subgenres =  @Subgenres,
     AvaliableLanguages = @AvaliableLanguages,
     AvaliablePlatforms = @AvaliablePlatforms
    WHERE Id = @Id

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
    WHERE Id = @Id
    
END