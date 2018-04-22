ALTER PROCEDURE [dbo].[GetExistingEmployeeNIC]
@NIC varchar (10),
@EID varchar (20)
AS
BEGIN
	SELECT NIC
	FROM [dbo].[Employee]
	WHERE [NIC] = @NIC AND [EmployeeId] != @EID
END