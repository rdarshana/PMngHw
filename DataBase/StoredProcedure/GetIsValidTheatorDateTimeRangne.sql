ALTER PROCEDURE [dbo].[GetIsValidTheatorDateTimeRangne]
@FromDate DATETIME,
@ToDate	DATETIME,
@TheatorId VARCHAR(5)
AS
BEGIN
SELECT *
FROM [dbo].[Surgery]
WHERE (((@FromDate <= SurgeryStart) AND (@ToDate >= SurgeryEnd)) OR
      (@FromDate BETWEEN SurgeryStart AND SurgeryEnd) OR 
	  (@ToDate BETWEEN SurgeryStart AND SurgeryEnd)) AND TheatorId = @TheatorId
END
