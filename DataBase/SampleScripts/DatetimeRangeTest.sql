DECLARE @FrmDt DATETIME, @ToDt DATETIME
--SELECT @FrmDt='2018-04-08 23:51:00.000', @ToDt='2018-04-10 23:55:00.000'

SELECT @FrmDt='2018-04-10', @ToDt='2018-04-11'

--SELECT COUNT(SurgeryId)
--FROM [dbo].[Surgery]
--WHERE ((@FrmDt <= SurgeryStart) AND (@ToDt >= SurgeryEnd)) OR
--      (@FrmDt BETWEEN SurgeryStart AND SurgeryEnd) OR 
--	  (@ToDt BETWEEN SurgeryStart AND SurgeryEnd)

	  --((@FrmDt <= SurgeryStart) AND (@ToDt <= SurgeryStart)) OR
	  --((@FrmDt >= SurgeryEnd) AND (@ToDt >= SurgeryEnd))

--2018-04-09 22:30:00.000	2018-04-09 23:50:00.000	


SELECT [SurgeryId], [SurgeryStart], [SurgeryEnd], [TheatorId], CONCAT(EM.FirstName,' ',EM.LastName) as Doctor
FROM [dbo].[Surgery] SU INNER JOIN [dbo].[Employee] EM ON SU.DoctorId = EM.EmployeeId
WHERE (@FrmDt <= SU.SurgeryStart) AND (@ToDt >= SU.SurgeryEnd)
