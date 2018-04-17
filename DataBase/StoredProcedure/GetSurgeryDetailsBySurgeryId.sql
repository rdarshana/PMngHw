ALTER PROCEDURE  [dbo].[GetSurgeryDetailsBySurgeryId]
@SurgeryId INT
AS
BEGIN
	SELECT PA.[PatientId], PA.[NIC], PA.[FirstName], PA.[LastName], SU.*
	FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Patient] PA ON SU.PatientId = PA.PatientId
	WHERE [SurgeryId] = @SurgeryId
END