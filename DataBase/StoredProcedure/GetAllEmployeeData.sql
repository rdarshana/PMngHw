ALTER PROCEDURE [dbo].[GetAllEmployeeData]
AS
BEGIN
	SELECT * FROM [dbo].[Employee]
	ORDER BY [EmployeeId]
END