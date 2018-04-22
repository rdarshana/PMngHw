CREATE PROCEDURE [dbo].[UpdateSurgeruStatus]
@SurgeryId INT,
@Note VARCHAR(500),
@Status VARCHAR(10)
AS
BEGIN
	UPDATE [dbo].[Surgery] SET [PostOperationMng] = @Note , [Status] = @Status
	WHERE [SurgeryId] = @SurgeryId
END