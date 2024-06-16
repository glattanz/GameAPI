SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Languages_Create
	@Name nvarchar(256)

AS
BEGIN

	SET NOCOUNT ON;

    DECLARE @id int;

    INSERT INTO Languages
    (Name)
    VALUES
    (@Name)
    
	SET @id = @@IDENTITY

	SELECT
		Id,
        Name
    FROM Languages WITH(NOLOCK)
    WHERE Id = @id
    
END