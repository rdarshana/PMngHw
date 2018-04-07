CREATE PROCEDURE [dbo].[GetAllDoctors]
AS
BEGIN
	SELECT [EmployeeId],CONCAT([FirstName],' ',[LastName]) as Owner FROM [dbo].[Employee]
	WHERE [EmployeeType] = 'doctor'
	ORDER BY [FirstName]
END
