ALTER PROCEDURE AddAnesthesiaApproval
@SurgeryId INT,
@AnesthetistApproval VARCHAR(10),
@ModeOfAnesthesia VARCHAR(100),
@AnesthetistProblem VARCHAR(200),
@Approver VARCHAR(20)
AS
BEGIN
	UPDATE [dbo].[Surgery] SET [AnesthetistApproval] = @AnesthetistApproval, [ModeOfAnesthesia] = @ModeOfAnesthesia,[AnesthetistProlems] = @AnesthetistProblem , [AnesthetistApprover] = @Approver
	WHERE [SurgeryId] = @SurgeryId
END