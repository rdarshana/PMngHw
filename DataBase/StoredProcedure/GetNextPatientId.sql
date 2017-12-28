CREATE PROCEDURE [dbo].[GetNextPatientId]
--@NextPatientId VARCHAR(20) OUTPUT
AS
BEGIN
DECLARE @RowCount INTEGER;

	SET @RowCount = (SELECT COUNT(*) FROM dbo.Patient  WHERE YEAR(CreationDate) = YEAR( getdate()));
	SELECT CONCAT('PAT', @RowCount +1 ,'-', YEAR(getdate()));
	--SELECT @NextPatientId =  CONCAT(@RowCount +1 ,'-', YEAR(getdate()));
END
