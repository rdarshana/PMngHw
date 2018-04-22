ALTER PROCEDURE [dbo].[GetExistingPatientNIC]
@NIC varchar (10),
@PID VARCHAR(20)
AS
BEGIN
	SELECT NIC
	FROM [dbo].[Patient]
	WHERE [NIC] = @NIC AND [PatientId] != @PID
END