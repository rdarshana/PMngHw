CREATE PROCEDURE [dbo].[GetAllTheaters]
AS
BEGIN
	SELECT [TheatorId]
	FROM [dbo].[Theator]
	ORDER BY [TheatorId]
END