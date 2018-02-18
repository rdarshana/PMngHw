CREATE PROCEDURE [dbo].[GetEmployeeById]
@EmployeeId varchar (20)
AS
BEGIN
	SELECT * FROM [dbo].[Employee]
	WHERE EmployeeId = @EmployeeId
END