ALTER PROCEDURE [dbo].[GetWardsByDoctor]
@EmployeeId varchar (20)
AS
BEGIN
	SELECT CONCAT([WardNo],' - ',[WardType]) as Wards, [WardNo]
	FROM [dbo].[Ward]
	WHERE [Owner] = @EmployeeId AND IsActive = 'true'
	ORDER BY [WardNo]
END
