SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Publishers_Update
    @Id int,
	@Name nvarchar(256)

AS
BEGIN

	SET NOCOUNT ON;

    UPDATE Publishers SET
     Name = @Name
    WHERE Id = @Id

	SELECT
		Id,
        Name
    FROM Publishers WITH(NOLOCK)
    WHERE Id = @Id
    
END