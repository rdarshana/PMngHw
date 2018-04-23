ALTER PROCEDURE [dbo].[GetPatientSurgeryList]
@SearchColumn VARCHAR(20),
@SearchValue VARCHAR(20),
@Doctor VARCHAR(20),
@SurgeryFrom VARCHAR(10),
@SurgeryTo VARCHAR(10),
@AdmissionFrom VARCHAR(10),
@AdmissionTo VARCHAR(10),
@SurgeryStatus VARCHAR(10),
@TheatorId VARCHAR(10)
AS
BEGIN
DECLARE @SearchQuery VARCHAR (1000);
DECLARE @QueryPatient VARCHAR (200);
DECLARE @QueryDoctor VARCHAR (200);
DECLARE @QueryStatus VARCHAR (200);
DECLARE @QueryAdmissionDate VARCHAR (200);
DECLARE @QuerySurgeryDate VARCHAR (200);
DECLARE @QueryDefault VARCHAR (1000);
DECLARE @QueryTheator VARCHAR (200);

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

IF (@SurgeryStatus != 'default')
	BEGIN
		SET @QueryStatus = 'AND SU.Status = '''+@SurgeryStatus+'''';
	END
ELSE
	BEGIN
		SET @QueryStatus = '';
	END

IF (@SurgeryFrom != '' AND @SurgeryTo != '')
	BEGIN
		SET @QuerySurgeryDate = 'AND SU.SurgeryStart BETWEEN '''+@SurgeryFrom+''' AND DATEADD(DAY,1,'''+@SurgeryTo+''' )';
	END
ELSE
	BEGIN
		SET @QuerySurgeryDate = '';
	END

IF (@AdmissionFrom != '' AND @AdmissionTo != '')
	BEGIN
		SET @QueryAdmissionDate = 'AND SU.AdmissionDate BETWEEN '''+@AdmissionFrom+''' AND DATEADD(DAY,1,'''+@AdmissionTo+''' )';
	END
ELSE
	BEGIN
		SET @QueryAdmissionDate = '';
	END

IF (@TheatorId != 'default')
	BEGIN
		SET @QueryTheator = 'AND SU.TheatorId = '''+@TheatorId+'''';
	END
ELSE
	BEGIN
		SET @QueryTheator = '';
	END
	
	--ELSE IF (@SearchValue = '' AND @Doctor = 'default' AND @SurgeryStatus = 'default' AND (@SurgeryFrom = '' OR @SurgeryTo = '') AND (@AdmissionFrom = '' OR @AdmissionTo = ''))
	--BEGIN
	--	SET @QuerySurgeryDate = 'AND SU.SurgeryStart BETWEEN DATEADD(DAY,-1,getdate()) AND getdate()';
	--END

--IF	(@SearchValue = '' AND @Doctor != 'default' AND @SurgeryStatus != 'default' AND (@SurgeryFrom = '' OR @SurgeryTo = '') AND (@AdmissionFrom = '' OR @AdmissionTo = ''))
--	BEGIN
--		SET @SearchQuery = 'SELECT SU.[SurgeryId],SU.[PatientId], SU.[TheatorId], SU.[SurgeryStart], SU.[AdmissionDate], SU.[WardNo], SU.[Status], CONCAT(PA.FirstName,'' '',PA.LastName) as Patient, PA.[NIC], PAD.[AdmissionStatus]
--	FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Patient] PA ON SU.[PatientId] = PA.[PatientId] 
--		 LEFT JOIN [dbo].[PatientAdmission] PAD ON SU.[SurgeryId] = PAD.[SurgeryId]
--	WHERE SU.[PatientId] IS NOT NULL AND SU.[AdmissionDate] = getdate() AND SU.[SurgeonApproval] = ''approved'' AND [AnesthetistApproval] = ''approved'' AND [DirectorApproval] = ''approved'' AND [Status]=''pending'' AND PAD.[AdmissionStatus] = ''admitted''
--	ORDER BY SU.[AdmissionDate]';
--	END

--'+@QueryTheator+'
--' +@QueryAdmissionDate+'

SET	@SearchQuery = 'SELECT SU.[SurgeryId],SU.[PatientId], SU.[DoctorId], SU.[TheatorId], SU.[SurgeryStart], SU.[AdmissionDate], SU.[WardNo], SU.[Status], CONCAT(PA.FirstName,'' '',PA.LastName) as Patient, PA.[NIC], PAD.[AdmissionStatus]
	FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Patient] PA ON SU.[PatientId] = PA.[PatientId] 
		 LEFT JOIN [dbo].[PatientAdmission] PAD ON SU.[SurgeryId] = PAD.[SurgeryId]
	WHERE SU.[PatientId] IS NOT NULL '+@QueryPatient+' ' +@QueryDoctor+' ' +@QueryStatus+' ' +@QuerySurgeryDate+' ' +@QueryAdmissionDate+' ' +@QueryTheator+'
	ORDER BY SU.[AdmissionDate]';

	PRINT @SearchQuery;

	exec (@SearchQuery)
END