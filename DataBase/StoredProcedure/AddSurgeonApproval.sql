CREATE PROCEDURE AddSurgeonApproval
@SurgeryId INT,
@SurgeonApproval VARCHAR(10),
@SurgeonDescription VARCHAR(200),
@Approver VARCHAR(20)
AS
BEGIN
	UPDATE [dbo].[Surgery] SET [SurgeonApproval] = @SurgeonApproval, [SurgeonDescription] = @SurgeonDescription, SurgeonApprover = @Approver
	WHERE [SurgeryId] = @SurgeryId
END