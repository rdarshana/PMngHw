CREATE PROCEDURE [dbO].[DeletePatientById]
@PatientId varchar(15)
AS
BEGIN
	DELETE
	FROM [dbo].[Patient]
	WHERE PatientId = @PatientId

END