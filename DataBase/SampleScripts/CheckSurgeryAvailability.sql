USE [PntMngOpeWrd]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[GetIsValidTheatorDateTimeRangne]
		@FromDate = N'2018/04/23 10:00 AM',
		@ToDate = N'2018/04/23 11:00 AM',
		@TheatorId = N'THE-2',
		@IsNewSurgery = true,
		@SurgeryId = 0

SELECT	'Return Value' = @return_value

GO
