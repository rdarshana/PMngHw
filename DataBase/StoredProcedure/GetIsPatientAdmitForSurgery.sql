ALTER PROCEDURE [dbo].[GetIsPatientAdmitForSurgery]
@patientId VARCHAR(20)
AS
BEGIN
	SELECT TOP 1 [WardNo]
	FROM [dbo].[Surgery]
	WHERE [PatientId] = @patientId AND [Status] = 'pending' AND DATEADD(day, 1,AdmissionDate) >=  getdate()
	ORDER BY [AdmissionDate]
END