SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Games_Get
	@Id int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		*
    FROM Games WITH(NOLOCK)
    WHERE Id = @Id
    
END