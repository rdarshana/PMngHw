USE [PntMngOpeWrd]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SurgeryRegistration]
		@SurgeryId = 0,
		@AdmissionDate =  N'2018/04/08',
		@Description = N'2018/04/08',
		@SurgeryStart = N'2018/04/08 11:28 PM',
		@SurgeryEnd = N'2018/04/09 12:28 AM',
		@IsNewSurgery = 0,
		@TheatorId = N'THE-1',
		@DoctorId = N'EMP-13',
		@PatientId = N'PAT1-2018'

SELECT	'Return Value' = @return_value

GO
