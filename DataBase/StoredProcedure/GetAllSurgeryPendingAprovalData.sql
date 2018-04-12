ALTER PROCEDURE [dbo].[GetAllSurgeryPendingAprovalData]
@UserType VARCHAR(15)
AS
BEGIN
	SELECT SU.[SurgeryId],SU.[PatientId],SU.[TheatorId],CONCAT(PA.FirstName,' ',PA.LastName) as Patient, PA.[NIC]
	FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Patient] PA ON SU.[PatientId] = PA.[PatientId] 
		  INNER JOIN [dbo].[Employee] EM ON EM.[EmployeeId] = SU.[DoctorId]
	WHERE [SurgeryStart] > getdate() AND EM.[EmployeeType] = @UserType
	ORDER BY [SurgeryStart]
END