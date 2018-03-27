CREATE PROCEDURE [dbo].[GetUserDetailsById]
	@EmployeeId VARCHAR (20)
AS
	BEGIN
		SELECT Password, UserGuid, EmployeeType, CONCAT([FirstName],' ',[LastName]) as Name
		FROM [dbo].[Employee]
		WHERE @EmployeeId = EmployeeId and IsActive = 'true'
	END