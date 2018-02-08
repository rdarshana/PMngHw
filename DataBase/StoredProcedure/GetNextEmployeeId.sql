ALTER PROCEDURE [dbo].[GetNextEmployeeId]

AS
BEGIN
	SELECT COUNT(*) FROM dbo.Employee WHERE YEAR(CreationDate) = YEAR( getdate());
END
