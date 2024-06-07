SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_Update
    @Id int,
	@Title nvarchar(256),
    @Description nvarchar(max),
    @GenreId int,
    @DeveloperId int,
    @PublisherId int,
    @Rating float,
    @ReleaseDate datetime,
    @IsAvaliable bit

AS
BEGIN

	SET NOCOUNT ON;

    UPDATE Games SET
     Title = @Title,
     [Description] = @Description,
     GenreId = @GenreId,
     DeveloperId = @DeveloperId,
     PublisherId = @PublisherId,
     Rating = @Rating,
     ReleaseDate = @ReleaseDate,
     IsAvaliable = @IsAvaliable
    WHERE Id = @Id

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
    WHERE Id = @Id
    
END