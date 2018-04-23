USE [PntMngOpeWrd]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[GetPatientSurgeryList]
		@SearchColumn = N'd',
		@SearchValue = NULL,
		@Doctor = N'default',
		@SurgeryFrom = NULL,
		@SurgeryTo = NULL,
		@AdmissionFrom = NULL,
		@AdmissionTo = NULL,
		@SurgeryStatus = N'default',
		@TheatorId = N'default'

SELECT	'Return Value' = @return_value

GO
