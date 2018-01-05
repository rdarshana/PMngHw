ALTER PROCEDURE [dbo].[GetNextEmployeeId]
@EmployeeType VARCHAR (15)
AS
BEGIN
DECLARE @RowCount INTEGER;
DECLARE @SelectQuery VARCHAR(200);

	--SET @SelectQuery = 'SELECT COUNT(*) FROM dbo.'+ @EmployeeType +  ' WHERE YEAR(CreationDate) = YEAR( getdate())';

	SET @SelectQuery = 'SELECT COUNT(*) FROM dbo.@EmployeeType WHERE YEAR(CreationDate) = YEAR( getdate())';

	EXEC dbo.sp_executesql @SelectQuery,N'@EmployeeType varchar(15)', N'@RowCount INTEGER OUTPUT',@EmployeeType, @RowCount OUTPUT;

	--exec @RowCount = @SelectQuery;

	--PRINT @SelectQuery;
	--PRINT @RowCount
	--@RowCount = 

	--SELECT CONCAT('PAT', @RowCount +1 ,'-', YEAR(getdate()));
	--SELECT @NextPatientId =  CONCAT(@RowCount +1 ,'-', YEAR(getdate()));
END
