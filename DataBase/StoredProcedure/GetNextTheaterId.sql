CREATE PROCEDURE [dbo].[GetNextTheaterId]
AS
BEGIN
DECLARE @RowCount INTEGER;
	SET @RowCount = (SELECT COUNT(*) FROM dbo.Theator);
	SELECT CONCAT('THE','-', @RowCount +1);
END
