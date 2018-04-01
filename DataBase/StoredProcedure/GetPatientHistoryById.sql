CREATE PROCEDURE [dbo].[GetPatientHistoryById]
@PatientId varchar (20)
AS
BEGIN
	SELECT CONCAT(em.FirstName,' ',em.LastName) as Employee, ex.ID, ex.PatientId,ex.EmployeeId,ex.Complain,ex.Examination,ex.Diagnosis,ex.Drugs,ex.ExamineDate
	FROM [dbo].[Examiation] ex INNER JOIN [dbo].[Employee] em ON ex.EmployeeId = em.EmployeeId
	WHERE PatientId = @PatientId
END