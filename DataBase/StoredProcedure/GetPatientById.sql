CREATE PROCEDURE [dbo].[GetPatientById]
@PatientId varchar (20)
AS
BEGIN
	SELECT * FROM [dbo].[Patient]
	WHERE PatientId = @PatientId
END