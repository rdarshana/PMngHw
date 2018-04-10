CREATE PROCEDURE [dbo].[GetTheatorsByDateRange]
@FromDate DATE,
@ToDate	DATE
AS
BEGIN
SELECT [SurgeryId], [SurgeryStart], [SurgeryEnd], [TheatorId], CONCAT(EM.FirstName,' ',EM.LastName) as Doctor
FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Employee] EM ON SU.DoctorId = EM.EmployeeId
WHERE (@FromDate >= SU.SurgeryStart) AND (@ToDate <= SU.SurgeryEnd)
END
