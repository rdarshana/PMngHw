CREATE PROCEDURE [dbo].[GetPatientAdmissionDetailsById]
@PatientId varchar (20),
@Status varchar (10)
AS
BEGIN
DECLARE @SearchQuery VARCHAR (500);

IF (@PatientId ='')
	BEGIN
		SET @SearchQuery= 'SELECT * FROM [dbo].[PatientAdmission] WHERE AdmissionStatus LIKE ' + ' ''%' + @Status +'%'' ORDER BY [AdmissionDate] ';
	END

ELSE
	BEGIN
		SET @SearchQuery= 'SELECT * FROM [dbo].[PatientAdmission] WHERE PatientId LIKE ' + ' ''%' + @PatientId +'%'' AND AdmissionStatus LIKE ' + ' ''%' + @Status +'%'' ORDER BY [AdmissionDate]';
	END

exec (@SearchQuery)

END