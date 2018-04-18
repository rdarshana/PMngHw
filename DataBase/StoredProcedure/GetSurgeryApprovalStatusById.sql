ALTER PROCEDURE GetSurgeryApprovalStatusById
@SurgeryId INT
AS
	BEGIN
		SELECT SU.[PatientId], SU.[SurgeonApproval], SU.[AnesthetistApproval], SU.[DirectorApproval]
		FROM [dbo].[Surgery] SU INNER JOIN [dbo].[PatientAdmission] PAD ON PAD.[PatientId] = SU.[PatientId]
		WHERE [SurgeryId] = @SurgeryId AND (getdate() BETWEEN SU.[AdmissionDate] AND SU.[SurgeryStart])
		AND PAD.[AdmissionStatus] = 'admitted'
		ORDER BY SU.[AdmissionDate]
	END