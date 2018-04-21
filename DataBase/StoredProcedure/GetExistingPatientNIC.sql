CREATE PROCEDURE [dbo].[GetExistingPatientNIC]
@NIC varchar (10)
AS
BEGIN
	SELECT NIC
	FROM [dbo].[Patient]
	WHERE [NIC] = @NIC
END