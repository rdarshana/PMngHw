CREATE TABLE [dbo].[Examiation] (
    [PatientId]    VARCHAR (20)   NOT NULL,
    [EmployeeId]   VARCHAR (20) NOT NULL,
	[Complain]     VARCHAR (500)  NOT NULL,
	[Examination]  VARCHAR (500)  NOT NULL,
    [Diagnosis]    VARCHAR (100)   NOT NULL,
	[Drugs]		   VARCHAR (500) NOT NULL,
	[Date]		   DATE,
    PRIMARY KEY CLUSTERED (PatientId, EmployeeId),
	CONSTRAINT FK_ExaminePatient FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	CONSTRAINT FK_ExamineDoctor FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId)
);