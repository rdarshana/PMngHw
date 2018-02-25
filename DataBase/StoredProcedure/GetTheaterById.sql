CREATE PROCEDURE [dbo].[GetTheaterById]
@TheaterId varchar (20)
AS
BEGIN
	SELECT * FROM [dbo].[Theator]
	WHERE TheatorId = @TheaterId
END