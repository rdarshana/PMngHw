CREATE PROCEDURE [dbo].[AddPatientExamination]
	@PatientId VARCHAR (20),
	@EmployeeId VARCHAR(20),
    @Complain VARCHAR (500),
	@Examination VARCHAR (500),
	@Diagnosis VARCHAR(100),
	@Drugs VARCHAR(500),
	@IsNewExamine VARCHAR(6)

AS
BEGIN
	IF(@IsNewExamine = 'true')
		BEGIN
			INSERT INTO [dbo].[Examiation](PatientId, EmployeeId, Complain, Examination, Diagnosis, Drugs, ExamineDate)
			VALUES (@PatientId, @EmployeeId, @Complain,@Examination,@Diagnosis,@Drugs, getdate())
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Examiation]
			SET Complain = @Complain, Examination = @Examination, Diagnosis= @Diagnosis,Drugs = @Drugs
			WHERE PatientId = @PatientId and EmployeeId = @EmployeeId
		END
END