/****** Script for SelectTopNRows command from SSMS  ******/
--Insert into Patient (FirstName) values('Asela')

/*Drop TABLE Patient*/

/*CREATE SEQUENCE [dbo].[Patient_Seq]  AS
INT START WITH 1
INCREMENT BY 1 ;


ALTER TABLE [dbo].[Patient]
ADD CONSTRAINT Const_Patient_Seq
DEFAULT FORMAT((NEXT VALUE FOR [dbo].[Patient_Seq]),'PAT#') FOR [PatientId];*/


SELECT * from dbo.Patient


--Alter TABLE dbo.Patient 
--ADD CreationDate date;



--SELECT COUNT(*) FROM dbo.Patient  WHERE YEAR(CreationDate) = YEAR( getdate())

--Exec [dbo].[GetNextPatientId]

--DROP SEQUENCE [dbo].[Patient_Seq] 

--SELECT TOP 1 PatientId FROM dbo.Patient  WHERE YEAR(CreationDate) = YEAR( getdate()) ORDER BY PatientId DESC


--SELECT * FROM Split('PAT3-2017', '-')