SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.sp_Tags_List
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		Id,
        Name
    FROM Tags WITH(NOLOCK)

END