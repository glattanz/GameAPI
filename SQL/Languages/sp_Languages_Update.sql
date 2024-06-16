SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Languages_Update
    @Id int,
	@Name nvarchar(256)

AS
BEGIN

	SET NOCOUNT ON;

    UPDATE Languages SET
     Name = @Name
    WHERE Id = @Id

	SELECT
		Id,
        Name
    FROM Languages WITH(NOLOCK)
    WHERE Id = @Id
    
END