ALTER PROCEDURE [dbo].[GetExistingEmployeeNIC]
@NIC varchar (10)
AS
BEGIN
	SELECT NIC
	FROM [dbo].[Employee]
	WHERE [NIC] = @NIC
END