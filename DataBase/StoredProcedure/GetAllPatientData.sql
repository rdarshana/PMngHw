ALTER PROCEDURE [dbo].[GetAllPatientData]
AS
BEGIN
	SELECT * FROM [dbo].[Patient]
	ORDER BY [CreationDate]
END