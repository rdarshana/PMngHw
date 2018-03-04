CREATE PROCEDURE [dbo].[GetAllWardData]
AS
BEGIN
	SELECT CONCAT(e.FirstName,' ',e.LastName) as Owner, w.[WardNo], w.[WardType], w.[NoOfBeds]
	FROM [dbo].[Ward] w INNER JOIN [dbo].[Employee] e ON w.[Owner] = e.[EmployeeId]

END