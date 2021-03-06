﻿CREATE TABLE [dbo].[Examiation] (
	ID int IDENTITY(1,1),
    [PatientId]    VARCHAR (20)   NOT NULL,
    [EmployeeId]   VARCHAR (20)   NOT NULL,
	[Complain]     VARCHAR (500)  NOT NULL,
	[Examination]  VARCHAR (500)  NOT NULL,
    [Diagnosis]    VARCHAR (100)  NOT NULL,
	[Drugs]		   VARCHAR (500)  NOT NULL,
	[ExamineDate]		   DATE,
    PRIMARY KEY CLUSTERED (ID),
	CONSTRAINT FK_ExaminePatient FOREIGN KEY (PatientId) REFERENCES Patient (PatientId),
	CONSTRAINT FK_ExamineDoctor FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId)
);