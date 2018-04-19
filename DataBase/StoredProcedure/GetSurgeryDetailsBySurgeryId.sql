ALTER PROCEDURE  [dbo].[GetSurgeryDetailsBySurgeryId]
@SurgeryId INT
AS
BEGIN
DECLARE @IsEditable varchar(10);

SET @IsEditable = (SELECT COUNT([PatientId])
					FROM [dbo].[Surgery]
					WHERE [SurgeryId] = @SurgeryId AND [SurgeryStart] >=  getdate()
					AND [AnesthetistApproval] IS NULL AND [Status] = 'pending')

	SELECT PA.[PatientId], PA.[NIC], PA.[FirstName], PA.[LastName], SU.*, @IsEditable AS IsEditableCount
	FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Patient] PA ON SU.PatientId = PA.PatientId
	WHERE SU.[SurgeryId] = @SurgeryId
END