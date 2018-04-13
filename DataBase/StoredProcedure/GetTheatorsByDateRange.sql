ALTER PROCEDURE [dbo].[GetTheatorsByDateRange]
@FromDate DATE,
@ToDate	DATE,
@TheatorId VARCHAR(5)

AS
BEGIN
DECLARE @ToDt DATETIME;
SET @ToDt = DATEADD(day, 1, @ToDate);

SELECT [SurgeryId], [SurgeryStart], [PatientId], [SurgeryEnd], [TheatorId], CONCAT(EM.FirstName,' ',EM.LastName) as Doctor
FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Employee] EM ON SU.DoctorId = EM.EmployeeId
WHERE (@FromDate <= SU.SurgeryStart) AND (DATEADD(day, 1, @ToDate) >= SU.SurgeryEnd) AND SU.TheatorId = @TheatorId
ORDER BY [SurgeryStart]
END
