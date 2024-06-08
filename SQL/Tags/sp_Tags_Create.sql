SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Tags_Create
	@Name nvarchar(256)

AS
BEGIN

	SET NOCOUNT ON;

    DECLARE @id int;

    INSERT INTO Tags
    (Name)
    VALUES
    (@Name)
    
	SET @id = @@IDENTITY

	SELECT
		Id,
        Name
    FROM Tags WITH(NOLOCK)
    WHERE Id = @id
    
END