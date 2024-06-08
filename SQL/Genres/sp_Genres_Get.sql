SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Genres_Get
	@Id int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		Id,
        Name
    FROM Genres WITH(NOLOCK)
    WHERE Id = @Id
    
END