ALTER PROCEDURE [dbo].[GetPatientAdmissionDetailsById]
@PatientId varchar (20),
@Status varchar (10)
AS
BEGIN
DECLARE @SearchQuery VARCHAR (500);

IF (@PatientId ='')
	BEGIN
		SET @SearchQuery= 'SELECT CONCAT(PA.FirstName,'' '',PA.LastName) as Patient, PD.[AdmissionId], PD.[PatientId], PD.[WardNo], PD.[AdmissionDate], PD.[DischageDate], PD.[AdmissionStatus] FROM [dbo].[PatientAdmission] PD, [dbo].[Patient] PA WHERE PA.[PatientId] = PD.[PatientId] AND PD.AdmissionStatus LIKE ' + ' ''%' + @Status +'%'' ORDER BY PD.[AdmissionDate] ';
	END

ELSE
	BEGIN
		SET @SearchQuery= 'SELECT CONCAT(PA.FirstName,'' '',PA.LastName) as Patient, PD.[AdmissionId], PD.[PatientId], PD.[WardNo], PD.[AdmissionDate], PD.[DischageDate], PD.[AdmissionStatus] FROM [dbo].[PatientAdmission] PD, [dbo].[Patient] PA WHERE PA.[PatientId] = PD.[PatientId] AND PD.PatientId LIKE ' + ' ''%' + @PatientId +'%'' AND PD.AdmissionStatus LIKE ' + ' ''%' + @Status +'%'' ORDER BY PD.[AdmissionDate]';
	END

exec (@SearchQuery)

END