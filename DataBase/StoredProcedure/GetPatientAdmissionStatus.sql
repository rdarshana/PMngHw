ALTER PROCEDURE [dbo].[GetPatientAdmissionStatus]
@PatientId VARCHAR(20),
@AdmissionId INT
AS
BEGIN
	IF (@AdmissionId = 0)
		BEGIN
		   SELECT TOP 1 AdmissionId, AdmissionStatus, AdmissionDescription, DischargeDescription, WardNo
		   FROM [dbo].[PatientAdmission]
		   WHERE [PatientId] = @PatientId
		   ORDER BY [AdmissionDate] DESC, AdmissionId DESC
		 END
	ELSE
		BEGIN
			SELECT AdmissionId, AdmissionStatus, AdmissionDescription, DischargeDescription, WardNo
		    FROM [dbo].[PatientAdmission]
		    WHERE [AdmissionId] = @AdmissionId
		END
END
