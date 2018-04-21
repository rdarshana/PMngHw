ALTER PROCEDURE [dbo].[GetAllTheaters]
AS
BEGIN
	SELECT [TheatorId]
	FROM [dbo].[Theator]
	WHERE [IsActive] = 'true'
	ORDER BY [TheatorId]
END