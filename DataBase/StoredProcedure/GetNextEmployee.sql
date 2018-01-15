ALTER PROCEDURE [dbo].[GetNextEmployeeId]
@EmployeeType VARCHAR (15)
AS
BEGIN
DECLARE @RowCount INTEGER;
DECLARE @SelectQuery VARCHAR(200);

	SET @SelectQuery = 'SELECT COUNT(*) FROM dbo.'+ @EmployeeType +  ' WHERE YEAR(CreationDate) = YEAR( getdate())';
	exec (@SelectQuery);

END
