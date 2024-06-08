SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Tags_Update
    @Id int,
	@Name nvarchar(256)

AS
BEGIN

	SET NOCOUNT ON;

    UPDATE Tags SET
     Name = @Name
    WHERE Id = @Id

	SELECT
		Id,
        Name
    FROM Tags WITH(NOLOCK)
    WHERE Id = @Id
    
END