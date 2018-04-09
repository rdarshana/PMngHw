ALTER PROCEDURE [dbo].[SurgeryRegistration]
	@SurgeryId INT,
	@AdmissionDate DATE,
	@Description	VARCHAR(200),
	@SurgeryStart	VARCHAR(20),
	@SurgeryEnd	VARCHAR(20),
	@IsNewSurgery BIT,
	@TheatorId	VARCHAR(5),
	@DoctorId VARCHAR(20),
	@PatientId VARCHAR(20)
AS
BEGIN

	IF(@IsNewSurgery = 'true')
		BEGIN
			INSERT INTO [dbo].[Surgery](AdmissionDate, Description, SurgeryStart, SurgeryEnd, Status, TheatorId, DoctorId, PatientId, RegistrationDate) 
					VALUES (@AdmissionDate, @Description, convert(datetime,@SurgeryStart), convert(datetime,@SurgeryEnd), 'pending', @TheatorId, @DoctorId, @PatientId, getdate());
	END

	ELSE
		BEGIN
			UPDATE [dbo].[Surgery] SET AdmissionDate = @AdmissionDate, Description = @Description, SurgeryStart = @SurgeryStart, SurgeryEnd = @SurgeryEnd , TheatorId = @TheatorId, DoctorId = @DoctorId
			WHERE SurgeryId = @SurgeryId;
		END
	END