ALTER PROCEDURE [dbo].[GetPatientAdmissionStatus]
@PatientId VARCHAR(20)
AS
BEGIN
	   SELECT TOP 1 AdmissionStatus
	   FROM [dbo].[PatientAdmission]
	   WHERE [PatientId] = @PatientId
	   ORDER BY [AdmissionDate] DESC
END
