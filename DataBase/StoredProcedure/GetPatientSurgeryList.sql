ALTER PROCEDURE [dbo].[GetPatientSurgeryList]
@SearchColumn VARCHAR(20),
@SearchValue VARCHAR(20),
@Doctor VARCHAR(20)
AS
BEGIN
DECLARE @SearchQuery VARCHAR (1000);
DECLARE @QueryStatus VARCHAR (500);
DECLARE @QueryPatient VARCHAR (200);
DECLARE @QueryDoctor VARCHAR (200);

IF (@SearchValue != '')
	BEGIN
		SET @QueryPatient = 'AND SU.'+@SearchColumn+' = '''+@SearchValue+'''';
	END
ELSE
	BEGIN
		SET @QueryPatient = '';
	END

IF (@Doctor != 'default')
	BEGIN
		SET @QueryDoctor = 'AND SU.DoctorId = '''+@Doctor+'''';
	END
ELSE
	BEGIN
		SET @QueryDoctor = '';
	END

--IF (@UserType = 'doctor')
--	BEGIN
--		SET @QueryStatus = 'AND SU.[SurgeonApproval] IS NULL';
--	END

--ELSE IF (@UserType = 'anesthetist')
--	BEGIN
--		SET @QueryStatus = 'AND SU.[SurgeonApproval] = ''approved'' AND SU.[AnesthetistApproval] IS NULL';
--	END

--ELSE
--	BEGIN
--		SET @QueryStatus = 'AND SU.[SurgeonApproval] = ''approved'' AND SU.[AnesthetistApproval] = ''approved'' AND SU.[DirectorApproval] IS NULL';
--	END


SET	@SearchQuery = 'SELECT SU.[SurgeryId],SU.[PatientId], SU.[TheatorId], SU.[SurgeryStart], SU.[WardNo], SU.[Status], CONCAT(PA.FirstName,'' '',PA.LastName) as Patient, PA.[NIC], PAD.[AdmissionStatus]
	FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Patient] PA ON SU.[PatientId] = PA.[PatientId] 
		 LEFT JOIN [dbo].[PatientAdmission] PAD ON SU.[SurgeryId] = PAD.[SurgeryId]
	WHERE SU.[PatientId] IS NOT NULL '+@QueryPatient+' ' +@QueryDoctor+'
	ORDER BY SU.[AdmissionDate]';

	PRINT @SearchQuery;

	exec (@SearchQuery)
END