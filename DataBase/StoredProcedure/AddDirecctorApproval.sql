ALTER PROCEDURE AddDirecctorApproval
@SurgeryId INT,
@DirectorApproval VARCHAR(10),
@DirectorDescription VARCHAR(200),
@Approver VARCHAR(20)
AS
BEGIN
	UPDATE [dbo].[Surgery] SET [DirectorApproval] = @DirectorApproval, [DirectorDescription] = @DirectorDescription, [DirectorApprover] = @Approver
	WHERE [SurgeryId] = @SurgeryId
END