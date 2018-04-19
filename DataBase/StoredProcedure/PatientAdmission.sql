ALTER PROCEDURE [dbo].[PatientWardAdmission]
	@AdmissionId INT,
	@WardNo	VARCHAR (5),
	@PatientId VARCHAR (20),
	@AdmissionDescription VARCHAR (500),
	@AdmittedBy VARCHAR(20),
	@DischargeDescription VARCHAR (500),
	@IsNewAdmission BIT,
	@AdmissionStatus VARCHAR (20),
	@SurgeryId INT
AS
BEGIN

	IF(@IsNewAdmission = 'true')
		BEGIN
			INSERT INTO [dbo].[PatientAdmission](WardNo, PatientId, AdmissionDescription, AdmissionDate, AdmittedBy, DischargeDescription, AdmissionStatus, SurgeryId) 
					VALUES (@WardNo, @PatientId, @AdmissionDescription , getdate() ,@AdmittedBy, @DischargeDescription, 'admitted', @SurgeryId);
	END

	ELSE
		BEGIN
			IF(@AdmissionStatus = 'updateAdmission')
				BEGIN
					UPDATE [dbo].[PatientAdmission] SET WardNo = @WardNo, PatientId= @PatientId, AdmissionDescription = @AdmissionDescription 
					WHERE AdmissionId= @AdmissionId;
				END
			ELSE
				BEGIN
					UPDATE [dbo].[PatientAdmission] SET WardNo = @WardNo, PatientId= @PatientId, DischargedBy = @AdmittedBy, DischargeDescription = @DischargeDescription, AdmissionStatus = 'discharged' , DischageDate = getdate() 
					WHERE AdmissionId= @AdmissionId;
				END
		END
	END
