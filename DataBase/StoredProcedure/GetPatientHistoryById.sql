CREATE PROCEDURE [dbo].[GetPatientHistoryById]
@PatientId varchar (20)
AS
BEGIN
	SELECT * FROM [dbo].[Examiation]
	WHERE PatientId = @PatientId
END