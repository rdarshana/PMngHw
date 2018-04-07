CREATE PROCEDURE [dbo].[GetWardOwners]
AS
BEGIN
	SELECT EM.EmployeeId, CONCAT(EM.FirstName,' ',EM.LastName) as Owner
	FROM [dbo].[Ward] WD INNER JOIN [dbo].[Employee] EM ON WD.Owner = EM.EmployeeId
	WHERE EM.IsActive = 'true'
	ORDER BY EM.FirstName
END