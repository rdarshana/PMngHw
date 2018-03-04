CREATE PROCEDURE [dbo].[GetNextWardNo]
AS
BEGIN
DECLARE @RowCount INTEGER;
	SET @RowCount = (SELECT COUNT(*) FROM dbo.Ward);
	SELECT CAST(@RowCount +1 AS VARCHAR(6));
END
