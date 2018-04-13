ALTER PROCEDURE [dbo].[GetPatientAdmissionById]
@AdmissionId INT
AS
BEGIN
	SELECT PA.[PatientId], PA.[FirstName], PA.[LastName], PA.[NIC], PD.[WardNo], PD.[AdmissionDescription], PD.[DischargeDescription]
	FROM [dbo].[PatientAdmission] PD INNER JOIN [dbo].[Patient] PA ON PD.[PatientId] = PA.[PatientId]
	WHERE PD.AdmissionId = @AdmissionId
END